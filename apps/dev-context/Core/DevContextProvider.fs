namespace Projects.DevContext.Core

open System.CommandLine

type IDevContextCommandProvider =
  abstract member AddGetCommands: Command -> unit
