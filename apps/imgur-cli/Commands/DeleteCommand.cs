using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

public class DeleteCommand : CommandBase
{
  private readonly ImgurService _imgur;

  [Required]
  [Argument(0, "imageHash", "The hash of the image to delete")]
  public required string Hash { get; set; }

  public DeleteCommand(
    ILazyServiceProvider serviceProvider,
    ImgurService imgur) : base(serviceProvider)
  {
    _imgur = imgur;
  }

  public override async Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    await _imgur.DeleteImageAsync(Hash);
    return 0;
  }
}
