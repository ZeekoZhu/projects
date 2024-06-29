using Projects.AvaloniaUtils.HotReload;
using Splat;
using static Projects.Project42.Dashboard.MarkupBuilder;


namespace Projects.Project42;

public class App : Application, IEnableLogger
{
  private readonly BehaviorSubject<int> _counter = new(0);

  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  private object MainViewRender(Window window)
  {
    this.Log().Info("Window created");
    return window
      .Width(400)
      .Height(300)
      .WindowStartupLocation(WindowStartupLocation.CenterScreen)
      .Title("project 42")
      .Content(
        Panel()
          .Children(
            DashboardCanvasView()
          )
      );
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      desktop.MainWindow = new HotReloadWindow(MainViewRender);

    base.OnFrameworkInitializationCompleted();
  }
}
