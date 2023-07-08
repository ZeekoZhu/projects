using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

[HelpOption("-?|-h|--help")]
public abstract class CommandBase : ITransientDependency
{
  protected ILazyServiceProvider ServiceProvider { get; }

  protected ILogger Logger =>
    ServiceProvider.GetRequiredService<ILogger>(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger(GetType()));

  protected IAnsiConsole Cli => ServiceProvider.GetRequiredService<IAnsiConsole>();

  public CommandBase(ILazyServiceProvider serviceProvider)
  {
    ServiceProvider = serviceProvider;
  }

  public virtual Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    app.ShowHelp();
    return Task.FromResult(0);
  }
}
