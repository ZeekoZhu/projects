using Avalonia.ReactiveUI;
using Projects.AvaloniaUtils;
using Projects.Project42.Markup;
using ReactiveUI;
using Splat;

namespace Projects.Project42;

public class ViewModelBase : ReactiveObject, IEnableLocator;

public abstract class MarkupViewBase<T> : ReactiveUserControl<T>, IEnableLogger,
  IMarkupView, IEnableLocator
  where T : class
{
  protected T Model => ViewModel ??
                       throw new InvalidOperationException("ViewModel is null");

  protected MarkupViewBase()
  {
    this.GetObservable(ViewModelProperty)
      .Where(vm => vm is not null)
      .Take(1)
      .Subscribe(_ => { View(); });
  }

  public abstract void View();
}

public abstract class MarkupWindowBase<T> : ReactiveWindow<T>, IEnableLogger,
  IMarkupView, IEnableLocator
  where T : class
{
  public bool IsProduction()
  {
    // if defined DEBUG or debugger attached, return false
#if DEBUG
    return false;
#else
    return true;
#endif
  }

  protected readonly IFullLogger Logger;

  private readonly KeyGesture _hotReloadGesture =
    new(Key.R, KeyModifiers.Control);

  public bool IsHotReloadEnabled()
  {
    return !IsProduction() && !Debugger.IsAttached;
  }

  protected MarkupWindowBase()
  {
    Logger = this.GetService<ILogManager>().GetLogger(GetType());
    this.GetObservable(ViewModelProperty)
      .Where(vm => vm is not null)
      .Take(1)
      .Subscribe(_ => { View(); });
    if (IsHotReloadEnabled())
    {
      this.ObserveOnKeyDown(RoutingStrategies.Tunnel)
        .Subscribe(args =>
        {
          if (!_hotReloadGesture.Matches(args)) return;
          Logger.Debug("Refreshed view.");
          View();
        });
    }
  }

  public abstract void View();
}
