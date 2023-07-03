using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;

namespace Zeeko.ImgurCli;

public class HelloWorldService : ITransientDependency
{
    public required ILogger<HelloWorldService> Logger { get; set; }

    public Task SayHelloAsync()
    {
        Logger.LogInformation("Hello World!");
        return Task.CompletedTask;
    }
}
