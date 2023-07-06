using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Imgur.API.Models;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli.Service;

public class ConfigFileProvider : ISingletonDependency
{
  public const string ConfigKey = nameof(AppConfig);

  public static readonly string ConfigDirPath = Path.Join(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "zeeko-imgur-cli");

  public string ConfigFilePath => Path.Join(ConfigDirPath, "appsettings.json");

  static ConfigFileProvider()
  {
    Directory.CreateDirectory(ConfigDirPath);
  }

  public AppConfig AppConfig => AppConfigOptions.Value;
  public required IOptions<AppConfig> AppConfigOptions { get; init; }

  public void UpdateConfig(AppConfig config)
  {
    // serialize AppConfig into json dom
    var dom = JsonSerializer.SerializeToNode(config);
    // read config file as json dom
    var configFileContent = File.ReadAllText(ConfigFilePath);
    var configDom = JsonNode.Parse(configFileContent);
    // update the AppConfig section
    if (configDom != null)
    {
      configDom[ConfigKey] = dom;
      var content =
        configDom.ToJsonString(new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
      File.WriteAllText(ConfigFilePath, content, Encoding.UTF8);
      // change file permission to current user only
      RestrictConfigFileAccess();
    }
    else
    {
      // create a new config file
      File.WriteAllText(ConfigFilePath, "{}", Encoding.UTF8);
    }
  }

  private void RestrictConfigFileAccess()
  {
    var filePath = ConfigFilePath;
    switch (Environment.OSVersion.Platform)
    {
      case PlatformID.Unix:
      case PlatformID.MacOSX:
        File.SetUnixFileMode(filePath, UnixFileMode.UserRead | UnixFileMode.UserWrite);
        break;
    }
  }
}

public record ClientInfo(string ClientId, string ClientSecret);

public record AppConfig
{
  public OAuth2Token? Token { get; set; }
  public ClientInfo? ClientInfo { get; set; }
}
