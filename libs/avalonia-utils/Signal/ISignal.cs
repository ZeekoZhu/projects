using System.ComponentModel;

namespace Projects.AvaloniaUtils.Signal;

public interface ISignal : INotifyPropertyChanged
{
  /// <summary>
  ///  Value of the signal.
  /// </summary>
  object Get();
}

public interface ISignal<out T> : ISignal, IObservable<T>
{
  T Value { get; }
  new T Get();
}

public interface IWritableSignal<T> : ISignal<T>
{
  new T Value { get; set; }
  void Set(T value);
}
