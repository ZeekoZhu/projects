using Avalonia.ReactiveUI;
using Projects.AvaloniaUtils;
using ReactiveUI;
using Serilog;
using Serilog.Events;
using Splat;
using Splat.Serilog;

namespace Projects.Project42;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static void Main(string[] args)
  {
    Log.Logger = SerilogHelper.CreateApplicationLogger("Projects")
      .CreateLogger();

    X11Helper.SetGlobalScalingFactor();

    AppModule();

    BuildAvaloniaApp()
      .StartWithClassicDesktopLifetime(args);
  }

  private static void AppModule()
  {
    Locator.CurrentMutable.UseSerilogFullLogger();
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
  {
    return AppBuilder.Configure<App>()
      .UsePlatformDetect()
      .UseReactiveUI()
      .With(new X11PlatformOptions { EnableIme = true })
      .WithInterFont()
      .AddLog();
  }
}
