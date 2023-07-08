using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

public class UploadCommand : CommandBase
{
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

  public UploadCommand(ILazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
  {
  }

  public ImgurService Imgur => ServiceProvider.GetRequiredService<ImgurService>();

  public override async Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    var file = ResolveFile(FilePath);
    Logger.LogDebug("Uploading file {FilePath}", file);
    var progress = new Progress<int>();
    var uploadTask = Imgur.UploadImageAsync(
      new UploadImageDto(file.OpenRead(), FileName ?? file.Name, Title, Description, Album),
      progress,
      CancellationToken.None);
    var uploadResult = await Cli.Progress()
      .StartAsync(
        async ctx =>
        {
          var task = ctx.AddTask("[green]Uploading...[/]");
          var fileSize = file.Length;
          progress.ProgressChanged += (_, args) =>
          {
            task.Increment(Math.Ceiling(args / (float)fileSize) * 100);
          };
          return await uploadTask;
        });
    Cli.MarkupLineInterpolated($"[green]Upload successful![/] [link={uploadResult}]{uploadResult}[/]");
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
