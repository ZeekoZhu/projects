namespace Projects.Blogkit.Services

open System
open FSharpPlus
open Microsoft.Extensions.Logging
open Microsoft.FSharp.Core
open OpenAI
open OpenAI.Interfaces
open OpenAI.Managers
open OpenAI.ObjectModels.RequestModels
open OpenAI.ObjectModels.ResponseModels


[<AutoOpen>]
module ChatHelper =
  let messages (msgList: ChatMessage list) = IList.ofList msgList
  let fromUser (message: string) = ChatMessage.FromUser message

  /// Completes a chat with the given messages
  /// <param name="configReq">configure the request before sending</param>
  let completeChat (client: IOpenAIService) (model: string) (msgs: ChatMessage list) configReq =
    let request =
      ChatCompletionCreateRequest(Messages = (msgs |> messages), Model = model)

    configReq request
    client.ChatCompletion.CreateCompletion(request)

  let firstChoice (result: ChatCompletionCreateResponse) =
    result.Choices |> Seq.tryHead |> Option.map _.Message.Content

  let parseTagValue tagName input =
    let regex = System.Text.RegularExpressions.Regex($@"<{tagName}>([^<]+)</{tagName}>")
    let matched = regex.Match(input)

    if matched.Success then
      Some matched.Groups[1].Value
    else
      None


type AISlugifier(logger: ILogger<AISlugifier>) =
  let apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
  let apiEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")

  let defaultModel = "gpt-4o-mini"

  let aiModel =
    match Environment.GetEnvironmentVariable("OPENAI_MODEL") with
    | s when String.IsNullOrWhiteSpace s -> defaultModel
    | model -> model

  let openAIClient =
    new OpenAIService(OpenAiOptions(ApiKey = apiKey, BaseDomain = apiEndpoint))

  interface ISlugifier with
    member _.Slugify(input: string) =
      let prompt =
        $"Create a concise English URL slug for the following title: {input}\n\
      you should response in the this format: <slug>the-slug-for-the-input</slug>\n\
      just write your response and nothing else.\n\n\
      Examples: hello, world\n\
      Response: <slug>hello-world</slug>\
      "

      logger.LogDebug("Prompt: {prompt}", prompt)
      let msgs = [ fromUser prompt ]

      task {
        let! resp = completeChat openAIClient aiModel msgs (fun req -> req.MaxTokens <- 150)

        logger.LogDebug("Response: {resp}", resp)

        return
          resp
          |> firstChoice
          |> Option.bind (parseTagValue "slug")
          |> FsToolkit.ErrorHandling.Option.teeNone (fun () -> logger.LogError("Failed to parse slug from response"))
          |> Option.defaultValue ""
      }
