open System.CommandLine
open System.CommandLine.Builder
open System.CommandLine.Parsing
open Projects.DevContext.ContextProviders
open Projects.DevContext.Core

let rootCommand = RootCommand("dev-ctx")

let getCommand = Command("get", "Get the current development context")
rootCommand.AddCommand(getCommand)

let commandProviders: IDevContextCommandProvider list = [
    RepoContextCommandProvider()
]

commandProviders
|> List.iter (fun provider -> provider.AddGetCommands getCommand)

[<EntryPoint>]
let main argv =
  let builder = CommandLineBuilder(rootCommand).UseDefaults()
  builder.Build().Invoke(argv)
