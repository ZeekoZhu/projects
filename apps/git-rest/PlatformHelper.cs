using System.Runtime.InteropServices;

namespace GitRest;

public class PlatformHelper
{
  public static bool IsLinux()
  {
    return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
  }
}
