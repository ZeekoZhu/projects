using System.Text.RegularExpressions;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli.Service;

public class ImgurService : ITransientDependency
{
  private readonly HttpClient _httpClient = new();
  public required ConfigFileProvider ConfigFileProvider { get; init; }

  protected ClientInfo ClientInfo =>
    ConfigFileProvider.AppConfig.ClientInfo ??
    throw new InvalidOperationException("No client id & client secret provided");

  public required ILogger<ImgurService> Logger { get; init; }

  public string GetAuthUrl(ClientInfo? clientInfo)
  {
    Logger.LogDebug("get auth url with client info: {ClientInfo}", clientInfo);
    var finalClientInfo = clientInfo ?? ClientInfo;
    var apiClient = new ApiClient(finalClientInfo.ClientId, finalClientInfo.ClientSecret);
    var oAuth2Endpoint = new OAuth2Endpoint(apiClient, _httpClient);
    return oAuth2Endpoint.GetAuthorizationUrl();
  }

  private OAuth2Token ExtractToken(string redirectUrl)
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

  public async Task RefreshTokenAsync(ClientInfo? clientInfo, string? callbackUrl)
  {
    var finalClientInfo = clientInfo ?? ClientInfo;
    var authToken = (callbackUrl is null ? ConfigFileProvider.AppConfig.Token : ExtractToken(callbackUrl)) ??
                    throw new InvalidOperationException("No auth token provided");
    Logger.LogDebug("refresh token with {@ClientInfo} {@AuthToken}", finalClientInfo, authToken);
    var apiClient = new ApiClient(finalClientInfo.ClientId, finalClientInfo.ClientSecret);
    var oAuth2Endpoint = new OAuth2Endpoint(apiClient, _httpClient);
    var newToken = await oAuth2Endpoint.GetTokenAsync(authToken.RefreshToken) as OAuth2Token;
    ConfigFileProvider.UpdateConfig(
      ConfigFileProvider.AppConfig with { ClientInfo = finalClientInfo, Token = newToken });
    Logger.LogDebug("new token saved: {@NewToken}", newToken);
  }
}
