namespace Projects.Blogkit

#nowarn "20"

open Giraffe.EndpointRouting
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Projects.Blogkit.Services

module Program =
  open Giraffe
  let exitCode = 0

  [<EntryPoint>]
  let main args =

    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddControllers()
    builder.Services.AddGiraffe()
    builder.Services.AddSingleton<LocalSlugifier>()
    builder.Services.AddSingleton<AISlugifier>()
    builder.Services.AddSingleton<MetaSlugifier>()

    let app = builder.Build()

    app.UseAuthorization()
    app.UseRouting()
    app.UseEndpoints(fun e -> e.MapGiraffeEndpoints Routes.webApp)

    app.Run()

    exitCode
