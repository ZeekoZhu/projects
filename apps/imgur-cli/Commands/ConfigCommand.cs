using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

[Subcommand(typeof(SetDefaultAlbumCommand))]
public class ConfigCommand : CommandBase
{
  public ConfigCommand(ILazyServiceProvider serviceProvider)
    : base(serviceProvider)
  {
  }
}

public class SetDefaultAlbumCommand : CommandBase
{
  private readonly ConfigFileProvider _configFileProvider;

  [Required]
  [Argument(0, "AlbumHash", "The hash of the album to set as default")]
  public required string AlbumHash { get; init; }

  public SetDefaultAlbumCommand(
    ILazyServiceProvider serviceProvider,
    ConfigFileProvider configFileProvider) : base(
    serviceProvider)
  {
    _configFileProvider = configFileProvider;
  }

  public override Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    _configFileProvider.UpdateConfig(
      _configFileProvider.AppConfig with
      {
        // ReSharper disable once WithExpressionModifiesAllMembers
        Settings = _configFileProvider.AppConfig.Settings with
        {
          DefaultAlbum = AlbumHash
        }
      });
    return Task.FromResult(0);
  }
}
