module Projects.DevContext.Utils


open System
open System.ComponentModel.DataAnnotations
open System.Text.Encodings.Web
open System.Text.Json
open System.Threading.Tasks
open FsToolkit.ErrorHandling
open Microsoft.Extensions.DependencyInjection
open Microsoft.FSharp.Core
open Serilog
open FSharpPlus

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

module Validator =
  type Validator<'a, 'b, 'e> = 'a -> Validation<'b, 'e>

  let (@) (x: Validator<'a, 'b, 'e>) (y: Validator<'b, 'c, 'e>) = x >> (Validation.bind y)


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

  let toValidationException (x: Validation<'a, string>) =
    x
    |> Result.mapError (fun errs ->
      let message = String.Join(Environment.NewLine, errs)
      ValidationException(message) :> exn)

module Result =
  let inline require (predicate: 'a -> bool) (error: 'e) (value: 'a) =
    if predicate value then Ok value else Error error

module TaskResult =
  let inline liftApply (x: TaskResult<'a, 'e>) (f: 'a -> 'b) = TaskResult.map f x

  let inline protect (f: 'a -> 'b Task) (x: 'a) =
    try
      f x |> TaskResult.ofTask
    with ex ->
      Task.FromResult(Error ex)

  let inline bindResult f = Result.bind f |> Task.map

  let inline applyF (x: TaskResult<'a, 'e>) (f: TaskResult<'a -> 'b, 'e>) = TaskResult.map2 id f x

  let inline applyResultF (x: Result<'a, 'e>) (f: TaskResult<'a -> 'b, 'e>) =
    f |> Task.map (fun f -> Result.apply f x)
