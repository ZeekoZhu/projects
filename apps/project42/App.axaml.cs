using Projects.AvaloniaUtils.HotReload;
using Splat;
using static Projects.Project42.CustomLabelBuilder;


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
      .Title("project 42")
      .Content(
        StackPanel()
          .Children(
            Label()
              .Content("Hello, world! Welcome to hotreload world!")
              .Foreground(Brushes.DodgerBlue),
            Button()
              .Content("Counter")
              .OnClick(
                (_, o) => o.Subscribe(_ =>
                  _counter.OnNext(
                    _counter.Value + 1))),
             CustomLabel()
              .Text(_counter.Select(c => $"Counter: {c}"))
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
