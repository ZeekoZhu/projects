using McMaster.Extensions.CommandLineUtils;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli.Commands;

[Subcommand(typeof(AuthCommand), typeof(UploadCommand))]
public class RootCommand : CommandBase
{
  public override async Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    app.ShowHelp();
    return 0;
  }

  public RootCommand(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
  {
  }
}
