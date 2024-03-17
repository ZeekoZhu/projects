namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Projects.DevContext
open Projects.DevContext.Core

type RepoContext(logger: ILogger<RepoContext>) =
  member _.Dir() =
    // returns working directory
    logger.LogDebug("Working directory: {dir}", Environment.CurrentDirectory)
    Environment.CurrentDirectory

module RepoCommand =
  open Utils

  let configureServices () =
    ServiceCollection()
    |> DI.addLogger
    |> DI.addSingleton<RepoContext>
    |> DI.buildServiceProvider

  let addGetCommands (get: Command) =
    let cmd = Command("repo:dir", "Get the current working directory")

    cmd.SetHandler(fun () ->
      use sp = configureServices ()
      let repo = sp.GetService<RepoContext>()
      writeToConsole (repo.Dir()))

    get.Add(cmd)
    ()

type RepoContextCommandProvider() =
  interface IDevContextCommandProvider with
    member this.AddGetCommands(get) = RepoCommand.addGetCommands get
