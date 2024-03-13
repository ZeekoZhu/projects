module Projects.DevContext.Utils

open System.Text.Json

let toString (x:'a) =
  JsonSerializer.Serialize(x)

let writeToConsole (x:'a) =
  printfn $"%s{toString x}"
