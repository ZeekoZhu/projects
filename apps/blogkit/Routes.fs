module Projects.Blogkit.Routes

open Giraffe
open Giraffe.EndpointRouting
open Projects.Blogkit.Controllers

let webApp: Endpoint list =
  [ subRoute "/api/v1" [ route "/slugify" Slugify.slugify ]
    route "/ping" <| text "PONG from blogkit" ]
