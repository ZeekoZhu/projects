using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Imgur.API.Models;
using MapsterMapper;
// ReSharper disable MemberCanBePrivate.Global

namespace Zeeko.ImgurCli.Service;

public class ConfigFileProvider : ISingletonDependency
{
  public const string ConfigKey = nameof(AppConfig);

  public IMapper ObjectMapper { protected get; init; }

  public static readonly string ConfigDirPath = Path.Join(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "zeeko-imgur-cli");

  public static string ConfigFilePath => Path.Join(ConfigDirPath, "appsettings.json");

  static ConfigFileProvider()
  {
    Directory.CreateDirectory(ConfigDirPath);
    if (!File.Exists(ConfigFilePath))
      File.WriteAllText(ConfigFilePath, "{}", Encoding.UTF8);
  }

  private readonly Lazy<AppConfig> _lazyAppConfig;
  public AppConfig AppConfig => _lazyAppConfig.Value;

  public ConfigFileProvider(IMapper objectMapper)
  {
    ObjectMapper = objectMapper;
    _lazyAppConfig = new Lazy<AppConfig>(LoadConfig);
  }

  private AppConfig LoadConfig()
  {
    // read config file as json
    var configFileContent = File.ReadAllText(ConfigFilePath);
    var config = JsonSerializer.Deserialize<AppConfig>(configFileContent);
    return config ?? new AppConfig();
  }

  public void UpdateConfig(AppConfig config)
  {
    // serialize AppConfig into json dom
    var dom = JsonSerializer.SerializeToNode(config);
    if (config.Token is not null)
    {
      var tokenDom = JsonSerializer.SerializeToNode(ObjectMapper.Map<OAuth2Token, AppAuthToken>(config.Token));
      dom![nameof(Service.AppConfig.Token)] = tokenDom;
    }

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
#pragma warning disable CA1416
        File.SetUnixFileMode(filePath, UnixFileMode.UserRead | UnixFileMode.UserWrite);
#pragma warning restore CA1416
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

public class AppAuthToken : IOAuth2Token
{
  public required string AccessToken { get; init; }
  public required int ExpiresIn { get; init; }
  public required string TokenType { get; init; }
  public required string RefreshToken { get; init; }
  public required int AccountId { get; init; }
  public required string AccountUsername { get; init; }
}
