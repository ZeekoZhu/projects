module RenameInvoice.RenameInvoice

open System
open System.IO
open System.Text
open AlibabaCloud.SDK.Ocr_api20210707.Models
open CliWrap
open FSharp.Data
open FsToolkit.ErrorHandling
open RenameInvoice.Json
open RenameInvoice.Types
open Spectre.Console


type RenameInvoiceFailedReason =
  { File: FileInfo
    Info: InvoiceInfo option
    Reason: exn }

type RenameInvoiceInput = { File: FileInfo; Info: InvoiceInfo }

type RenameInvoiceReturn = Result<RenameInvoiceInput, RenameInvoiceFailedReason>

/// <summary>
/// Use AK&SK to initialize account Client
/// </summary>
/// <param name="accessKeyId"></param>
/// <param name="accessKeySecret"></param>
/// <returns>Client</returns>
/// <exception cref="System.Exception"></exception>
let CreateClient (accessKeyId: string) (accessKeySecret: string) =
  let config =
    AlibabaCloud.OpenApiClient.Models.Config(
      AccessKeyId = accessKeyId,
      AccessKeySecret = accessKeySecret,
      Endpoint = "ocr-api.cn-hangzhou.aliyuncs.com"
    )

  AlibabaCloud.SDK.Ocr_api20210707.Client(config)

type ParsedInvoiceData = JsonProvider<"./example.json">

let client =
  CreateClient
    (Environment.GetEnvironmentVariable "ALIBABA_CLOUD_ACCESS_KEY_ID")
    (Environment.GetEnvironmentVariable "ALIBABA_CLOUD_ACCESS_KEY_SECRET")

let convertToText (file: FileInfo) =
  let sb = StringBuilder()

  Console.Error.WriteLine $"converting pdf to text: {file.FullName}"

  let cmd =
    Cli
      .Wrap("pdftotext")
      .WithArguments([ "-layout"; file.FullName; "-" ])
      .WithStandardOutputPipe(PipeTarget.ToStringBuilder(sb))
      .WithStandardErrorPipe(
        PipeTarget.ToDelegate(fun s ->
          Console.Error.WriteLine $"pdftotext 2> {s}")
      )

  let result =
    cmd.ExecuteAsync().Task
    |> AsyncResult.ofTask
    |> AsyncResult.map (fun _ -> sb.ToString())
    |> AsyncResult.teeError AnsiConsole.WriteException
    |> Async.RunSynchronously
    |> Option.ofResult
    |> Option.defaultWith sb.ToString

  result

let extractInvoiceInfo (file: FileInfo) =
  try
    use fileStream = file.OpenRead()

    let resp =
      client.RecognizeInvoice(RecognizeInvoiceRequest(Body = fileStream))

    let data = ParsedInvoiceData.Parse(resp.Body.Data)

    let info =
      { Price = data.Data.TotalAmount |> float
        Date = DateOnly.FromDateTime data.Data.InvoiceDate
        Seller = data.Data.SellerName
        InvoiceNumber = data.Data.InvoiceNumber.JsonValue.AsString()
        TextContent = convertToText file
        Items =
          data.Data.InvoiceDetails
          |> Seq.map (fun x -> { Name = x.ItemName })
          |> List.ofSeq }

    Result.Ok { File = file; Info = info }
  with exn ->
    Result.Error
      { File = file
        Info = None
        Reason = exn }


let createSidecarFile (file: string) (invoiceInfo: InvoiceInfo) =
  // create a json file alongside the invoice file, named as the invoice file with .json extension
  let jsonFile = Path.ChangeExtension(file, ".json")
  writeInvoiceInfo (FileInfo(jsonFile)) invoiceInfo

let renameInvoice (input: RenameInvoiceInput) outputDir =
  let info = input.Info
  let file = input.File
  let dateStr = info.Date.ToString("yyyy-MM-dd")

  let fileName =
    $"{dateStr}_{info.Seller}_{info.Price}_{info.InvoiceNumber}.pdf"
  // ensure output dir exists
  if not <| Directory.Exists outputDir then
    Directory.CreateDirectory outputDir |> ignore

  let outputFilePath = Path.Join(outputDir, fileName)

  if Path.Exists outputFilePath then
    AnsiConsole.WriteLine $"[red]File already exists: {outputFilePath}[/]"
  else
    File.Copy(file.FullName, outputFilePath, false)
    createSidecarFile (Path.Join(outputDir, fileName)) info
