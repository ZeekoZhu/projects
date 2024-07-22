using System.ComponentModel;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Form;

public class DataErrors: IObservable<string[]>
{
  private readonly IWritableSignal<string[]> _messages = new State<string[]>([]);

  public ISignal<string[]> Messages => _messages;

  public bool HasErrors => Messages.Get().Length != 0;


  public IEnumerable GetErrors(string? propertyName)
  {
    return Messages.Get();
  }

  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

  public void SetErrors(IEnumerable<string> errors)
  {
    _messages.Set(errors.ToArray());
    ErrorsChanged?.Invoke(this,
      new DataErrorsChangedEventArgs(null));
  }

  public IDisposable Subscribe(IObserver<string[]> observer) => _messages.Subscribe(observer);
}

public static class DataErrorsExtensions
{
  public static void SetErrors(this DataErrors dataErrors, IObservable<IEnumerable<string>> errors)
  {
    errors.Subscribe(dataErrors.SetErrors);
  }
}
