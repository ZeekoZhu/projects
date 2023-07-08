using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Zeeko.ImgurCli.Dto;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

public class UploadCommand : CommandBase
{
  private readonly ConfigFileProvider _configFile;

  [Required]
  [FileExists]
  [Option("-f|--file", Description = "The image file to upload")]
  public required string FilePath { get; init; }

  [Option("-t|--title", Description = "The title of the image")]
  public string? Title { get; init; }

  [Option("-n|--name", Description = "The name of the file")]
  public string? FileName { get; init; }

  [Option("-d|--description", Description = "The description of the image")]
  public string? Description { get; init; }

  [Option(
    "-a|--album",
    Description =
      "The album id to add the image to. For anonymous albums, {album} should be the deletehash that is returned at creation.")]
  public string? Album { get; init; }

  public UploadCommand(
    ILazyServiceProvider lazyServiceProvider,
    ConfigFileProvider configFile) : base(
    lazyServiceProvider)
  {
    _configFile = configFile;
  }

  public ImgurService Imgur =>
    ServiceProvider.GetRequiredService<ImgurService>();

  public override async Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    var album = Album ?? _configFile.AppConfig.Settings.DefaultAlbum;
    if (album is null)
    {
      Logger.LogInformation("No album specified, uploading to anonymous album");
    }

    var file = ResolveFile(FilePath);
    Logger.LogDebug("Uploading file {FilePath} to album {Album}", file, album);
    var progress = new Progress<int>();

    var uploadResult = await Imgur.UploadImageAsync(
      new UploadImageDto(
        file.OpenRead(),
        FileName ?? file.Name,
        Title,
        Description,
        album),
      progress,
      CancellationToken.None);
    Cli.MarkupLineInterpolated(
      @$"[green]Upload successful![/]
[blue]Image Url:[/] [link={uploadResult.Link}]{uploadResult.Link}[/]
[blue]Delete Hash:[/] {uploadResult.DeleteHash}
");
    return 0;
  }

  private FileInfo ResolveFile(string filePath)
  {
    // convert to absolute path
    var absolute = Path.GetFullPath(filePath);
    // create file info
    return new FileInfo(absolute);
  }
}
