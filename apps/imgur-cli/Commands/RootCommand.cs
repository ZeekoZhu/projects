using McMaster.Extensions.CommandLineUtils;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli.Commands;

[Subcommand(typeof(AuthCommand), typeof(UploadCommand))]
public class RootCommand : CommandBase
{
  public override Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    app.ShowHelp();
    return Task.FromResult(0);
  }

  public RootCommand(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
  {
  }
}
