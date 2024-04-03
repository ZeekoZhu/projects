module Projects.DevContext.Core.Model

open Projects.DevContext


type Username = string
/// password or personal access token
type Secret = string

module GitLabContextConfig =
  type GitLabContextConfig() =
    member val public Host: string = "https://gitlab.com" with get, set
    member val public Token: Secret = "" with get, set


  let readConfig () =
    AppConfig.section<GitLabContextConfig> "GitLab"
