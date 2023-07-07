using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli;

/// <summary>
/// Log the body of the request and response if the body is json
/// </summary>
public class LogBodyHandler : DelegatingHandler, ITransientDependency
{
  private readonly ILogger<LogBodyHandler> _logger;

  public LogBodyHandler(ILogger<LogBodyHandler> logger)
  {
    _logger = logger;
  }

  protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
  {
    // log the request body
    // if the request body is json
    if (request.Content?.Headers.ContentType?.MediaType == "application/json")
    {
      // read the request body
      string requestBody = await request.Content.ReadAsStringAsync(cancellationToken);
      // log the request body
      _logger.LogDebug("Request Body: {RequestBody}", requestBody);
    }

    var resp = await base.SendAsync(request, cancellationToken);
    // log the response body
    // if the response body is json
    if (resp.Content?.Headers.ContentType?.MediaType == "application/json")
    {
      // read the response body
      string responseBody = await resp.Content.ReadAsStringAsync(cancellationToken);
      // log the response body
      _logger.LogDebug("Response Body: {ResponseBody}", responseBody);
    }

    return resp;
  }
}
