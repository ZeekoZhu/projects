using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Zeeko.ImgurCli.Dto;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

[RequireFileOrStdin]
public class UploadCommand : CommandBase
{
  private readonly ConfigFileProvider _configFile;

  [Option(
    optionType: CommandOptionType.NoValue,
    template: "--stdin",
    Description = "Read the image from stdin")]
  public bool IsFromStdin { get; init; }

  [FileExists]
  [Option("-f|--file", Description = "The image file to upload")]
  public string? FilePath { get; init; }

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
    else
    {
      Logger.LogDebug("Uploading to album {Album}", album);
    }

    var (fileStream, fileName) = ResolveFile(FilePath, IsFromStdin);
    var progress = new Progress<int>();

    var uploadResult = await Imgur.UploadImageAsync(
      new UploadImageDto(
        fileStream,
        FileName ?? fileName,
        Title,
        Description,
        album),
      progress,
      CancellationToken.None);
    Cli.MarkupLine("[green]Upload successful![/]");
    Cli.MarkupLineInterpolated(
      $"[blue]Image Url:[/] [link={uploadResult.Link}]{uploadResult.Link}[/]");
    if (album is not null)
    {
      var albumUrl = $"https://imgur.com/a/{album}";
      Cli.MarkupLineInterpolated($"[blue]Album Url:[/] [link={albumUrl}]{albumUrl}[/]");
    }

    Cli.MarkupLineInterpolated(
      $"[blue]Delete Hash:[/] {uploadResult.DeleteHash}");
    return 0;
  }

  private (Stream FileStream, string FileName) ResolveFile(
    string? filePath,
    bool isFromStdIn)
  {
    if (filePath is not null)
    {
      Logger.LogDebug("Reading file {FilePath}", filePath);
      // convert to absolute path
      var absolute = Path.GetFullPath(filePath);
      // create file info
      var resolveFile = new FileInfo(absolute);
      return (resolveFile.OpenRead(), resolveFile.Name);
    }

    if (isFromStdIn)
    {
      Logger.LogDebug("Reading from stdin");
      // read bytes from stdin
      var bytes = new MemoryStream();
      Console.OpenStandardInput().CopyTo(bytes);
      bytes.Seek(0, SeekOrigin.Begin);
      return (bytes, "stdin");
    }

    throw new ArgumentException("Must specify file or stdin");
  }
}
