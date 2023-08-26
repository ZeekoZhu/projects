using GitRest.Infrastructure;
using Splat;
using Splat.Serilog;

namespace GitRest.Service;

public class Bootstrap : IEnableLogger
{
  public Bootstrap()
  {
    // infrastructure
    Locator.CurrentMutable.UseSerilogFullLogger();

    // config object
    Locator.CurrentMutable.RegisterLazySingleton(
      GitMonitorOptions.Load);

    // platform specific
    if (PlatformHelper.IsLinux())
    {
      Locator.CurrentMutable.RegisterLazySingleton(
        () => new LinuxGitCommandMonitor());
    }

    // service
    Locator.CurrentMutable.RegisterLazySingleton(
      () => new GitCommandParser());
    Locator.CurrentMutable.RegisterLazySingleton(
      () => new AlertWindowManager());
    Locator.CurrentMutable.RegisterLazySingleton(
      () => new TakeARestManager());

    // window
    Locator.CurrentMutable.RegisterLazySingleton(
      () => new MainWindow());
    Locator.CurrentMutable.RegisterLazySingleton(
      () => new MainWindowViewModel());
  }
}
