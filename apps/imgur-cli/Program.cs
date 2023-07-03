using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Volo.Abp;

namespace Zeeko.ImgurCli;

public class Program
{
  public static async Task<int> Main(string[] args)
  {
    Log.Logger = new LoggerConfiguration()
#if DEBUG
      .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
      .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
      .Enrich.FromLogContext()
      .WriteTo.Async(c => c.Console())
      .CreateLogger();

    try
    {
      var builder = Host.CreateDefaultBuilder(args);

      builder.ConfigureServices(
          services =>
          {
            services.AddHostedService<ImgurCliHostedService>();
            services.AddApplicationAsync<ImgurCliModule>(
              options =>
              {
                options.Services.ReplaceConfiguration(services.GetConfiguration());
                options.Services.AddLogging(loggingBuilder => loggingBuilder.ClearProviders().AddSerilog());
              });
          })
        .AddAppSettingsSecretsJson()
        .UseAutofac()
        .UseConsoleLifetime();

      var host = builder.Build();
      await host.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>()
        .InitializeAsync(host.Services);

      await host.RunAsync();

      return 0;
    }
    catch (Exception ex)
    {
      if (ex is HostAbortedException)
      {
        throw;
      }

      Log.Fatal(ex, "Terminated unexpectedly!");
      return 1;
    }
    finally
    {
      Log.CloseAndFlush();
    }
  }
}
