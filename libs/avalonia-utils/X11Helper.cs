using Serilog;

namespace Projects.AvaloniaUtils;

public class X11Helper
{
  private static ILogger Log => Serilog.Log.ForContext<X11Helper>();

  public static int GetGdkWindowScalingFactor()
  {
    try
    {
      var configFilePath = Path.Join(
        Environment.GetEnvironmentVariable("HOME"),
        ".config",
        "xsettingsd",
        "xsettingsd.conf");
      var content = File.ReadLines(configFilePath);
      var targetLine = content.FirstOrDefault(
        line => line.StartsWith("Gdk/WindowScalingFactor"));
      return int.Parse(targetLine?.Split(' ')[1].Trim() ?? "1");
    }
    catch (Exception e)
    {
      Log.Error(e, "Failed to get Gdk/WindowScalingFactor");
      return 1;
    }
  }

  public static void SetGlobalScalingFactor()
  {
    if (!PlatformHelper.IsLinux()) return;
    var factor = GetGdkWindowScalingFactor();
    Log.Information("Gdk/WindowScalingFactor: {Factor}", factor);
    Environment.SetEnvironmentVariable(
      "AVALONIA_GLOBAL_SCALE_FACTOR",
      factor.ToString());
  }
}
