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
      .RefCount();

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
  object ISignal.Value => Value!;

  public T Value => ComputedValue;

  public IDisposable Subscribe(IObserver<T> observer)
  {
    return Observable.Subscribe(observer);
  }
}
