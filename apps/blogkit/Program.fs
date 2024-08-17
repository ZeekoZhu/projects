namespace Projects.Blogkit

#nowarn "20"

open System
open System.Threading.RateLimiting
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http.Timeouts
open Microsoft.AspNetCore.RateLimiting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Projects.Blogkit.Services

module Program =
  let exitCode = 0

  [<EntryPoint>]
  let main args =

    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddControllers()
    builder.Services.AddSingleton<LocalSlugifier>()
    builder.Services.AddSingleton<AISlugifier>()
    builder.Services.AddSingleton<MetaSlugifier>()

    builder.Services.AddResponseCaching()
    builder.Services.AddOutputCache()

    builder.Services.AddRequestTimeouts(fun options ->
      options.DefaultPolicy <- RequestTimeoutPolicy(Timeout = TimeSpan.FromSeconds(90))
      ())

    builder.Services.AddRateLimiter(fun it ->
      it.AddFixedWindowLimiter(
        "fixed",
        fun policy ->
          policy.Window <- TimeSpan.FromSeconds(73)
          policy.PermitLimit <- 10
          policy.QueueProcessingOrder <- QueueProcessingOrder.OldestFirst
          policy.QueueLimit <- 2
      )
      |> ignore)

    let app = builder.Build()
    app.UseRouting()
    app.UseRateLimiter()
    app.UseResponseCaching()
    app.UseOutputCache()
    app.UseRequestTimeouts()
    app.MapControllers()

    app.Run()

    exitCode
