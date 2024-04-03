namespace Projects.DevContext.ContextProviders

open System
open System.Collections.Generic
open System.CommandLine
open System.Text.RegularExpressions
open System.Threading.Tasks
open FsToolkit.ErrorHandling
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Newtonsoft.Json.Linq
open Projects.DevContext
open Projects.DevContext.Core
open Projects.DevContext.Core.Model
open Projects.JiraPlatformApi.Api
open Projects.JiraPlatformApi.Client
open Projects.JiraPlatformApi.Model

type JiraContextConfig() =
  /// The issue key prefix to use when looking for issue keys, e.g. "PROJ-" or "PROJ"
  member val public IssueKeyPrefix: string = "" with get, set
  member val public BaseUrl: string = "" with get, set
  member val public Username: string = "" with get, set
  member val public Password: string = "" with get, set
  member val public PersonalAccessToken: string = "" with get, set

type JiraIssueOutput =
  { IssueKey: string
    Summary: string
    Description: string
    Status: string }

type IJiraContext =
  abstract IssueKey: unit -> string option
  abstract Issue: unit -> JiraIssueOutput option Task


type JiraAuthInfo =
  | BasicAuth of Username * Secret
  | PAT of Secret

type ParsedJiraConfig =
  { IssueKeyPrefix: string
    BaseUrl: string
    AuthInfo: JiraAuthInfo }


type JiraContext
  (
    logger: ILogger<JiraContext>,
    repoCtx: IRepoContext,
    gitCtx: IGitContext,
    jiraIssuesApi: IIssuesApi,
    config: ParsedJiraConfig
  ) =
  let getIssueKeyPattern () =
    let prefix = config.IssueKeyPrefix
    let prefix = if prefix.EndsWith("-") then prefix else prefix + "-"

    try
      Regex(prefix + @"\d+")
    with :? ArgumentException as e ->
      logger.LogError(e, "Invalid jira issue key prefix: '{Prefix}'", prefix)
      reraise ()

  let tryGetIssueKeyFromString (s: string) =
    let issueKeyPattern = getIssueKeyPattern ()
    let matched = issueKeyPattern.Match(s)
    if matched.Success then Some matched.Value else None

  let issueKey () =
    tryGetIssueKeyFromString (gitCtx.Branch() |> Utils.toString)
    |> Option.orElseWith (fun () -> tryGetIssueKeyFromString (repoCtx.Dir()))

  let getIssueByKey (key: string) =
    TaskResult.ofTask (jiraIssuesApi.GetIssueAsync(key))
    |> TaskResult.teeError (fun (err: exn) ->
      logger.LogError(err, "Failed to get issue by key '{Key}'", key))
    |> Task.map Result.toOption

  let tryGetString key (dict: IDictionary<string, obj>) =
    match dict.TryGetValue(key) with
    | true, value -> Some(value :?> string)
    | _ -> None

  let tryGetJObject key (dict: IDictionary<string, obj>) =
    match dict.TryGetValue(key) with
    | true, value -> Some(value :?> JObject)
    | _ -> None

  let toIssueOutput (issue: IssueBean) =
    { IssueKey = issue.Key
      Summary = issue.Fields |> tryGetString "summary" |> Option.defaultValue ""
      Description =
        issue.Fields |> tryGetString "description" |> Option.defaultValue ""
      Status =
        issue.Fields
        |> tryGetJObject "status"
        |> Option.map (_.Property("name").Value.ToString())
        |> Option.defaultValue "" }

  interface IJiraContext with
    member _.IssueKey() = issueKey ()

    member this.Issue() =
      issueKey ()
      |> Option.map getIssueByKey
      |> Option.defaultWith (fun () -> Task.FromResult None)
      |> TaskOption.map toIssueOutput



module JiraContextConfig =
  let private nonEmptyPrefix (config: JiraContextConfig) =
    if String.IsNullOrWhiteSpace config.IssueKeyPrefix then
      Validation.error [ "Jira issue key prefix must not be empty" ]
    else
      Validation.ok config

  let private validAuthInfo (config: JiraContextConfig) =
    match config.Username, config.Password, config.PersonalAccessToken with
    | username, password, _ when
      not <| String.IsNullOrWhiteSpace username
      && not <| String.IsNullOrWhiteSpace password
      ->
      Validation.ok (BasicAuth(username, password))
    | _, _, pat when not <| String.IsNullOrWhiteSpace pat ->
      Validation.ok (PAT pat)
    | _ ->
      Validation.error
        [ "Jira authentication information is invalid, please provide either (Username, Password) or (PersonalAccessToken)" ]

  let private nonEmptyBaseUrl (config: JiraContextConfig) =
    if String.IsNullOrWhiteSpace config.BaseUrl then
      Validation.error [ "Jira base url must not be empty" ]
    else
      Validation.ok config

  let parseConfig (config: JiraContextConfig) =
    nonEmptyPrefix config
    |> Validation.bind nonEmptyBaseUrl
    |> Validation.zip (validAuthInfo config)
    |> Validation.map (fun (authInfo, config) ->
      { IssueKeyPrefix = config.IssueKeyPrefix
        BaseUrl = config.BaseUrl
        AuthInfo = authInfo })

  let readConfig () =
    AppConfig.section<JiraContextConfig> "Jira" |> parseConfig

module JiraCommand =
  open Utils

  let addJiraContext (services: IServiceCollection) =
    let config =
      JiraContextConfig.readConfig ()
      |> Result.defaultWith (fun err ->
        getLogger()
          .Error("Failed to read jira context configuration: {Errors}", err)

        failwith "Failed to read jira context configuration")

    let apiConfig = Configuration()
    apiConfig.BasePath <- config.BaseUrl

    match config.AuthInfo with
    | BasicAuth(username, password) ->
      apiConfig.Username <- username
      apiConfig.Password <- password
    | PAT pat -> apiConfig.ApiKey.Add("Bearer", pat)

    let apiClient = IssuesApi(apiConfig)

    services
      .AddSingleton<IIssuesApi>(apiClient)
      .AddSingleton<IJiraContext, JiraContext>()
      .AddSingleton(config)


  let private configureServices () =
    ServiceCollection()
    |> DI.addLogger
    |> GitCommand.addGitContext
    |> RepoCommand.addRepoContext
    |> addJiraContext
    |> DI.buildServiceProvider

  let addGetCommands (get: Command) =
    let issueKey =
      Command(
        "jira:issuekey",
        "Get the Jira issue key from the current branch or repo directory"
      )

    issueKey.SetHandler(fun () ->
      use sp = configureServices ()
      let jiraCtx = sp.GetService<IJiraContext>()
      writeToConsole (jiraCtx.IssueKey()))

    get.Add(issueKey)

    let issueDetail = Command("jira:issue", "Get the Jira issue details")

    issueDetail.SetHandler(fun () ->
      let sp = configureServices ()
      let jiraCtx = sp.GetService<IJiraContext>()

      task {
        let! issue = jiraCtx.Issue()
        writeToConsole issue
      }
      :> Task)

    get.Add(issueDetail)


type JiraContextCommandProvider() =
  interface IDevContextCommandProvider with
    member _.AddGetCommands(get: Command) = JiraCommand.addGetCommands get
