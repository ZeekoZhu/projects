namespace Projects.AvaloniaUtils.HotReload;

/// <summary>
/// A hot reload window under development.
/// Press Ctrl + R to reload the view.
/// </summary>
public class HotReloadWindow : Window
{
  private readonly Func<Window, object> _contentRender;

  private KeyGesture _hotReloadGesture = new(Key.R, KeyModifiers.Control);

  public HotReloadWindow(Func<Window, object> contentRender)
  {
    _contentRender = contentRender;
    Content = contentRender(this);
  }

  /// <summary>
  /// Set the hot reload gesture.
  /// The default is Ctrl + R.
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

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (IsHotReloadEnabled())
      if (_hotReloadGesture.Matches(e))
      {
        Content = _contentRender(this);
        Console.WriteLine("View reloaded.");
      }

    base.OnKeyDown(e);
  }
}
