module Projects.Blogkit.Controllers.Slugify

open Giraffe
open Projects.Blogkit.Services

let slugify: HttpHandler =
  fun next ctx ->
    let slugifier = ctx.GetService<ISlugifier>()

    match ctx.TryGetQueryStringValue "t" with
    | Some title ->
      task {
        let! slug = slugifier.Slugify title
        return! text slug next ctx
      }
    | None -> RequestErrors.badRequest (text "Missing 't' parameter") next ctx
