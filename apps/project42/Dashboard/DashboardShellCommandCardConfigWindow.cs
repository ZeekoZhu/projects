using Projects.AvaloniaUtils.HotReload;

namespace Projects.Project42.Dashboard;

public class DashboardShellCommandCardConfigWindow() : HotReloadWindow(View)
{
  private static object View(Window window)
  {
    return window
      .WindowStartupLocation(WindowStartupLocation.CenterOwner)
      .Width(600)
      .Height(400);
  }
}

// todo: reactive window
