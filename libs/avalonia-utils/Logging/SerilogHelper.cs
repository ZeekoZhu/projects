using Serilog;

namespace Projects.AvaloniaUtils;

public static class SerilogHelper
{
  public static LoggerConfiguration CreateApplicationLogger(string name)
  {
    return new LoggerConfiguration()
        .MinimumLevel.Warning()
        .MinimumLevel.Override(name, Serilog.Events.LogEventLevel.Debug)
        .WriteTo.Console(
          outputTemplate:
          "[{Timestamp:HH:mm:ss} {Level:u3} {SourceContext}] {Message:lj}{NewLine}{Exception}")
      ;
  }
}
