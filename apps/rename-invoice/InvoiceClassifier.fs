module RenameInvoice.InvoiceClassifier

open RenameInvoice.Types

type InvoiceCategoryRule = { Name: string; Keywords: string list }

let getCategory (categories: InvoiceCategoryRule list) (invoice: InvoiceInfo) =
  let string = invoice.TextContent

  categories
  |> Seq.tryFind (fun category ->
    category.Keywords |> List.exists string.Contains)
  |> Option.map _.Name
