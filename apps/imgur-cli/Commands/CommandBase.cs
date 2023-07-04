using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli.Commands;

[HelpOption("-?|-h|--help")]
public abstract class CommandBase : ITransientDependency
{
  protected IAbpLazyServiceProvider LazyServiceProvider { get; }
  protected ILogger Logger => LazyServiceProvider.LazyGetRequiredService<ILoggerFactory>().CreateLogger(GetType());
  protected IAnsiConsole Cli => LazyServiceProvider.GetRequiredService<IAnsiConsole>();

  public CommandBase(IAbpLazyServiceProvider lazyServiceProvider)
  {
    LazyServiceProvider = lazyServiceProvider;
  }

  public virtual Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    app.ShowHelp();
    return Task.FromResult(0);
  }
}
