namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Projects.DevContext
open Projects.DevContext.Core

type IRepoContext =
  abstract member Dir: unit -> string

type RepoContext(logger: ILogger<RepoContext>) =
  interface IRepoContext with
    member _.Dir() =
      // returns working directory
      logger.LogDebug("Working directory: {dir}", Environment.CurrentDirectory)
      Environment.CurrentDirectory

module RepoCommand =
  open Utils

  let addRepoContext (services: IServiceCollection) =
    services.AddSingleton<IRepoContext, RepoContext>()

  let private configureServices () =
    ServiceCollection() |> DI.addLogger |> addRepoContext |> DI.buildServiceProvider

  let commands () =
    let cmd = Command("repo:dir", "Get the current working directory")

    cmd.SetHandler(fun () ->
      use sp = configureServices ()
      let repo = sp.GetService<IRepoContext>()
      writeToConsole (repo.Dir()))

    [ Get cmd ]

type RepoContextCommandProvider() =
  interface IDevContextCommandProvider with
    member this.CreateCommands() = RepoCommand.commands ()
