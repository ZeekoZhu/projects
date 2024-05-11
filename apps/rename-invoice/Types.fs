module RenameInvoice.Types

open System
open System.IO
open System.Text.Encodings.Web
open System.Text.Json
open FSharpPlus
open FsToolkit.ErrorHandling
open Serilog

type InvoiceDetailItem = { Name: string }

type InvoiceInfo =
  { Price: float
    Date: DateOnly
    Seller: string
    InvoiceNumber: string
    Items: InvoiceDetailItem list
    TextContent: string }

let configJsonOptions =
  JsonSerializerOptions(
    JsonSerializerDefaults.Web,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true
  )

let fromJson<'T> (json: string) =
  Json.fromJson<'T> configJsonOptions json

let toJson<'T> (value: 'T) = Json.toJson<'T> configJsonOptions value

let readInvoiceInfo (file: FileInfo) =
  let content = File.ReadAllText file.FullName

  Result.protect fromJson<InvoiceInfo> content
  |> Result.teeError (fun e ->
    Log
      .ForContext<InvoiceInfo>()
      .Error(e, "Failed to parse invoice info from {file}", file.FullName))

let writeInvoiceInfo (file: FileInfo) (info: InvoiceInfo) =
  let content = toJson info
  File.WriteAllText(file.FullName, content)
