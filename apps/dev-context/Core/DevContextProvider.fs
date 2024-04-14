namespace Projects.DevContext.Core

open System.CommandLine

type ContextCommand =
  | Get of Command
  | Act of Command

type IDevContextCommandProvider =
  abstract member CreateCommands: unit -> ContextCommand list
