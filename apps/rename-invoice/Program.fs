open System.CommandLine
open System.CommandLine.Builder
open System.CommandLine.Parsing
open RenameInvoice
open Serilog

Log.Logger <-
  LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("invoice-logs.txt")
    .CreateLogger()


let root = RootCommand()


root.Add RenameCommand.cmd
root.Add StatsCommand.cmd

let app = CommandLineBuilder(root).UseDefaults().Build()

[<EntryPoint>]
let main argv = app.Invoke(argv)
