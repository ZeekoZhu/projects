using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        return Task.CompletedTask;
    }
}
