using Projects.Project42.Dashboard;
using Splat;


namespace Projects.Project42;

public class App : Application, IEnableLogger
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      desktop.MainWindow = new DashboardWindow();

    base.OnFrameworkInitializationCompleted();
  }
}
