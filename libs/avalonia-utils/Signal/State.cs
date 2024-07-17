using System.ComponentModel;

namespace Projects.AvaloniaUtils.Signal;

public class State<T>(T value, SignalOptions<T>? options = null)
  : ISignal<T>, INotifyable
{
  protected readonly SignalOptions<T> Options =
    options ?? new SignalOptions<T>();

  protected T CurrentValue = value;

  /// <summary>
  /// Notify that the value has changed.
  /// </summary>
  public virtual void NotifyChanged()
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
  }

  object ISignal.Value => Value!;

  /// <summary>
  /// The observable value.
  /// </summary>
  public T Value
  {
    get => CurrentValue;
    set
    {
      if (Options.Equal.Equals(CurrentValue, value)) return;
      CurrentValue = value;
      NotifyChanged();
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public IDisposable Subscribe(IObserver<T> observer)
  {
    return Observable
      .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
        h => PropertyChanged += h,
        h => PropertyChanged -= h)
      .Select(_ => Value)
      .StartWith(Value)
      .Subscribe(observer);
  }
}
