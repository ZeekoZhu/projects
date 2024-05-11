module RenameInvoice.Stats

open System.IO
open RenameInvoice.Types

(*
the output folder structure
- output
---- category1
------ invoice1.json
------ invoice2.json
---- category2
------ invoice3.json
------ invoice4.json
*)


type InvoiceCategoryStats =
  { Category: string
    Count: int
    Sum: float
    Items: InvoiceInfo list }

type ReadCategoryResult = Result<string * InvoiceInfo list, exn>

let readCategory (dir: DirectoryInfo) =
  let categoryName = dir.Name
  let jsonFiles = dir.GetFiles "*.json"

  let readJsonResults =
    jsonFiles
    |> Array.map readInvoiceInfo

  let invoices =
    readJsonResults
    |> Seq.choose Result.toOption
    |> Seq.toList

  categoryName, invoices

let getStatsForCategory (category: string) (invoices: InvoiceInfo list) =
  let count = invoices.Length
  let sum = invoices |> List.sumBy (_.Price)
  { Category = category; Count = count; Sum = sum; Items = invoices }

let getStatsForOutputDir (outputDir: DirectoryInfo) =
  outputDir.GetDirectories()
  |> Seq.map readCategory
  |> Seq.map (fun (category, invoices) -> getStatsForCategory category invoices)
