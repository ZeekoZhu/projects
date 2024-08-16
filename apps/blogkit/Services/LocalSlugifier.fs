namespace Projects.Blogkit.Services

open System.Threading.Tasks
open Slugify

type LocalSlugifier() =
  let slugHelper = SlugHelper()

  interface ISlugifier with
    member _.Slugify(input: string) =
      slugHelper.GenerateSlug input |> Task.FromResult
