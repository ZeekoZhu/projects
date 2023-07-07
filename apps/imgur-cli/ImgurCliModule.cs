using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli;

[DependsOn(
  typeof(AbpAutofacModule),
  typeof(AbpObjectMappingModule),
  typeof(AbpAutoMapperModule)
)]
public class ImgurCliModule : AbpModule
{
  public override void ConfigureServices(ServiceConfigurationContext context)
  {
    context.Services.AddSingleton(AnsiConsole.Console);
    context.Services.Configure<AppConfig>(
      context.Services.GetConfiguration().GetSection(ConfigFileProvider.ConfigKey));
    context.Services.AddHttpClient("imgur")
      .AddHttpMessageHandler(sp => sp.GetRequiredService<LogBodyHandler>());
    //Use AutoMapper for MyModule
    context.Services.AddAutoMapperObjectMapper<ImgurCliModule>();
    Configure<AbpAutoMapperOptions>(
      options =>
      {
        //Add all mappings defined in the assembly of the MyModule class
        options.AddProfile<AppMapping>();
      });
  }

  public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
  {
    return Task.CompletedTask;
  }
}
