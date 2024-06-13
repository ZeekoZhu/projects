using Serilog;
using Path = System.IO.Path;

namespace Projects.AvaloniaUtils;

public class X11Helper
{
  private static ILogger Log => Serilog.Log.ForContext<X11Helper>();

  public static float GetWindowScalingFactor()
  {
    var unscaledDpi = ReadXSettingsdValue("Gdk/UnscaledDPI");

    var scalingFactor = ReadXSettingsdValue("Gdk/WindowScalingFactor");
    switch (unscaledDpi, scalingFactor)
    {
      case (null, null):
        Log.Warning(
          "Unable to determine scaling factor from xsettingsd config. Defaulting to 1.0");
        return 1;
      case (null, { } factor):
        Log.Information("Using Scaling factor: {Factor}", factor);
        return factor;
      case ({ } dpi, null):
        Log.Information("Using DPI: {Dpi}", unscaledDpi);
        return dpi / 1024 / 96;
      case ({ } dpi, { } factor):
        Log.Information(
          "Using DPI x Scaling Factor: {Dpi} / 1024 / 96 x {Factor}",
          unscaledDpi, factor);
        return dpi / 1024 / 96 * factor;
    }
  }

  private static float? ReadXSettingsdValue(string key)
  {
    var configFilePath = Path.Join(
      Environment.GetEnvironmentVariable("HOME"),
      ".config",
      "xsettingsd",
      "xsettingsd.conf");
    var content = File.ReadLines(configFilePath);
    var targetLine = content.FirstOrDefault(
      line => { return line.StartsWith(key); });
    // return int.Parse(targetLine?.Split(' ')[1].Trim() ?? defaultVal);
    if (targetLine == null) return null;

    try
    {
      return float.Parse(targetLine.Split(' ')[1].Trim());
    }
    catch (Exception e)
    {
      Log.Error(e, "Failed to read {Key} from xsettingsd config",
        key);
      return null;
    }
  }

  public static void SetGlobalScalingFactor()
  {
    if (!PlatformHelper.IsLinux()) return;
    var factor = GetWindowScalingFactor();
    Environment.SetEnvironmentVariable(
      "AVALONIA_GLOBAL_SCALE_FACTOR",
      factor.ToString());
  }
}
