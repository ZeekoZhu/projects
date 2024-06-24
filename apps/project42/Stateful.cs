using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Projects.Project42;

public class Stateful<T>(T initValue) : INotifyPropertyChanged
{
  protected BehaviorSubject<T> State { get; } = new(initValue);

  /// <summary>
  ///   Current state value
  /// </summary>
  public T Current
  {
    get => State.Value;
    set
    {
      State.OnNext(value);
      OnPropertyChanged();
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  /// <summary>
  ///   Set new state value
  /// </summary>
  /// <param name="newState"></param>
  public void SetState(T newState)
  {
    State.OnNext(newState);
    OnPropertyChanged(nameof(Current));
  }

  /// <summary>
  ///   Set new state value
  /// </summary>
  /// <param name="update"></param>
  public void SetState(Func<T, T> update)
  {
    State.OnNext(update(State.Value));
    OnPropertyChanged(nameof(Current));
  }

  /// <summary>
  ///   Create a new observable by applying a selector function to the current state
  /// </summary>
  /// <param name="selector"></param>
  /// <typeparam name="TResult"></typeparam>
  /// <returns></returns>
  public IObservable<TResult> Select<TResult>(Func<T, TResult> selector)
  {
    return State.Select(selector);
  }

  /// <summary>
  ///   Create a new observable of the current state
  /// </summary>
  /// <returns></returns>
  public IObservable<T> Select()
  {
    return State;
  }

  public IObservable<T> ToObservable()
  {
    return State;
  }

  protected virtual void OnPropertyChanged(
    [CallerMemberName] string? propertyName = null)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}

public static class StatefulObservableExtension
{
  /// <summary>
  ///   Connect an observable to a stateful state
  /// </summary>
  /// <param name="observable">The source observable</param>
  /// <param name="stateful">The state</param>
  /// <param name="update">Function to update the state</param>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="TState"></typeparam>
  /// <returns></returns>
  public static IDisposable Connect<T, TState>(this IObservable<T> observable,
    Stateful<TState> stateful, Func<T, TState, TState> update)
  {
    return observable.Subscribe(it => stateful.SetState(s => update(it, s)));
  }

  /// <summary>
  ///   Create a 2way binding for the stateful object.
  /// </summary>
  /// <param name="stateful"></param>
  /// <param name="mode"></param>
  /// <param name="priority"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static IBinding Binding<T>(this Stateful<T> stateful,
    BindingMode mode = BindingMode.OneWay,
    BindingPriority priority = BindingPriority.LocalValue)
  {
    return new Binding
    {
      Source = stateful,
      Path = nameof(stateful.Current),
      Mode = mode,
      Priority = priority
    };
  }
}
