module RenameInvoice.RenameCommand

open System.CommandLine
open System
open System.IO
open FSharpPlus
open FsToolkit.ErrorHandling
open RenameInvoice
open RenameInvoice.InvoiceClassifier
open Spectre.Console
open FSharp.Control
open Tomlyn
open Tomlyn.Model

let cmd = Command("rename", "rename invoice files")

(*
rename -c ./config.toml
*)
let configOption = Option<FileInfo>([| "-c"; "--config" |], "config file path")

(* toml config
invoiceInbox = "./inbox"
outDir = "./out"
[[categories]]
name = "咖啡"
keywords = ["咖啡", "星巴克", "提姆"]
[[categories]]
name = "电影"
keywords = ["电影", "影城"]
*)

type RenameConfig =
  {
    InvoiceInbox: DirectoryInfo
    OutDir: DirectoryInfo
    /// 咖啡，电影
    Categories: InvoiceCategoryRule list
  }

cmd.Add(configOption)


let renameFile (config: RenameConfig) (file: FileInfo) =
  let info = extractInvoiceInfo file


  let outputDir =
    info
    |> Result.map (fun input ->
      let category =
        InvoiceClassifier.getCategory config.Categories input.Info
        |> Option.defaultValue "other"

      Path.Join(config.OutDir.FullName, category))

  Result.zip info outputDir
  |> Result.map (uncurry renameInvoice)
  |> Result.map (konst (file, info))

let renameFileAsync (config: RenameConfig) (file: FileInfo) =
  async { return renameFile config file }

let renameCommandHandler (config: RenameConfig) =

  AnsiConsole
    .Progress()
    .Start(fun ctx ->
      let pdfFiles =
        config.InvoiceInbox.GetFiles("*.pdf", SearchOption.AllDirectories)

      let task =
        ctx.AddTask(
          $"Renaming {pdfFiles.Length} files",
          maxValue = pdfFiles.Length
        )

      let handleRenameCompleted () res =
        task.Increment(1)

        match res with
        | Ok(file: FileInfo, _) -> File.Delete(file.FullName)
        | Error(e: RenameInvoiceFailedReason) ->
          AnsiConsole.MarkupLine($"[red]Failed to rename {e.File.Name}[/]")

      let asyncTasks =
        pdfFiles
        |> Seq.map (
          renameFileAsync config >> Async.map (handleRenameCompleted ())
        )

      Async.Parallel(asyncTasks, 5) |> Async.RunSynchronously)
  |> ignore

let tryReadString (model: TomlTable) key =
  let success, value = model.TryGetValue key
  if success then Some(value :?> string) else None

let readStringList (model: TomlTable) key =
  let success, value = model.TryGetValue key

  if success then
    (value :?> obj seq |> Seq.cast |> List.ofSeq)
    |> List.filter (String.IsNullOrWhiteSpace >> not)
    |> Validation.ok
  else
    Validation.ok []

let readDirInfo (model: TomlTable) (key: string) =
  let path = tryReadString model key

  path
  |> Option.filter Path.Exists
  |> Option.map DirectoryInfo
  |> Option.toResult
  |> Result.mapError (fun _ -> $"directory for '{key}' not exists")
  |> Validation.ofResult

let readCategoryRule (model: TomlTable) =
  let name =
    tryReadString model "name"
    |> Option.toResultWith "category name can not be empty"
    |> Validation.ofResult

  let keywords = readStringList model "keywords"
  Validation.map2 (fun n k -> { Name = n; Keywords = k }) name keywords

let readCategoryRules (model: TomlTable) =
  let success, categories = model.TryGetValue "categories"

  if success then
    categories :?> TomlTableArray
    |> Seq.map readCategoryRule
    |> Seq.map (Validation.mapError (fun e -> $"category rule error: {e}"))
    |> Seq.fold (Validation.map2 (fun a b -> a @ [ b ])) (Validation.ok [])
  else
    Validation.ok []




let readConfig (configFile: FileInfo) =
  // ensure file exists
  if not configFile.Exists then
    Validation.error "config file not exists"
  else
    let content = File.ReadAllText(configFile.FullName)
    let model = Toml.ToModel(content)

    validation {
      let! inbox = readDirInfo model "invoiceInbox"
      let! outDir = readDirInfo model "outDir"
      let! categories = readCategoryRules model

      return
        { InvoiceInbox = inbox
          OutDir = outDir
          Categories = categories }
    }

cmd.SetHandler(fun (ctx: Invocation.InvocationContext) ->
  let configFile =
    ctx.ParseResult.GetValueForOption configOption
    |> Option.ofObj
    |> Option.defaultWith (fun () -> FileInfo("./invoice.config.toml"))

  let config = readConfig configFile

  match config with
  | Validation.Ok config -> renameCommandHandler config
  | Validation.Error errors ->
    errors |> Seq.iter (fun e -> AnsiConsole.MarkupLine($"[red]{e}[/]")))
