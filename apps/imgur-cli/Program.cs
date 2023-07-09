using System.IO.Abstractions;
using Mapster;
using MapsterMapper;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
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
      var services = new ServiceCollection();
      ConfigureDI(services);
      ConfigureMapster(services);

      services.AddSingleton(AnsiConsole.Console);
      services.AddHttpClient("imgur")
        .AddHttpMessageHandler(sp => sp.GetRequiredService<LogBodyHandler>());
      services.AddLogging(
        loggingBuilder => loggingBuilder.ClearProviders().AddSerilog());
      services.AddSingleton<IFileSystem, FileSystem>();


      var serviceProvider = services.BuildServiceProvider();
      var app = new CommandLineApplication<RootCommand>();
      app.Conventions.UseDefaultConventions()
        .UseConstructorInjection(serviceProvider);

      if (String.Equals(
            Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT"),
            "Development",
            StringComparison.OrdinalIgnoreCase))
      {
        levelSwitch.MinimumLevel = LogEventLevel.Debug;
        appLevelSwitch.MinimumLevel = LogEventLevel.Debug;
      }

      return await app.ExecuteAsync(args);
    }
    catch (Exception ex)
    {
      AnsiConsole.WriteException(ex);
      return 1;
    }
    finally
    {
      await Log.CloseAndFlushAsync();
    }
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
