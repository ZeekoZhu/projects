namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open LibGit2Sharp
open Microsoft.Extensions.DependencyInjection
open Projects.DevContext
open Projects.DevContext.Core
open FSharpPlus
open FsToolkit.ErrorHandling
open Microsoft.Extensions.Logging


type BranchInfo =
  { FriendlyName: string
    FullName: string }

type CommitInfo =
  { SHA: string
    Message: string
    CommitTime: DateTimeOffset }

type IGitContext =
  abstract member Branch: unit -> BranchInfo option
  abstract member RemoteRepositoryUrl: unit -> string option
  abstract member Commits: unit -> CommitInfo list
  abstract member MergeTargetBranch: unit -> BranchInfo option

type GitContext(repoCtx: IRepoContext, logger: ILogger<GitContext>) =
  let currentGitRepo () =
    Repository.Discover(repoCtx.Dir())
    |> Option.ofObj
    |> Option.teeSome (fun dir -> logger.LogDebug("Repository found at {dir}", dir))
    |> Option.teeNone (fun () -> logger.LogWarning("No git repository found"))

  let tryFindCurrentBranch (repo: Repository) =
    repo.Branches
    |> Seq.tryFind (_.IsCurrentRepositoryHead)
    |> Option.teeSome (fun b -> logger.LogDebug("Current branch: {branch}", b.CanonicalName))
    |> Option.teeNone (fun () -> logger.LogWarning("No current branch found"))

  /// find the default merge target branch
  /// todo: make the default branch configurable
  let tryFindMergeTargetBranch (repo: Repository) =
    repo.Branches
    |> Seq.tryFind (fun b ->
      b.CanonicalName.Equals("refs/heads/main", StringComparison.InvariantCultureIgnoreCase)
      || b.CanonicalName.Equals("refs/heads/master", StringComparison.InvariantCultureIgnoreCase))
    |> Option.teeSome (fun b -> logger.LogDebug("Merge target branch: {branch}", b.CanonicalName))

  let defaultBranch (repo: Repository) =
    tryFindMergeTargetBranch repo
    |> Option.defaultWith (fun () -> failwith "Unable to find default branch")

  let commitsMissingInDefault (repo: Repository) (branch: Branch) =
    let defaultBranch = defaultBranch repo

    if defaultBranch = branch then
      failwith "Only feature branch workflow is supported at the moment."
    else
      let mergeTargetRef = defaultBranch.Tip
      let mergeBase = repo.ObjectDatabase.FindMergeBase(branch.Tip, mergeTargetRef)
      branch.Commits |> Seq.takeWhile (fun c -> c <> mergeBase) |> Seq.truncate 50

  let currentBranchCommits () =
    monad {
      let! repoDir = currentGitRepo ()
      use repo = new Repository(repoDir)
      let! currentBranch = tryFindCurrentBranch repo

      commitsMissingInDefault repo currentBranch
      |> Seq.map (fun c ->
        { SHA = c.Sha[0..7]
          Message = c.Message
          CommitTime = c.Committer.When })
      |> Seq.toList
    }
    |> Option.defaultValue []


  interface IGitContext with
    member _.Branch() =
      monad {
        let! repoDir = currentGitRepo ()
        use repo = new Repository(repoDir)

        let! currentBranch = repo.Branches |> Seq.tryFind (_.IsCurrentRepositoryHead)

        { FriendlyName = currentBranch.FriendlyName
          FullName = currentBranch.CanonicalName }
      }

    member this.RemoteRepositoryUrl() =
      monad {
        let! repoDir = Repository.Discover(repoCtx.Dir()) |> Option.ofObj
        logger.LogDebug("Repository found at {repoDir}", repoDir)
        use repo = new Repository(repoDir)
        return! repo.Network.Remotes |> Seq.tryHead |> Option.map (_.Url)
      }

    member this.Commits() = currentBranchCommits ()

    member this.MergeTargetBranch() =
      monad {
        let! repoDir = currentGitRepo ()
        use repo = new Repository(repoDir)
        let! branch = tryFindMergeTargetBranch repo

        return
          { FriendlyName = branch.FriendlyName
            FullName = branch.CanonicalName }
      }


module GitCommand =
  open Utils

  let addGitContext (services: IServiceCollection) =
    services.AddSingleton<IGitContext, GitContext>()

  let private configureServices () =
    ServiceCollection()
    |> addGitContext
    |> DI.addSingleton2 typeof<IRepoContext> typeof<RepoContext>
    |> DI.addLogger
    |> DI.buildServiceProvider

  let commands () =
    let branch = Command("git:branch", "Get the current branch")

    branch.SetHandler(fun () ->
      use sp = configureServices ()
      let gitCtx = sp.GetRequiredService<IGitContext>()
      writeToConsole (gitCtx.Branch()))

    let commits =
      Command("git:commits", "List commits to be merged on the current branch")

    commits.SetHandler(fun () ->
      use sp = configureServices ()
      let gitCtx = sp.GetRequiredService<IGitContext>()
      writeToConsole (gitCtx.Commits()))

    [ Get branch; Get commits ]

type GitContextCommandProvider() =
  interface IDevContextCommandProvider with
    member _.CreateCommands() = GitCommand.commands ()
