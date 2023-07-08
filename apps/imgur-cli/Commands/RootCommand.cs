using System.Reflection;
using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

[Subcommand(
  typeof(AuthCommand),
  typeof(UploadCommand),
  typeof(ConfigCommand),
  typeof(DeleteCommand))]
public class RootCommand : CommandBase
{
  [Option(
    CommandOptionType.NoValue,
    Template = "-v|--version",
    Description = "Show version information")]
  public bool Version { get; set; }

  public override Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    if (Version)
    {
      // get version from assembly
      var version = GetType()
        .Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
        ?.InformationalVersion ?? "unknown";
      Cli.WriteLine(
        $"Imgur CLI v{version}",
        new Style(
          foreground: Color.Green,
          decoration: Decoration.Bold));
    }

    return Task.FromResult(0);
  }

  public RootCommand(ILazyServiceProvider lazyServiceProvider) : base(
    lazyServiceProvider)
  {
  }
}
