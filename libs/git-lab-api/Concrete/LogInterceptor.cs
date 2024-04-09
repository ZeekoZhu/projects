using Microsoft.Extensions.Logging;
using Projects.GitLabApi.Abstraction;
using RestSharp;

namespace Projects.GitLabApi.Concrete;

public class LogInterceptor(ILogger<IGitLabApi> logger)
{
  public ValueTask BeforeHttpRequest(
    HttpRequestMessage requestMessage,
    CancellationToken cancellationToken)
  {
    logger.LogDebug(
      "==> {Method} {Uri}",
      requestMessage.Method,
      requestMessage.RequestUri);

    return ValueTask.CompletedTask;
  }

  public async ValueTask AfterHttpRequest(
    HttpResponseMessage responseMessage,
    CancellationToken cancellationToken)
  {
    logger.LogDebug(
      "<== {Method} {Uri} {StatusCode}",
      responseMessage.RequestMessage!.Method,
      responseMessage.RequestMessage!.RequestUri,
      responseMessage.StatusCode);

    if (logger.IsEnabled(LogLevel.Debug))
    {
      try
      {
        var headers = responseMessage.Headers;
        logger.LogDebug(
          "--- Response Headers ---\n{Headers}\n--- End of Response Headers ---",
          headers.Select(it => $"{it.Key}: {string.Join(", ", it.Value)}"));
      }
      catch (Exception e)
      {
        // ignore
      }

      try
      {
        var content =
          await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        logger.LogDebug(
          "--- Response Content ---\n{Content}\n--- End of Response Content ---",
          content);
      }
      catch (Exception e)
      {
        // ignore
      }
    }
  }
}

public static class LogRequestExtensions
{
  public static RestRequest LogRequest(
    this RestRequest request,
    LogInterceptor interceptor)
  {
    request.OnBeforeRequest = async requestMessage =>
    {
      await interceptor.BeforeHttpRequest(requestMessage, default);
    };

    request.OnAfterRequest = async responseMessage =>
    {
      await interceptor.AfterHttpRequest(
        responseMessage,
        default);
    };

    return request;
  }
}
