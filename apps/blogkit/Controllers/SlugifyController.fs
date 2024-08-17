namespace Projects.Blogkit.Controllers

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Http.HttpResults
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.OutputCaching
open Microsoft.AspNetCore.RateLimiting
open Microsoft.Extensions.Logging
open Projects.Blogkit
open Projects.Blogkit.Services
open AspNetCoreInterop

[<ApiController>]
[<Route("/api/v1/[controller]")>]
type SlugifyController(slugifier: MetaSlugifier, logger: ILogger<SlugifyController>) =
  inherit ControllerBase()
  let slugifier = slugifier :> ISlugifier

  [<HttpGet>]
  [<ResponseCache(VaryByQueryKeys = [| "t" |], Duration = 60 * 60 * 24 * 365, Location = ResponseCacheLocation.Any)>]
  [<OutputCache(VaryByQueryKeys = [| "t" |])>]
  [<EnableRateLimiting("fixed")>]
  member this.Get([<FromQuery(Name = "t")>] title: string) : Task<Results<Ok<string>, BadRequest<string>>> =
    task {
      match title with
      | title when String.IsNullOrWhiteSpace title -> return ~~(TypedResults.BadRequest("Missing 't' parameter"))
      | title ->
        logger.LogInformation("input: {title}", title)
        let! slug = slugifier.Slugify title
        logger.LogInformation("result for '{input}': '{slug}'", title, slug)
        return ~~(TypedResults.Ok slug)
    }
