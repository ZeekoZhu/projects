using Splat;
using Window = Avalonia.Controls.Window;

namespace Projects.AvaloniaUtils.HotReload;

/// <summary>
///   A hot reload window under development.
///   Press Ctrl + R to reload the view.
/// </summary>
public class HotReloadWindow : Window, IEnableLogger
{
  private readonly Func<Window, object> _contentRender;

  private KeyGesture _hotReloadGesture = new(Key.R, KeyModifiers.Control);

  public HotReloadWindow(Func<Window, object> contentRender)
  {
    _contentRender = contentRender;
    _contentRender(this);
    if (!IsProduction()) this.AttachDevTools();

    if (IsHotReloadEnabled())
      this.AddDisposableHandler(KeyDownEvent, (sender, args) =>
      {
        if (!_hotReloadGesture.Matches(args)) return;
        _contentRender(this);
        this.Log().Info("Refreshed view.");
      });
  }

  /// <summary>
  ///   Set the hot reload gesture.
  ///   The default is Ctrl + R.
  /// </summary>
  /// <param name="gesture"></param>
  /// <returns></returns>
  public HotReloadWindow HotReloadWith(KeyGesture gesture)
  {
    _hotReloadGesture = gesture;
    return this;
  }

  public bool IsProduction()
  {
    // if defined DEBUG or debugger attached, return false
#if DEBUG
    return false;
#else
    return true;
#endif
  }

  public bool IsHotReloadEnabled()
  {
    return !IsProduction() && !Debugger.IsAttached;
  }
}
