namespace Projects.DevContext.ContextProviders

open System.CommandLine
open LibGit2Sharp
open Microsoft.Extensions.DependencyInjection
open Projects.DevContext
open Projects.DevContext.Core
open FSharpPlus
open Microsoft.Extensions.Logging


type BranchInfo =
  { FriendlyName: string
    FullName: string }

type GitContext(repoCtx: RepoContext, logger: ILogger<GitContext>) =
  member _.Branch() =
    let workingDir = repoCtx.Dir()

    monad {
      let! repoDir = Repository.Discover(workingDir) |> Option.ofObj
      logger.LogDebug("Repository found at {repoDir}", repoDir)
      use repo = new Repository(repoDir)

      let! currentBranch =
        repo.Branches |> Seq.tryFind (_.IsCurrentRepositoryHead)

      { FriendlyName = currentBranch.FriendlyName
        FullName = currentBranch.CanonicalName }
    }


module GitCommand =
  open Utils
  let build (builder: 'a -> 'a) (input: 'a) = builder input

  let configureServices () =
    ServiceCollection()
    |> DI.addSingleton<RepoContext>
    |> DI.addSingleton<GitContext>
    |> DI.addLogger
    |> DI.buildServiceProvider

  let addGetCommands (get: Command) =
    let cmd = Command("git:branch", "Get the current branch")

    cmd.SetHandler(fun () ->
      use sp = configureServices ()
      let gitCtx = sp.GetRequiredService<GitContext>()
      writeToConsole (gitCtx.Branch()))

    get.Add(cmd)
    ()

type GitContextCommandProvider() =
  interface IDevContextCommandProvider with
    member _.AddGetCommands(get: Command) = GitCommand.addGetCommands get
