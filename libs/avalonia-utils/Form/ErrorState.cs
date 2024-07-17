using System.ComponentModel;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Form;

public class ErrorState
{
  private readonly IWritableSignal<string[]> _errors = new State<string[]>([]);

  public ISignal<string[]> Errors => _errors;

  public bool HasErrors => Errors.Get().Length != 0;


  public IEnumerable GetErrors(string? propertyName)
  {
    return Errors.Get();
  }

  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

  public void SetErrors(IEnumerable<string> errors)
  {
    _errors.Set(errors.ToArray());
    ErrorsChanged?.Invoke(this,
      new DataErrorsChangedEventArgs(null));
  }
}
