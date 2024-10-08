using System.ComponentModel;
using System.Reactive.Concurrency;
using LanguageExt.TypeClasses;

namespace Projects.AvaloniaUtils.Signal;

public class Computed<T> : ISignal<T>, IDisposable
{
  private readonly IDisposable? _computation;
  protected readonly IObservable<T> Observable;
  protected T ComputedValue = default!;

  public Computed(IObservable<T> observable, SignalOptions<T>? options = null)
  {
    Options = options ?? new SignalOptions<T>();
    Observable = observable
      .DistinctUntilChanged(Options.Equal.ToEqualityComparer())
      .Replay(1)
      .RefCount(2);

    _computation =
      Observable.SubscribeOn(CurrentThreadScheduler.Instance).Subscribe(OnNext);
    return;

    void OnNext(T val)
    {
      ComputedValue = val;
      PropertyChanged?.Invoke(this,
        new PropertyChangedEventArgs(nameof(Value)));
    }
  }

  protected SignalOptions<T> Options { get; }


  public void Dispose()
  {
    _computation?.Dispose();
  }

  public event PropertyChangedEventHandler? PropertyChanged;
  object ISignal.Get()
  {
    return Get()!;
  }

  /// <summary>
  /// Get the value of the signal.
  /// </summary>
  /// <remarks>
  /// The computed must be subscribed to before accessing the value.
  /// </remarks>
  public T Get()
  {
    return Value;
  }

  /// <summary>
  /// Get the value of the signal.
  /// </summary>
  /// <remarks>
  /// The computed must be subscribed to before accessing the value.
  /// </remarks>
  public T Value => ComputedValue;

  public IDisposable Subscribe(IObserver<T> observer)
  {
    return Observable.Subscribe(observer);
  }
}
