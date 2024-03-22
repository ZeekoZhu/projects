module Projects.DevContext.AppConfig

open System
open System.IO
open Microsoft.Extensions.Configuration

let templateConfigJson =
  """
{
  "Serilog": {
   "MinimumLevel": "Information"
  },
  "Jira": {
    "IssueKeyPrefix": "EE",
  }
}
"""

let configDir =
  Path.Join(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "dev-ctx"
  )

let ensureConfigDir () =
  if not (Directory.Exists(configDir)) then
    Directory.CreateDirectory(configDir) |> ignore
  let appsettingsFile = Path.Join(configDir, "appsettings.json")
  if not (File.Exists(appsettingsFile)) then
    File.WriteAllText(appsettingsFile, templateConfigJson)

let setupConfiguration () =
  ensureConfigDir ()

  let builder =
    ConfigurationBuilder()
      .SetBasePath(configDir)
      .AddJsonFile("appsettings.json", true, false)

  builder.Build()


let private appConfigLazy = Lazy<IConfigurationRoot>(setupConfiguration)

let configuration () = appConfigLazy.Value


let section<'a> (name: string) =
  configuration().GetSection(name).Get<'a>()
