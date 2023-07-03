using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Zeeko.ImgurCli;

public class ImgurCliHostedService : IHostedService
{
  private readonly IAbpApplicationWithExternalServiceProvider _abpApplication;
  private readonly HelloWorldService _helloWorldService;
  public required ILogger<ImgurCliHostedService> Logger { get; set; }
  public required IHostApplicationLifetime ApplicationLifetime { get; set; }

  public ImgurCliHostedService(
    HelloWorldService helloWorldService,
    IAbpApplicationWithExternalServiceProvider abpApplication)
  {
    _helloWorldService = helloWorldService;
    _abpApplication = abpApplication;
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {
    await _helloWorldService.SayHelloAsync();
    Logger.LogInformation("Starting console host");
    ApplicationLifetime.StopApplication();
  }

  public async Task StopAsync(CancellationToken cancellationToken)
  {
    Logger.LogInformation("Shutdown console host");
    await _abpApplication.ShutdownAsync();
  }
}
