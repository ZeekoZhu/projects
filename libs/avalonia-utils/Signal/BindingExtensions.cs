namespace Projects.AvaloniaUtils.Signal;

public static class BindingExtensions
{
  public static IBinding Binding<T>(this IWritableSignal<T> signal,
    BindingMode mode = BindingMode.TwoWay,
    BindingPriority priority = BindingPriority.LocalValue)
  {
    return new Binding
    {
      Mode = mode,
      Priority = priority,
      Path = nameof(IWritableSignal<T>.Value),
      Source = signal
    };
  }

  public static IBinding Binding<T>(this ISignal<T> signal,
    BindingMode mode = BindingMode.OneWay,
    BindingPriority priority = BindingPriority.LocalValue)
  {
    return new Binding
    {
      Mode = mode,
      Priority = priority,
      Path = nameof(ISignal<T>.Value),
      Source = signal
    };
  }
}
