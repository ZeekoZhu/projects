namespace Projects.AvaloniaUtils;

public static class TopLevelExtensions
{
  /// <summary>
  /// Get the top-level window for the control.
  /// </summary>
  /// <param name="control"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public static Window GetTopLevelWindow(this Control control)
  {
    var parent = control.GetVisualRoot();
    return parent switch
    {
      Window topLevel => topLevel,
      _ => throw new ArgumentOutOfRangeException(nameof(parent))
    };
  }
}
