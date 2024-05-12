namespace Projects.DevContext.ContextProviders

open System.CommandLine
open System.Text.RegularExpressions
open System.Threading.Tasks
open FSharpPlus
open Projects.DevContext.Core
open FsToolkit.ErrorHandling
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Octokit
open Projects.DevContext
open Projects.DevContext.Utils


[<AllowNullLiteral>]
type GitHubContextConfig() =
  member val Token = "" with get, set

module GitHubContextConfig =
  open Validator

  let readConfig () =
    AppConfig.section<GitHubContextConfig> "GitHub"
    |> (Validations.notNone id "Please provide GitHub configuration in the config file"
        @ Validations.nonEmptyString (_.Token) (konst """Token can not be empty"""))

type GitHubProjectOutput =
  { Name: string
    Description: string
    Owner: string
    Repo: string
    WebUrl: string }

module GitHubUtils =
  let private pattern =
    Regex(".*[:/](?<owner>[^\/:]+?)/(?<repo>[^\/:]+?)(?:\.git)?$", RegexOptions.Compiled)

  let getOwnerRepoFromUrl (url: string) =
    Result.protect
      (fun () ->
        let matches = pattern.Match(url)

        if matches.Success then
          matches.Groups["owner"].Value, matches.Groups["repo"].Value

        else
          failwith "Not matched")
      ()

    |> Result.mapError (fun _ ->
      exn $"Failed to extract owner and repo from url: '{url}', please make sure the url is a GitHub repo url")


type IGitHubContext =
  abstract member Repository: unit -> GitHubProjectOutput option Task

type GitHubContext
  (config: GitHubContextConfig, git: IGitContext, githubClient: IGitHubClient, logger: ILogger<GitHubContext>) =
  let fetchRepoInfo () =
    let getGitHubRepo (owner, repo) =
      githubClient.Repository.Get(owner, repo) |> TaskResult.ofTask

    let ownerAndRepo =
      git.RemoteRepositoryUrl()
      |> Option.toResultWith (exn "Failed to get remote repository url")
      |> Result.bind GitHubUtils.getOwnerRepoFromUrl

    getGitHubRepo
    |> TaskResult.ok
    |> TaskResult.applyR ownerAndRepo
    |> TaskResult.bind id

  interface IGitHubContext with
    member this.Repository() =
      fetchRepoInfo ()
      |> TaskResult.tee (fun repo -> logger.LogDebug("Fetched GitHub repository info: {@Repo}", repo))
      |> TaskResult.map (fun repo ->
        { Name = repo.Name
          Description = repo.Description
          Owner = repo.Owner.Login
          Repo = repo.Name
          WebUrl = repo.HtmlUrl })
      |> TaskResult.teeError (fun e -> logger.LogError(e, "Failed to fetch GitHub repository info"))
      |> Task.map Result.toOption

module GitHubCommand =
  let addGitHubContext (services: IServiceCollection) =
    let config =
      GitHubContextConfig.readConfig ()
      |> Result.defaultWith (fun e ->
        getLogger<GitHubContextConfig>()
          .Error("Failed to read GitHub config: {Error}", e)

        failwith "Failed to read GitHub config")

    services
      .AddSingleton(config)
      .AddSingleton<IGitHubClient>(fun sp ->
        let githubClient = GitHubClient(ProductHeaderValue("dev-ctx"))
        githubClient.Credentials <- Credentials(config.Token)
        githubClient :> IGitHubClient)
      .AddSingleton<IGitHubContext, GitHubContext>()

  let private configureServices () =
    ServiceCollection()
    |> DI.addLogger
    |> addGitHubContext
    |> GitCommand.addGitContext
    |> RepoCommand.addRepoContext
    |> DI.buildServiceProvider

  let commands () =
    let project = Command("gh:project", "Get GitHub project information")

    project.SetHandler(fun () ->
      let sp = configureServices ()
      let githubCtx = sp.GetService<IGitHubContext>()
      githubCtx.Repository() |> TaskOption.iter writeToConsole :> Task)

    [ Get project ]

type GitHubContextCommandProvider() =
  interface IDevContextCommandProvider with
    member this.CreateCommands() = GitHubCommand.commands ()
