module Projects.DevContext.Utils


open System.Text.Json
open Microsoft.Extensions.DependencyInjection
open Serilog

let toString (x: 'a) = JsonSerializer.Serialize(x)

let writeToConsole (x: 'a) = printfn $"%s{toString x}"


module DI =
  let addLogger (services: IServiceCollection) =
    services.AddLogging(fun builder -> builder.AddSerilog() |> ignore)
  let addSingleton<'a when 'a: not struct> (services: IServiceCollection) =
    services.AddSingleton<'a>()

  let buildServiceProvider (services: IServiceCollection) =
    services.BuildServiceProvider()
