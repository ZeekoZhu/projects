open System.CommandLine
open System.CommandLine.Builder
open System.CommandLine.Parsing
open RenameInvoice

let root = RootCommand()


root.Add RenameCommand.cmd

let app = CommandLineBuilder(root).UseDefaults().Build()

[<EntryPoint>]
let main argv = app.Invoke(argv)
