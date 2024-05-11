module RenameInvoice.StatsCommand

open System
open System.CommandLine
open System.Globalization
open System.IO
open RenameInvoice.Stats
open Spectre.Console

let cmd = Command("stats", "Show statistics about the invoices")

(*
stats -d ./invoice-dir
*)

let dirOption =
  Option<DirectoryInfo>([| "-d"; "--dir" |], "The directory where the invoices are stored")

cmd.Add dirOption

let inline formatAmount< ^a when ^a: (member ToString: string * IFormatProvider -> string)> (amount: ^a) =
  amount.ToString("C", CultureInfo.CreateSpecificCulture("zh-CN"))

let showCategorySummary (categoryStats: InvoiceCategoryStats list) =
  let table = Table()
  table.AddColumns("Category", "Count", "Amount") |> ignore
  table.Title <- TableTitle("[green]Category Summary[/]")

  categoryStats
  |> List.iter (fun stats ->
    table.AddRow(stats.Category, stats.Count.ToString(), stats.Sum |> formatAmount)
    |> ignore)

  table.AddRow(
    "Total",
    (categoryStats |> List.sumBy (_.Count)).ToString(),
    categoryStats |> List.sumBy (_.Sum) |> formatAmount
  )
  |> ignore

  AnsiConsole.Write table
  ()

let showCategoryDetails (category: InvoiceCategoryStats) =
  let table = Table(Border = TableBorder.None)
  table.Title <- TableTitle(category.Category, Style(Color.Yellow))

  table.AddColumns("Seller", "Date", "Amount") |> ignore

  category.Items
  |> List.iter (fun item ->
    table.AddRow(item.Seller, item.Date.ToString("yyyy-MM-dd"), item.Price |> formatAmount)
    |> ignore)

  AnsiConsole.Write table

cmd.SetHandler(
  (fun dir ->
    let results = getStatsForOutputDir dir |> List.ofSeq
    showCategorySummary results
    results |> List.iter showCategoryDetails
    ()),
  dirOption
)
