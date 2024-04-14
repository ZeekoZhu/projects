namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open System.IO
open System.Text.RegularExpressions
open System.Threading.Tasks
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Projects.DevContext
open Projects.DevContext.Core
open Projects.DevContext.Core.Model
open FsToolkit.ErrorHandling
open FSharpPlus
open Projects.DevContext.Utils
open Projects.GitLabApi.Abstraction
open Projects.GitLabApi.Concrete
open Projects.GitLabApi.Model
open YamlDotNet.Serialization

[<AllowNullLiteral>]
type GitLabContextConfig() =
  member val Host = "https://gitlab.com" with get, set
  member val Token: Secret = "" with get, set


type GitLabMROutput =
  { IID: int64
    Id: int64
    Title: string
    Description: string
    State: string
    WebURL: string
    SourceBranch: string
    TargetBranch: string }

type GitLabProjectOutput =
  { ID: int64
    Name: string
    WebUrl: string
    SSHUrl: string
    HTTPUrl: string }

[<AllowNullLiteral>]
type GitLabCreateMRInput() =
  member val Title = "" with get, set
  member val Description = "" with get, set

module GitLabInput =
  open Validator
  let deserializer =
    DeserializerBuilder()
      .WithNamingConvention(NamingConventions.CamelCaseNamingConvention.Instance)
      .Build()

  let parseCreateMRYaml<'a when 'a : null> (content: string) = deserializer.Deserialize<'a>(content) |> Option.ofObj

  let validateCreateMRInput (input: GitLabCreateMRInput) =
    input |>
    (Validations.nonEmptyString _.Title (konst """Title can not be empty"""))
    @ (Validations.nonEmptyString _.Description (konst """Description can not be empty"""))
    |> Validations.toValidationException

  let readCreateMRInput (path: FileInfo) =
    TaskResult.protect File.ReadAllTextAsync path.FullName
    |> TaskResult.map parseCreateMRYaml<GitLabCreateMRInput>
    |> TaskResult.bindRequireSome (exn "Failed to parse input file")
    |> Task.map (Result.bind validateCreateMRInput)

type IGitLabContext =
  abstract member MergeRequest: unit -> GitLabMROutput option Task
  abstract member Project: unit -> GitLabProjectOutput option Task

module GitLabUtils =
  let private pattern = Regex("^(http|https)://", RegexOptions.Compiled)

  let getNamespacedPath (gitRepoUrl: string) =
    let isHttpProtocol (url: string) = pattern.IsMatch(url)

    if isHttpProtocol gitRepoUrl then
      let url = Uri(gitRepoUrl)
      let path = url.AbsolutePath.Replace(".git", "").TrimStart('/')
      path
    else
      let parts = gitRepoUrl.Split(":")
      let path = (Array.last parts).Replace(".git", "")
      path

