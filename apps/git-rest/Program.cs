using Avalonia;
using System;
using Avalonia.Controls;
using GitRest.Logging;
using Serilog;

namespace GitRest;

class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static void Main(string[] args)
  {
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Warning()
      .MinimumLevel.Override("GitRest", Serilog.Events.LogEventLevel.Debug)
      .WriteTo.Console(
        outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3} {SourceContext}] {Message:lj}{NewLine}{Exception}")
      .CreateLogger();
    X11Helper.SetGlobalScalingFactor();
    BuildAvaloniaApp()
      .StartWithClassicDesktopLifetime(args, ShutdownMode.OnExplicitShutdown);
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>()
      .UsePlatformDetect()
      .With(new X11PlatformOptions { EnableIme = true })
      .WithInterFont()
      .AddLog();
}
