using System.Linq.Expressions;
using System.Reflection;

namespace Projects.Project42;

public class Stateful<T>(T initValue)
{
  protected BehaviorSubject<T> State { get; } = new(initValue);

  /// <summary>
  ///   Current state value
  /// </summary>
  public T Current => State.Value;

  /// <summary>
  ///   Set new state value
  /// </summary>
  /// <param name="newState"></param>
  public void SetState(T newState)
  {
    State.OnNext(newState);
  }

  /// <summary>
  ///   Set new state value
  /// </summary>
  /// <param name="update"></param>
  public void SetState(Func<T, T> update)
  {
    State.OnNext(update(State.Value));
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
}


public static class StatefulObservableExtension
{
  /// <summary>
  /// Connect an observable to a stateful state
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
}
