open System
open System.CommandLine
open System.CommandLine.Invocation
open System.IO
open System.Text.Encodings.Web
open System.Text.Json
open System.Threading.Tasks
open AlibabaCloud.SDK.Ocr_api20210707.Models
open FSharp.Data

type InvoiceDetailItem = { Name: string }

type InvoiceInfo =
  { Price: float
    Date: DateOnly
    Seller: string
    InvoiceNumber: string
    Items: InvoiceDetailItem list }

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


let extractInvoiceInfo (file: string) =
  let resp =
    client.RecognizeInvoice(RecognizeInvoiceRequest(Body = File.OpenRead(file)))

  let data = ParsedInvoiceData.Parse(resp.Body.Data)

  { Price = data.Data.TotalAmount |> float
    Date = DateOnly.FromDateTime data.Data.InvoiceDate
    Seller = data.Data.SellerName
    InvoiceNumber = data.Data.InvoiceNumber.JsonValue.AsString()
    Items =
      data.Data.InvoiceDetails
      |> Seq.map (fun x -> { Name = x.ItemName })
      |> List.ofSeq }

let jsonOptions =
  JsonSerializerOptions(
    JsonSerializerDefaults.Web,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true
  )

let createSidecarFile (file: string) (invoiceInfo: InvoiceInfo) =
  // create a json file alongside the invoice file, named as the invoice file with .json extension
  let jsonFile = Path.ChangeExtension(file, ".json")
  let json = JsonSerializer.Serialize(invoiceInfo, jsonOptions)
  File.WriteAllText(jsonFile, json)



let root = RootCommand()

let fileOption =
  Option<string>(
    [| "-f"; "--file" |],
    "The invoice file to process",
    IsRequired = true
  )

let outputDirOption =
  Option<string>(
    [| "-o"; "--output-dir" |],
    "The output directory",
    IsRequired = true
  )

root.AddOption(fileOption)
root.AddOption(outputDirOption)

root.SetHandler(fun (ctx: InvocationContext) ->
  let file = ctx.ParseResult.GetValueForOption(fileOption)
  let info = extractInvoiceInfo file
  printfn $"%A{info}"
  // file name pattern yyyy-mm-dd_<seller>_<price>.pdf
  let dateStr = info.Date.ToString("yyyy-MM-dd")

  let fileName =
    $"{dateStr}_{info.Seller}_{info.Price}_{info.InvoiceNumber}.pdf"

  let outputDir = ctx.ParseResult.GetValueForOption(outputDirOption)
  let outputPath = Path.Combine(outputDir, fileName)
  File.Copy(file, outputPath)
  createSidecarFile (Path.Join(outputDir, fileName)) info
  Task.CompletedTask)


[<EntryPoint>]
let main argv = root.Invoke(argv)
