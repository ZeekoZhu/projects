using System.ComponentModel;

namespace Projects.AvaloniaUtils.Signal;

public abstract class WritableSignalProxy<T>(IWritableSignal<T> signal)
  : IWritableSignal<T>
{
  protected readonly IWritableSignal<T> Signal = signal;

  public T Value
  {
    get => Signal.Value;
    set => Signal.Value = value;
  }

  public T Get() => Signal.Get();
  public void Set(T value) => Signal.Set(value);

  public IDisposable Subscribe(IObserver<T> observer) =>
    Signal.Subscribe(observer);

  private readonly Dictionary<PropertyChangedEventHandler,
      PropertyChangedEventHandler>
    _handlers = new();

  public event PropertyChangedEventHandler? PropertyChanged
  {
    add
    {
      if (value is null) return;
      if (_handlers.ContainsKey(value)) return;
      PropertyChangedEventHandler handler = (_, _) =>
        value(this, new PropertyChangedEventArgs(nameof(Value)));
      _handlers[value] = handler;
      Signal.PropertyChanged += handler;
    }

    remove
    {
      if (value is null) return;
      if (!_handlers.Remove(value, out var handler)) return;
      Signal.PropertyChanged -= handler;
    }
  }

  object ISignal.Get()
  {
    return Get()!;
  }
}
