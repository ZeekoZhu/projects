using System.Text.RegularExpressions;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Imgur.API.Models;

namespace Zeeko.ImgurCli.Service;

public class ImgurService : ITransientDependency
{
  public ImgurService(
    IHttpClientFactory httpClientFactory,
    ConfigFileProvider configFileProvider,
    ILogger<ImgurService> logger)
  {
    HttpClientFactory = httpClientFactory;
    ConfigFileProvider = configFileProvider;
    Logger = logger;
    HttpClient = HttpClientFactory.CreateClient("imgur");
  }

  public IHttpClientFactory HttpClientFactory { get; init; }
  public HttpClient HttpClient { get; init; }
  public ConfigFileProvider ConfigFileProvider { get; init; }

  protected ClientInfo ClientInfo =>
    ConfigFileProvider.AppConfig.ClientInfo ??
    throw new InvalidOperationException("No client id & client secret provided");

  protected OAuth2Token Token =>
    ConfigFileProvider.AppConfig.Token ??
    throw new InvalidOperationException("No token provided, please run `imgur-cli auth` first");


  public ILogger<ImgurService> Logger { get; init; }

  public string GetAuthUrl(ClientInfo? clientInfo)
  {
    Logger.LogDebug("get auth url with client info: {ClientInfo}", clientInfo);
    var finalClientInfo = clientInfo ?? ClientInfo;
    var apiClient = new ApiClient(finalClientInfo.ClientId, finalClientInfo.ClientSecret);
    var oAuth2Endpoint = new OAuth2Endpoint(apiClient, HttpClient);
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
    var oAuth2Endpoint = new OAuth2Endpoint(apiClient, HttpClient);
    var newToken = await oAuth2Endpoint.GetTokenAsync(authToken.RefreshToken) as OAuth2Token;
    ConfigFileProvider.UpdateConfig(
      ConfigFileProvider.AppConfig with { ClientInfo = finalClientInfo, Token = newToken });
    Logger.LogDebug("new token saved: {@NewToken}", newToken);
  }

  public async Task<string> UploadImageAsync(
    UploadImageDto dto,
    IProgress<int> progress,
    CancellationToken cancellationToken)
  {
    var apiClient = new ApiClient(ClientInfo.ClientId, ClientInfo.ClientSecret);
    Logger.LogDebug("upload image with {@ClientInfo} {@Token}", ClientInfo, Token);
    apiClient.SetOAuth2Token(Token);
    var imgEndpoint = new ImageEndpoint(apiClient, HttpClient);
    var resp = await imgEndpoint.UploadImageAsync(
      dto.ImageStream,
      dto.AlbumHash,
      dto.FileName,
      dto.Title,
      dto.Description,
      progress,
      4096,
      cancellationToken);
    return resp.Link;
  }
}

public record UploadImageDto(
  Stream ImageStream,
  string FileName,
  string? Title,
  string? Description,
  string? AlbumHash);
