using Splat;
using Splat.Serilog;

namespace GitRest.Service;

public class Bootstrap : IEnableLogger
{
  public Bootstrap()
  {
    // infrastructure
    Locator.CurrentMutable.UseSerilogFullLogger();

    // platform specific
    if (PlatformHelper.IsLinux())
    {
      Locator.CurrentMutable.Register(
        () => new LinuxGitCommandMonitor());
    }

    // service
    Locator.CurrentMutable.Register(
      () => new GitCommandParser());
    Locator.CurrentMutable.Register(
      () => new AlertWindowManager());
    Locator.CurrentMutable.Register(
      () => new TakeARestManager());

    // window
    Locator.CurrentMutable.Register(
      () => new MainWindow());
  }
}
