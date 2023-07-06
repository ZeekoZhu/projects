using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Volo.Abp.DependencyInjection;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli.Commands;

public class AuthCommand : CommandBase
{
  [Option("-c|--client-id", Description = "Client ID")]
  public required string ClientId { get; init; }

  [Option("-s|--client-secret", Description = "Client Secret")]
  public required string ClientSecret { get; init; }

  protected ConfigFileProvider ConfigFileProvider => LazyServiceProvider.LazyGetRequiredService<ConfigFileProvider>();
  protected ImgurService Imgur => LazyServiceProvider.LazyGetRequiredService<ImgurService>();


  public AuthCommand(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
  {
  }

  public override async Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    var clientInfo = new ClientInfo(ClientId, ClientSecret);
    var authUrl = Imgur.GetAuthUrl(clientInfo);
    Cli.WriteLine(authUrl, new Style(foreground: Color.Green, decoration: Decoration.Underline, link: authUrl));
    Cli.WriteLine(
      "Open the above URL in your browser and authorize the app, after the redirection, copy the url from address bar and paste it here.");
    var redirectUrl =
      Cli.Ask<string>("> ");
    await Imgur.RefreshTokenAsync(clientInfo, redirectUrl);
    Cli.MarkupLineInterpolated($"[green]Login successful![/]");
    return 0;
  }
}
