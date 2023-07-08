using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Spectre.Console;
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
      .MinimumLevel.Override("System.Net.Http.HttpClient", levelSwitch)
      .Enrich.FromLogContext()
      .WriteTo.Console()
      .CreateLogger();

    try
    {
      var builder = Host.CreateDefaultBuilder();

      builder.ConfigureServices(
          (ctx, services) =>
          {
            ConfigureDI(services);
            ConfigureMapster(services);
            ConfigureAppConfig(services, ctx);

            services.AddSingleton(AnsiConsole.Console);
            services.AddHttpClient("imgur")
              .AddHttpMessageHandler(sp => sp.GetRequiredService<LogBodyHandler>());
            services.AddLogging(loggingBuilder => loggingBuilder.ClearProviders().AddSerilog());
          })
        .ConfigureAppConfiguration(
          b =>
          {
            b.SetBasePath(ConfigFileProvider.ConfigDirPath).Sources.Clear();
            b.AddEnvironmentVariables("DOTNET_");
          })
        .UseCommandLineApplication<RootCommand>(args);


      var host = builder.Build();

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

  private static void ConfigureAppConfig(IServiceCollection services, HostBuilderContext ctx)
  {
    services.AddSingleton<IFileProvider>(
      new PhysicalFileProvider(ConfigFileProvider.ConfigDirPath));
    services.Configure<AppConfig>(ctx.Configuration.GetSection(ConfigFileProvider.ConfigKey));
  }

  private static void ConfigureMapster(IServiceCollection services)
  {
    // Mapster
    services.AddSingleton(TypeAdapterConfig.GlobalSettings);
    services.AddSingleton<IMapper, ServiceMapper>();
  }

  private static void ConfigureDI(IServiceCollection services)
  {
    // Dependency Injection
    services.Scan(
      scan => scan.FromAssemblyOf<ITransientDependency>()
        .AddClasses(classes => classes.AssignableTo<ITransientDependency>())
        .AsSelfWithInterfaces()
        .WithTransientLifetime()
        .AddClasses(classes => classes.AssignableTo<ISingletonDependency>())
        .AsSelfWithInterfaces()
        .WithSingletonLifetime()
        .AddClasses(classes => classes.AssignableTo<IScopedDependency>())
        .AsSelfWithInterfaces()
        .WithSingletonLifetime()
    );
    services.AddTransient<ILazyServiceProvider, LazyServiceProvider>();
  }
}
