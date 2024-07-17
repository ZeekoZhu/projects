using System.ComponentModel;

namespace Projects.AvaloniaUtils.Signal;

public interface ISignal : INotifyPropertyChanged
{
  /// <summary>
  ///  Value of the signal.
  /// </summary>
  object Value { get; }
}

public interface ISignal<out T> : ISignal, IObservable<T>
{
  new T Value { get; }
}

internal interface INotifyable
{
  /// <summary>
  /// Notify that the value has changed.
  /// </summary>
  void NotifyChanged();
}
