using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Text.Json;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Test;

public class ConfigFileProviderTests
{
  private IFileSystem _fileSystem = null!;
  private ConfigFileProvider _configFileProvider = null!;
  private IFilePermissionProvider _filePermissionProvider = null!;

  [SetUp]
  public void Setup()
  {
    _fileSystem = new MockFileSystem();
    _filePermissionProvider = Mock.Of<IFilePermissionProvider>();

    _configFileProvider = new ConfigFileProvider(
      _fileSystem,
      _filePermissionProvider,
      NullLogger<ConfigFileProvider>.Instance);
  }

  [Test]
  public void LoadConfig_ShouldReturnAppConfig_WhenCalled()
  {
    // Arrange
    var expectedConfig = new AppConfig
    {
      ClientInfo = new ClientInfo
      {
        ClientId = "test",
        ClientSecret = "test"
      }
    };
    var json = JsonSerializer.Serialize(expectedConfig);
    _fileSystem.File.WriteAllText(ConfigFileProvider.ConfigFilePath, json);

    // Act
    var result = _configFileProvider.AppConfig;

    // Assert
    result.Should().BeEquivalentTo(expectedConfig);
  }

  [Test]
  public void UpdateConfig_ShouldUpdateConfigFile_WhenCalled()
  {
    // Arrange
    var newConfig = new AppConfig
    {
      ClientInfo = new ClientInfo
      {
        ClientId = "test",
        ClientSecret = "test"
      }
    };

    // Act
    _configFileProvider.UpdateConfig(newConfig);

    // Assert
    var configFileContent =
      _fileSystem.File.ReadAllText(ConfigFileProvider.ConfigFilePath);
    var actualConfig = JsonSerializer.Deserialize<AppConfig>(
      configFileContent,
      new JsonSerializerOptions(JsonSerializerDefaults.Web));
    actualConfig.Should().BeEquivalentTo(newConfig);
  }
}
