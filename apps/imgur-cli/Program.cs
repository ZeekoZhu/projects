using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Spectre.Console;
using Volo.Abp;
using Zeeko.ImgurCli.Commands;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli;

public class Program
{

  public static async Task<int> Main(string[] args)
  {
    var levelSwitch = new LoggingLevelSwitch(LogEventLevel.Warning);
    var appLevelSwitch = new LoggingLevelSwitch();
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.ControlledBy(levelSwitch)
      .MinimumLevel.Override("Zeeko", appLevelSwitch)
      .Enrich.FromLogContext()
      .WriteTo.Async(c => c.Console())
      .CreateLogger();

    try
    {
      var builder = Host.CreateDefaultBuilder();

      builder.ConfigureServices(
          services =>
          {
            services.AddApplicationAsync<ImgurCliModule>(
              options =>
              {
                options.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(ConfigFileProvider.ConfigDirPath));
                options.Services.ReplaceConfiguration(services.GetConfiguration());
                options.Services.AddLogging(loggingBuilder => loggingBuilder.ClearProviders().AddSerilog());
              });
          })
        .UseAutofac()
        .ConfigureAppConfiguration(
          b =>
          {
            b.SetBasePath(ConfigFileProvider.ConfigDirPath).AddJsonFile("appsettings.json", true, false);
          })
        .UseCommandLineApplication<RootCommand>(args);

      var host = builder.Build();
      await host.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>()
        .InitializeAsync(host.Services);

      if (host.Services.GetRequiredService<IHostEnvironment>().IsDevelopment())
      {
        levelSwitch.MinimumLevel = LogEventLevel.Debug;
        appLevelSwitch.MinimumLevel = LogEventLevel.Debug;
      }

      return await host.RunCommandLineApplicationAsync();
    }
    catch (Exception ex)
    {
      if (ex is HostAbortedException)
      {
        throw;
      }

      AnsiConsole.WriteException(ex);
      return 1;
    }
    finally
    {
      await Log.CloseAndFlushAsync();
    }
  }
}
