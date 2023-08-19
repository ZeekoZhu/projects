using System;
using Avalonia;
using Avalonia.Logging;
using Serilog;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace GitRest.Logging;

public class SerilogSink : ILogSink
{
  private readonly ILogger _logger = Serilog.Log.Logger;

  public bool IsEnabled(LogEventLevel level, string area)
  {
    return _logger.IsEnabled(TranslateLevel(level));
  }

  public void Log(
    LogEventLevel level,
    string area,
    object? source,
    string messageTemplate)
  {
    _logger.Write(TranslateLevel(level), messageTemplate);
  }

  public void Log(
    LogEventLevel level,
    string area,
    object? source,
    string messageTemplate,
    params object?[] propertyValues)
  {
    _logger.Write(TranslateLevel(level), messageTemplate, propertyValues);
  }

  public static Serilog.Events.LogEventLevel TranslateLevel(
    LogEventLevel level)
  {
    return level switch
    {
      LogEventLevel.Verbose => Serilog.Events.LogEventLevel.Verbose,
      LogEventLevel.Debug => Serilog.Events.LogEventLevel.Debug,
      LogEventLevel.Information => Serilog.Events.LogEventLevel.Information,
      LogEventLevel.Warning => Serilog.Events.LogEventLevel.Warning,
      LogEventLevel.Error => Serilog.Events.LogEventLevel.Error,
      LogEventLevel.Fatal => Serilog.Events.LogEventLevel.Fatal,
      _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
    };
  }
}

public static class AppExtension
{
  public static AppBuilder AddLog(
    this AppBuilder builder,
    LogEventLevel level = LogEventLevel.Warning)
  {
    Logger.Sink =
      new SerilogSink();
    Logger.Sink.Log(LogEventLevel.Debug, "App", null, "Log is ready");
    return builder;
  }
}
