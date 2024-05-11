namespace Projects.DevContext.ContextProviders

open System.Text.RegularExpressions
open FSharpPlus
open FsToolkit.ErrorHandling


[<AllowNullLiteral>]
type GitHubContextConfig() =
  member val Token = "" with get, set

type GitHubProjectOutput =
  { Name: string
    Description: string
    Owner: string
    Repo: string
    WebUrl: string }

module GitHubUtils =
  let private pattern =
    Regex(".*[:/](?<owner>[^\/:]+?)/(?<repo>[^\/:]+?)(?:\.git)?$", RegexOptions.Compiled)

  let getOwnerRepoFromUrl (url: string) =
    Result.protect
      (fun () ->
        let matches = pattern.Match(url)

        if matches.Success then
          matches.Groups["owner"].Value, matches.Groups["repo"].Value

        else
          failwith "Not matched")
      ()

    |> Validation.ofResult
    |> Validation.mapError (fun _ ->
      exn $"Failed to extract owner and repo from url: '{url}', please make sure the url is a GitHub repo url")
