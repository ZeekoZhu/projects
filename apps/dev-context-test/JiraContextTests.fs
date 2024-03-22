module Projects.DevContext.JiraContextTests

open Microsoft.Extensions.Logging.Abstractions
open Microsoft.Extensions.Logging
open Moq.AutoMock
open NUnit.Framework
open FsUnitTyped
open Projects.DevContext.ContextProviders

let mockLogger<'a> (mocker: AutoMocker) =
  let logger = (new NullLoggerFactory()).CreateLogger<'a>()
  mocker.Use(logger)

let mockRepoDir (mocker: AutoMocker) (dir: string) =
  mocker.GetMock<IRepoContext>().Setup(fun x -> x.Dir()).Returns(dir) |> ignore

let mockGitBranch (mocker: AutoMocker) (branch: string option) =
  let result =
    branch
    |> Option.map (fun x ->
      { FriendlyName = x
        FullName = "refs/heads/" + x })

  mocker.GetMock<IGitContext>().Setup(fun x -> x.Branch()).Returns(result)
  |> ignore

let fakeJiraConfig =
  { BaseUrl = "https://example.atlassian.net"
    AuthInfo = BasicAuth("user", "pass")
    IssueKeyPrefix = "DEV-" }

[<Test>]
let createJiraCtx (mocker: AutoMocker) (config: ParsedJiraConfig) =
  mocker.Use(config)

  let jiraCtx = mocker.CreateInstance<JiraContext>()

  jiraCtx :> IJiraContext

[<Test>]
let ``extract issue key from repo dir path`` () =
  let container = AutoMocker()
  mockLogger<JiraContext> container
  mockRepoDir container "c:\\repos\\DEV-1234"
  mockGitBranch container None

  let jiraCtx = createJiraCtx container fakeJiraConfig

  jiraCtx.IssueKey() |> shouldEqual (Some "DEV-1234")


[<Test>]
let ``extract issue key from git branch name`` () =
  let container = AutoMocker()
  mockLogger<JiraContext> container
  mockRepoDir container "c:\\repos\\"
  mockGitBranch container (Some "DEV-555-fix-something")

  let jiraCtx = createJiraCtx container fakeJiraConfig

  jiraCtx.IssueKey() |> shouldEqual (Some "DEV-555")

[<Test>]
let ``unable to extract issue key`` () =
  let container = AutoMocker()
  mockLogger<JiraContext> container
  mockRepoDir container "c:\\repos\\"
  mockGitBranch container None

  let jiraCtx = createJiraCtx container fakeJiraConfig

  jiraCtx.IssueKey() |> shouldEqual None

[<Test>]
let ``prefix without '-'`` () =
  let container = AutoMocker()
  mockLogger<JiraContext> container
  mockRepoDir container "c:\\repos\\DEV-111-fix-something"
  mockGitBranch container None

  let jiraCtx =
    createJiraCtx
      container
      { fakeJiraConfig with
          IssueKeyPrefix = "DEV" }

  jiraCtx.IssueKey() |> shouldEqual (Some "DEV-111")
