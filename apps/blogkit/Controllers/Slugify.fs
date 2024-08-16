module Projects.Blogkit.Controllers.Slugify

open Giraffe
open Microsoft.Extensions.Logging
open Projects.Blogkit.Services

let slugify: HttpHandler =
  fun next ctx ->
    let slugifier = ctx.GetService<MetaSlugifier>() :> ISlugifier
    let logger = ctx.GetLogger("Projects.Blogkit.Controllers.Slugify")

    match ctx.TryGetQueryStringValue "t" with
    | Some title ->
      logger.LogInformation("input: {title}", title)
      task {
        let! slug = slugifier.Slugify title
        logger.LogInformation("result for '{input}': '{slug}'", title, slug)
        return! text slug next ctx
      }
    | None -> RequestErrors.badRequest (text "Missing 't' parameter") next ctx
