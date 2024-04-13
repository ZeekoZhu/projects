module Projects.DevContext.Utils


open System
open System.Text.Encodings.Web
open System.Text.Json
open System.Threading.Tasks
open FsToolkit.ErrorHandling
open Microsoft.Extensions.DependencyInjection
open Serilog

let private jsonOptions =
  JsonSerializerOptions(JsonSerializerDefaults.Web, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping)

let toString (x: 'a) =
  JsonSerializer.Serialize(x, jsonOptions)

let writeToConsole (x: 'a) = printfn $"%s{toString x}"

let getLogger<'a> () = Log.ForContext<'a>()

module DI =
  let addLogger (services: IServiceCollection) =
    services.AddLogging(fun builder -> builder.AddSerilog() |> ignore)

  let addSingleton<'a when 'a: not struct> (services: IServiceCollection) = services.AddSingleton<'a>()

  let addSingleton2 (a: Type) (b: Type) (services: IServiceCollection) = services.AddSingleton(a, b)

  let buildServiceProvider (services: IServiceCollection) = services.BuildServiceProvider()

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

module TaskResult =
  let inline liftApply (x: TaskResult<'a, 'e>) (f: 'a -> 'b)  = TaskResult.map f x
  let inline protect (f: 'a -> 'b Task) (x: 'a) =
    try
      f x |> TaskResult.ofTask
    with ex ->
      Task.FromResult(Error ex)

  let inline applyF (x: TaskResult<'a, 'e>) (f: TaskResult<'a -> 'b, 'e>) = TaskResult.map2 id f x

  let inline applyResultF (x: Result<'a, 'e>) (f: TaskResult<'a -> 'b, 'e>) =
    f |> Task.map (fun f -> Result.apply f x)
