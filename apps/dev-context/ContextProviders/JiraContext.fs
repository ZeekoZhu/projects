namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open System.Text.RegularExpressions
open FSharpPlus.Data
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Projects.DevContext
open Projects.DevContext.Core

type JiraContextConfig() =
  /// The issue key prefix to use when looking for issue keys, e.g. "PROJ-" or "PROJ"
  member val public IssueKeyPrefix: string = "" with get, set
  member val public BaseUrl: string = "" with get, set
  member val public Username: string = "" with get, set
  member val public Password: string = "" with get, set
  member val public PersonalAccessToken: string = "" with get, set

type Username = string
/// password or personal access token
type Secret = string

type JiraAuthInfo =
  | BasicAuth of Username * Secret
  | PAT of Secret

type ParsedJiraConfig =
  { IssueKeyPrefix: string
    BaseUrl: string
    AuthInfo: JiraAuthInfo }

type IJiraContext =
  abstract IssueKey: unit -> string option

type JiraContext
  (
    logger: ILogger<JiraContext>,
    repoCtx: IRepoContext,
    gitCtx: IGitContext,
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

  interface IJiraContext with
    member _.IssueKey() =
      tryGetIssueKeyFromString (gitCtx.Branch() |> Utils.toString)
      |> Option.orElseWith (fun () -> tryGetIssueKeyFromString (repoCtx.Dir()))

module JiraContextConfig =
  let private nonEmptyPrefix (config: JiraContextConfig) =
    if String.IsNullOrWhiteSpace config.IssueKeyPrefix then
      Failure [ "Jira issue key prefix must not be empty" ]
    else
      Success config

  let private validAuthInfo (config: JiraContextConfig) =
    match config.Username, config.Password, config.PersonalAccessToken with
    | username, password, _ when
      not <| String.IsNullOrWhiteSpace username
      && not <| String.IsNullOrWhiteSpace password
      ->
      Success(BasicAuth(username, password))
    | _, _, pat when not <| String.IsNullOrWhiteSpace pat -> Success(PAT pat)
    | _ ->
      Failure
        [ "Jira authentication information is invalid, please provide either (Username, Password) or (PersonalAccessToken)" ]

  let private nonEmptyBaseUrl (config: JiraContextConfig) =
    if String.IsNullOrWhiteSpace config.BaseUrl then
      Failure [ "Jira base url must not be empty" ]
    else
      Success config

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
      |> Validation.defaultWith (fun err ->
        getLogger()
          .Error("Failed to read jira context configuration: {Errors}", err)

        failwith "Failed to read jira context configuration")

    services.AddSingleton<IJiraContext, JiraContext>().AddSingleton(config)


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

type JiraContextCommandProvider() =
  interface IDevContextCommandProvider with
    member _.AddGetCommands(get: Command) = JiraCommand.addGetCommands get
