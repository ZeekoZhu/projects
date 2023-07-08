using System.Text;
using System.Text.Json;
using Imgur.API.Models;
using System.IO.Abstractions;
using System.Text.Json.Serialization;

// ReSharper disable MemberCanBePrivate.Global

namespace Zeeko.ImgurCli.Service;

public class ConfigFileProvider : ISingletonDependency
{
  private IFilePermissionProvider _filePermissionProvider;
  private readonly IFileSystem _fs; // Add this line

  public static readonly string ConfigDirPath = Path.Join(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "zeeko-imgur-cli");

  public static string ConfigFilePath => Path.Join(ConfigDirPath, "appsettings.json");

  private readonly Lazy<AppConfig> _lazyAppConfig;
  public AppConfig AppConfig => _lazyAppConfig.Value;

  public ConfigFileProvider(IFileSystem fs, IFilePermissionProvider filePermissionProvider)
  {
    _fs = fs;
    _filePermissionProvider = filePermissionProvider;
    _lazyAppConfig = new Lazy<AppConfig>(LoadConfig);
    fs.Directory.CreateDirectory(ConfigDirPath);
    if (fs.File.Exists(ConfigFilePath))
    {
      return;
    }

    fs.File.WriteAllText(ConfigFilePath, "{}", Encoding.UTF8);
    _filePermissionProvider.RestrictFilePermissions(ConfigFilePath);
  }

  private AppConfig LoadConfig()
  {
    // read config file as json
    var configFileContent = _fs.File.ReadAllText(ConfigFilePath);
    var config = JsonSerializer.Deserialize<AppConfig>(configFileContent);
    return config ?? new AppConfig();
  }

  public void UpdateConfig(AppConfig config)
  {
    // write config file as json
    var json = JsonSerializer.Serialize(
      config,
      new JsonSerializerOptions(JsonSerializerDefaults.Web) { WriteIndented = true });
    _fs.File.WriteAllText(ConfigFilePath, json, Encoding.UTF8);
  }
}

public record ClientInfo
{
  [JsonConstructor]
  public ClientInfo(string ClientId, string ClientSecret)
  {
    this.ClientId = ClientId;
    this.ClientSecret = ClientSecret;
  }

  public string ClientId { get; init; }
  public string ClientSecret { get; init; }
}

public record AppConfig
{
  public OAuth2Token? Token { get; set; }
  public ClientInfo? ClientInfo { get; set; }
  public AppSettings Settings { get; set; } = new();
}

/// <summary>
/// </summary>
public class AppSettings
{
  /// <summary>The default album to upload to.</summary>
  public string? DefaultAlbum { get; init; }
}
