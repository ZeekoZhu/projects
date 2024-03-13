namespace Projects.DevContext.ContextProviders

open System
open System.CommandLine
open Projects.DevContext
open Projects.DevContext.Core

type RepoContext() =
  member _.Dir() =
    // returns working directory
    Environment.CurrentDirectory

module RepoCommand =
  let addGetCommands (get: Command) =
    let cmd = Command("repo:dir", "Get the current working directory")

    cmd.SetHandler(fun () ->
      let repo = RepoContext()
      Utils.writeToConsole (repo.Dir()))

    get.Add(cmd)
    ()

type RepoContextCommandProvider() =
  interface IDevContextCommandProvider with
    member this.AddGetCommands(get) = RepoCommand.addGetCommands get
