using Splat;
using Splat.Serilog;

namespace Projects.StatusTray;

public class Bootstrap
{
  public Bootstrap()
  {
    Locator.CurrentMutable.UseSerilogFullLogger();
  }
}