type GitLabContext(config: GitLabContextConfig, git: IGitContext, gitlabApi: IGitLabApi, logger: ILogger<GitLabContext>)
  =
  let fetchProject () =
    git.RemoteRepositoryUrl()
    |> Option.map GitLabUtils.getNamespacedPath
    |> TaskOption.FromResult
    |> TaskOption.bind (fun path ->
      logger.LogDebug("Fetching project information for {Path}", path)

      gitlabApi.Project.GetProjectAsync(path, GetProjectRequestParams())
      |> Task.map Option.ofObj)
    |> TaskOption.map (fun project ->
      { ID = project.Id
        Name = project.Name
        WebUrl = project.WebUrl
        SSHUrl = project.SshUrlToRepo
        HTTPUrl = project.HttpUrlToRepo })

  let fetchMergeRequest () =
    let fetchMR branch projectId =
      gitlabApi.MergeRequest.ListProjectMergeRequestsAsync(
        projectId,
        ListMergeRequestsRequestParams(SourceBranch = branch)
      )
      |> Task.map (fun it ->
        logger.LogDebug("Merge requests: {@Response}", it)
        it.Items |> (Option.ofObj >> (Option.bind Array.tryHead)))

    taskOption {
      let! branch = git.Branch() |> Task.FromResult
      let! project = fetchProject ()
      return! fetchMR branch.FriendlyName (project.ID.ToString())
    }

  let mrDtoToOutput (mr: MergeRequestDto) =
    { IID = mr.Iid
      Id = mr.Id
      Title = mr.Title
      Description = mr.Description
      State = mr.State
      WebURL = mr.WebUrl
      SourceBranch = mr.SourceBranch
      TargetBranch = mr.TargetBranch }

  let createMRWithApi (input: GitLabCreateMRInput) projectId currentBranch targetBranch =
    let param =
      CreateMergeRequestParams(
        SourceBranch = currentBranch.FriendlyName,
        TargetBranch = targetBranch.FriendlyName,
        Title = input.Title,
        Description = input.Description
      )

    TaskResult.protect gitlabApi.MergeRequest.CreateMergeRequestAsync (projectId, param)


  let createMergeRequest (input: GitLabCreateMRInput) =
    // check if there is an open MR for the branch
    // if yes, aborts.
    let ensureNoMr =
      fetchMergeRequest ()
      |> map (Result.requireNone (exn "Merge request already exists"))

    let projectId =
      fetchProject ()
      |> map (map (_.ID >> string) >> Result.requireSome (exn "Project not found"))

    let branch = git.Branch() |> Result.requireSome (exn "Branch not found")

    let mergeTargetBranch =
      git.MergeTargetBranch()
      |> Result.requireSome (exn "Merge target branch not found")

    createMRWithApi input
    |> konst
    |> TaskResult.liftApply ensureNoMr
    |> TaskResult.applyF projectId
    |> TaskResult.applyResultF branch
    |> TaskResult.applyResultF mergeTargetBranch
    |> TaskResult.bind id
    |> TaskResult.map mrDtoToOutput

  interface IGitLabContext with
    member this.MergeRequest() =
      fetchMergeRequest () |> TaskOption.map mrDtoToOutput

    member this.Project() = fetchProject ()

module GitLabContextConfig =
  open Validator

  let readConfig () =
    AppConfig.section<GitLabContextConfig> "GitLab"
      |> (Validations.notNone id "Please provide GitLab configuration in config file"
      @ Validations.nonEmptyString (_.Host) (konst """Host can not be empty""")
      @ Validations.nonEmptyString (_.Token) (konst """Token can not be empty"""))

module GitLabCommand =
  let addGitLabContext (services: IServiceCollection) =
    let config =
      GitLabContextConfig.readConfig ()
      |> Result.defaultWith (fun e ->
        getLogger<GitLabContextConfig>()
          .Error("Failed to read GitLab config: {Errors}", e)

        failwith "Failed to read GitLab config")

    services
      .AddSingleton<IGitLabApi>(fun sp ->
        let logger = sp.GetService<ILogger<IGitLabApi>>()
        GitLabApi.Create(config.Host, config.Token, logger) :> IGitLabApi)
      .AddSingleton<IGitLabContext, GitLabContext>()
      .AddSingleton(config)

  let private configureServices () =
    ServiceCollection()
    |> DI.addLogger
    |> addGitLabContext
    |> GitCommand.addGitContext
    |> RepoCommand.addRepoContext
    |> DI.buildServiceProvider

  let addGetCommands (get: Command) =
    // Project
    let project = Command("gitlab:project", "Get project information")

    project.SetHandler(fun () ->
      let sp = configureServices ()
      let gitlabCtx = sp.GetService<IGitLabContext>()

      task {
        let! project = gitlabCtx.Project()
        writeToConsole project
      }
      :> Task)

    get.Add(project)

    // Merge Request
    let mergeRequest = Command("gitlab:mr", "Get merge request information")

    mergeRequest.SetHandler(fun () ->
      let sp = configureServices ()
      let gitlabCtx = sp.GetService<IGitLabContext>()

      task {
        let! mr = gitlabCtx.MergeRequest()
        writeToConsole mr
      }
      :> Task)

    get.Add(mergeRequest)


type GitLabContextCommandProvider() =
  interface IDevContextCommandProvider with
    member this.AddGetCommands(get: Command) = GitLabCommand.addGetCommands get
