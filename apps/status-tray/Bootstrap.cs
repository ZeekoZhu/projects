using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Logging;
using Projects.StatusTray.Domain;
using Projects.StatusTray.StatusProvider.GitLab;
using ReactiveUI;
using Refit;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using Splat.Serilog;

namespace Projects.StatusTray;

public class Bootstrap
{
  public Bootstrap()
  {
    var services = new ServiceCollection();
    services.UseMicrosoftDependencyResolver();
    Locator.CurrentMutable.InitializeSplat();
    Locator.CurrentMutable.InitializeReactiveUI();
    Locator.CurrentMutable.UseSerilogFullLogger();

    services.AddSingleton(new GitLabStatusProviderConfig
    {
      // todo: config file
      PersonalAccessToken = Environment.GetEnvironmentVariable("GITLAB_PAT")!
    });
    services.AddRefitClient<IGitLabApi>(new RefitSettings(
        new SystemTextJsonContentSerializer(
          new JsonSerializerOptions(JsonSerializerDefaults.Web)
          {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
          }))
      )
      .ConfigureHttpClient((sp, c) =>
      {
        var accessToken = sp.GetService<GitLabStatusProviderConfig>()!
          .PersonalAccessToken;
        c.BaseAddress = new Uri("https://gitlab.com/api/v4");
        c.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
      })
      .RemoveAllLoggers()
      .AddLogger<HttpLogHandler>();
    services.AddSingleton<HttpLogHandler>();

    services.AddSingleton<GitLabPrPipelineStatusProvider>();
    services.AddSingleton(sp =>
    {
      var providers = new List<IStatusProvider>
        { sp.GetRequiredService<GitLabPrPipelineStatusProvider>() };
      return new TrayStatusTracker(providers);
    });
  }
}

internal class HttpLogHandler : IHttpClientLogger, IEnableLogger
{
  public object? LogRequestStart(HttpRequestMessage request)
  {
    this.Log().Debug("|=> {Method} {Uri}", request.Method,
      request.RequestUri?.ToString() ?? "");
    return null;
  }

  public void LogRequestStop(object? context, HttpRequestMessage request,
    HttpResponseMessage response, TimeSpan elapsed)
  {
    this.Log().Debug("<=| {StatusCode} {Method} {Uri} {Elapsed}",
      (int)response.StatusCode, request.Method,
      request.RequestUri?.ToString() ?? "", elapsed);
  }

  public void LogRequestFailed(object? context, HttpRequestMessage request,
    HttpResponseMessage? response, Exception exception, TimeSpan elapsed)
  {
    this.Log().Debug("<~| {Method} {Uri} {Elapsed} {Exception}",
      request.Method, request.RequestUri?.ToString() ?? "", elapsed,
      exception);
  }
}
