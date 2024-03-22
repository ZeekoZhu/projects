open System.CommandLine
open System.CommandLine.Builder
open System.CommandLine.Parsing
open Projects.DevContext
open Projects.DevContext.ContextProviders
open Projects.DevContext.Core
open Serilog
open Serilog.Events

Log.Logger <-
  LoggerConfiguration()
    .ReadFrom.Configuration(AppConfig.configuration ())
    .WriteTo.Console(
      outputTemplate =
        "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}",
      standardErrorFromLevel = LogEventLevel.Verbose
    )
    .CreateLogger()

let rootCommand = RootCommand(Name = "dev-ctx")

let getCommand = Command("get", "Get the current development context")
rootCommand.AddCommand(getCommand)

let commandProviders: IDevContextCommandProvider list =
  [ RepoContextCommandProvider()
    GitContextCommandProvider()
    JiraContextCommandProvider() ]

commandProviders
|> List.iter (fun provider -> provider.AddGetCommands getCommand)


[<EntryPoint>]
let main argv =
  let builder = CommandLineBuilder(rootCommand).UseDefaults()
  builder.Build().Invoke(argv)
