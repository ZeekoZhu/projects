using System.ComponentModel;

namespace Projects.AvaloniaUtils.Signal
{
  public class State<T>(T value, SignalOptions<T>? options = null)
    : IWritableSignal<T>
  {
    protected readonly SignalOptions<T> Options =
      options ?? new SignalOptions<T>();

    protected T CurrentValue = value;

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

    public T Get()
    {
      return Value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    object ISignal.Get()
    {
      return Get()!;
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
      return Observable
        .FromEventPattern<PropertyChangedEventHandler,
          PropertyChangedEventArgs>(
          h => PropertyChanged += h,
          h => PropertyChanged -= h)
        .Select(_ => Value)
        .StartWith(Value)
        .Subscribe(observer);
    }

    public void Set(T value)
    {
      Value = value;
    }

    /// <summary>
    /// Notify that the value has changed.
    /// </summary>
    public virtual void NotifyChanged()
    {
      PropertyChanged?.Invoke(this,
        new PropertyChangedEventArgs(nameof(Value)));
    }
  }
}
