using System.Text;
using System.Text.Json;
using Imgur.API.Models;
using System.IO.Abstractions;
using System.Text.Json.Serialization;

// ReSharper disable MemberCanBePrivate.Global

namespace Zeeko.ImgurCli.Service;

public class ConfigFileProvider : ISingletonDependency
{
  private readonly IFileSystem _fs; // Add this line

  public static readonly string ConfigDirPath = Path.Join(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "zeeko-imgur-cli");

  public static string ConfigFilePath =>
    Path.Join(ConfigDirPath, "appsettings.json");

  private readonly Lazy<AppConfig> _lazyAppConfig;

  private static readonly JsonSerializerOptions JSONSerializerOptions =
    new(JsonSerializerDefaults.Web)
    { WriteIndented = true };

  public AppConfig AppConfig => _lazyAppConfig.Value;
  private ILogger<ConfigFileProvider> _logger;

  public ConfigFileProvider(
    IFileSystem fs,
    IFilePermissionProvider filePermissionProvider,
    ILogger<ConfigFileProvider> logger)
  {
    _fs = fs;
    _logger = logger;
    _lazyAppConfig = new Lazy<AppConfig>(LoadConfig);
    fs.Directory.CreateDirectory(ConfigDirPath);
    if (fs.File.Exists(ConfigFilePath))
    {
      return;
    }

    fs.File.WriteAllText(ConfigFilePath, "{}", Encoding.UTF8);
    filePermissionProvider.RestrictFilePermissions(ConfigFilePath);
  }

  private AppConfig LoadConfig()
  {
    // read config file as json
    var configFileContent = _fs.File.ReadAllText(ConfigFilePath);
    _logger.LogDebug("Config file content: {ConfigContent}", configFileContent);
    var config = JsonSerializer.Deserialize<AppConfig>(
      configFileContent,
      JSONSerializerOptions);
    _logger.LogDebug("Config object: {ConfigObject}", config);
    return config ?? new AppConfig();
  }

  public void UpdateConfig(AppConfig config)
  {
    // write config file as json
    var json = JsonSerializer.Serialize(
      config,
      JSONSerializerOptions);
    _fs.File.WriteAllText(ConfigFilePath, json, Encoding.UTF8);
  }
}

public record ClientInfo
{
  public required string ClientId { get; init; }
  public required string ClientSecret { get; init; }
}

public record AppConfig
{
  public OAuth2Token? Token { get; set; }
  public ClientInfo? ClientInfo { get; set; }
  public AppSettings Settings { get; set; } = new();
}

/// <summary>
/// </summary>
public record AppSettings
{
  /// <summary>The default album to upload to.</summary>
  public string? DefaultAlbum { get; init; }
}
