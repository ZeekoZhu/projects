namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open System.Text.RegularExpressions
open FSharpPlus.Data
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Projects.DevContext
open Projects.DevContext.Core
open Serilog

type JiraContextConfig() =
  /// The issue key prefix to use when looking for issue keys, e.g. "PROJ-" or "PROJ"
  member val public IssueKeyPrefix: string = "" with get, set

type IJiraContext =
  abstract IssueKey: unit -> string option

type JiraContext
  (
    logger: ILogger<JiraContext>,
    repoCtx: IRepoContext,
    gitCtx: IGitContext,
    config: JiraContextConfig
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
  let nonEmptyPrefix (config: JiraContextConfig) =
    if String.IsNullOrWhiteSpace config.IssueKeyPrefix then
      Failure [ "Jira issue key prefix must not be empty" ]
    else
      Success config

  let readConfig () =
    AppConfig.section<JiraContextConfig> "Jira"
    |> Success
    |> Validation.bind nonEmptyPrefix

module JiraCommand =
  open Utils

  let addJiraContext (services: IServiceCollection) =
    let config = JiraContextConfig.readConfig ()

    match config with
    | Success config ->
      services.AddSingleton<IJiraContext, JiraContext>().AddSingleton(config)
    | Failure err ->
      Log
        .ForContext<JiraContext>()
        .Error("Failed to read jira context configuration: {Errors}", err)

      failwith "Failed to read jira context configuration"


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
