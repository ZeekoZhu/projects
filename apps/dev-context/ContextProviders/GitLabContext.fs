namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
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

type GitLabContext
  (
    config: GitLabContextConfig,
    git: IGitContext,
    gitlabApi: IGitLabApi,
    logger: ILogger<GitLabContext>
  ) =
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

  interface IGitLabContext with
    member this.MergeRequest() =
      taskOption {
        let! mr = fetchMergeRequest ()

        return
          { Id = mr.Id
            IID = mr.Iid
            Title = mr.Title
            Description = mr.Description
            State = mr.State
            WebURL = mr.WebUrl
            SourceBranch = mr.SourceBranch
            TargetBranch = mr.TargetBranch }
      }

    member this.Project() = fetchProject ()



module GitLabContextConfig =

  let readConfig () =
    let config = AppConfig.section<GitLabContextConfig> "GitLab"

    validation {
      let! config =
        config
        |> Validations.notNone
          id
          "Please provide GitLab configuration in config file"

      let! _ =
        config
        |> Validations.nonEmptyString
          (_.Host)
          (konst """Host can not be empty""")

      let! _ =
        config
        |> Validations.nonEmptyString
          (_.Token)
          (konst """Token can not be empty""")

      return config
    }

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
