namespace Projects.Blogkit.Controllers

open Microsoft.AspNetCore.Mvc

[<ApiController>]
[<Route("/ping")>]
type PingController() =
  inherit ControllerBase()

  member this.Get() = "pong! --- from blogkit"
