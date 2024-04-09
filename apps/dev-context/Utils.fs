module Projects.DevContext.Utils


open System
open System.Text.Encodings.Web
open System.Text.Json
open FsToolkit.ErrorHandling
open Microsoft.Extensions.DependencyInjection
open Serilog

let private jsonOptions =
  JsonSerializerOptions(
    JsonSerializerDefaults.Web,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
  )

let toString (x: 'a) =
  JsonSerializer.Serialize(x, jsonOptions)

let writeToConsole (x: 'a) = printfn $"%s{toString x}"

let getLogger<'a> () = Log.ForContext<'a>()

module DI =
  let addLogger (services: IServiceCollection) =
    services.AddLogging(fun builder -> builder.AddSerilog() |> ignore)

  let addSingleton<'a when 'a: not struct> (services: IServiceCollection) =
    services.AddSingleton<'a>()

  let addSingleton2 (a: Type) (b: Type) (services: IServiceCollection) =
    services.AddSingleton(a, b)

  let buildServiceProvider (services: IServiceCollection) =
    services.BuildServiceProvider()

module Validations =
  let notNone selector message target =
    let value = selector target

    match value with
    | Some v -> Validation.ok v
    | _ -> Validation.error message

  let nonEmptyString selector message target =
    let value = selector target

    if String.IsNullOrWhiteSpace value then
      Validation.error (message value)
    else
      Validation.ok target
