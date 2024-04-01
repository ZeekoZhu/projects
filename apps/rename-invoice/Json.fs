module RenameInvoice.Json

open System.Text.Json

let fromJson<'T> (options: JsonSerializerOptions) (json: string) =
  JsonSerializer.Deserialize<'T>(json, options)

let toJson<'T> (options: JsonSerializerOptions) (value: 'T) =
  JsonSerializer.Serialize(value, options)
