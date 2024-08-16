namespace Projects.Blogkit.Services

open System.Text.RegularExpressions
open Microsoft.Extensions.Logging

module InputClassifier =
  let private cjkRegex = Regex(@"\p{IsCJKUnifiedIdeographs}")
  let containsCJK (input: string) = cjkRegex.IsMatch input

type MetaSlugifier(local: LocalSlugifier, ai: AISlugifier, logger: ILogger<MetaSlugifier>) =
  let local = local :> ISlugifier
  let ai = ai :> ISlugifier

  interface ISlugifier with
    member _.Slugify(input: string) =
      match input with
      | _ when InputClassifier.containsCJK input ->
        logger.LogInformation("input contains CJK characters, using AI slugifier")
        ai.Slugify input
      | _ ->
        logger.LogInformation("input does not contain CJK characters, using local slugifier")
        local.Slugify input
