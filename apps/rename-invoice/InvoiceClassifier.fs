module RenameInvoice.InvoiceClassifier

open RenameInvoice.RenameInvoice

type InvoiceCategoryRule = { Name: string; Keywords: string list }

let getCategory (categories: InvoiceCategoryRule list) (invoice: InvoiceInfo) =
  let itemNames = invoice.Items |> Seq.map _.Name |> String.concat " "
  let string = $"{invoice.Seller} {itemNames}"

  categories
  |> Seq.tryFind (fun category ->
    category.Keywords |> List.exists (fun keyword -> string.Contains(keyword)))
  |> Option.map _.Name
