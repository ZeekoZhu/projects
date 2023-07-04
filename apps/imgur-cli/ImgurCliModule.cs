using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Spectre.Console;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Zeeko.ImgurCli;

[DependsOn(
  typeof(AbpAutofacModule)
)]
public class ImgurCliModule : AbpModule
{
  public override void ConfigureServices(ServiceConfigurationContext context)
  {
    context.Services.AddSingleton(AnsiConsole.Console);
  }

  public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
  {
    EnsureConfigFile(context);

    return Task.CompletedTask;
  }

  private static void EnsureConfigFile(ApplicationInitializationContext context)
  {
    var logger = context.ServiceProvider.GetRequiredService<ILogger<ImgurCliModule>>();
    var fp = context.ServiceProvider.GetRequiredService<IFileProvider>();

    var appSettingsFile = fp.GetFileInfo("appsettings.json");

    if (appSettingsFile is not { Exists: false, PhysicalPath: not null }) return;

    // create the file
    logger.LogDebug("Creating appsettings.json at {Path}", appSettingsFile.PhysicalPath);
    File.WriteAllText(appSettingsFile.PhysicalPath, "{}");
  }
}
