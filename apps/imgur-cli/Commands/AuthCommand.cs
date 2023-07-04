using System.Text.RegularExpressions;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli.Commands;

public class AuthCommand : CommandBase
{
  [Option("-c|--client-id", Description = "Client ID")]
  public required string ClientId { get; init; }

  [Option("-s|--client-secret", Description = "Client Secret")]
  public required string ClientSecret { get; init; }


  public AuthCommand(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
  {
  }

  public override async Task<int> OnExecuteAsync(CommandLineApplication app)
  {
    Logger.LogDebug("OAuth2: {ClientId} {ClientSecret}", ClientId, ClientSecret);
    var apiClient = new ApiClient(ClientId, ClientSecret);
    var httpClient = new HttpClient();

    var oAuth2Endpoint = new OAuth2Endpoint(apiClient, httpClient);
    var authUrl = oAuth2Endpoint.GetAuthorizationUrl();
    Logger.LogInformation("Auth URL: {AuthUrl}", authUrl);
    var redirectUrl =
      Cli.Ask<string>(
        "Open the above URL in your browser and authorize the app, after the redirection, copy the url from address bar and paste it here.\n");
    IOAuth2Token token = ExtractToken(redirectUrl);
    Logger.LogDebug("OAuth2 Token: {Token}", token);
    return 0;
  }

  private IOAuth2Token ExtractToken(string redirectUrl)
  {
    var regex = new Regex(
      "#access_token=(?<access_token>.+)&expires_in=(?<expires_in>.+)&token_type=(?<token_type>.+)&refresh_token=(?<refresh_token>.+)&account_username=(?<account_username>.+)&account_id=(?<account_id>.+)");
    var match = regex.Match(redirectUrl);
    if (!match.Success)
    {
      throw new ApplicationException("Invalid redirect url");
    }

    return new OAuth2Token
    {
      AccessToken = match.Groups["access_token"].Value,
      RefreshToken = match.Groups["refresh_token"].Value,
      AccountId = int.Parse(match.Groups["account_id"].Value),
      AccountUsername = match.Groups["account_username"].Value,
      ExpiresIn = int.Parse(match.Groups["expires_in"].Value),
      TokenType = match.Groups["token_type"].Value
    };
  }
}
