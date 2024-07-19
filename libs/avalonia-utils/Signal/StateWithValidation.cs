using System.ComponentModel;
using Projects.AvaloniaUtils.Form;

namespace Projects.AvaloniaUtils.Signal;

public class StateWithValidation<T>(
  IWritableSignal<T> signal,
  DataErrors dataErrors) : WritableSignalProxy<T>(signal), INotifyDataErrorInfo
{
  public IEnumerable GetErrors(string? propertyName) =>
    dataErrors.GetErrors(propertyName);

  public bool HasErrors => dataErrors.HasErrors;

  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged
  {
    add => dataErrors.ErrorsChanged += value;
    remove => dataErrors.ErrorsChanged -= value;
  }
}

public static class StateWithValidationExtensions
{
  public static StateWithValidation<T> WithValidation<T>(
    this IWritableSignal<T> signal, DataErrors dataErrors) =>
    new(signal, dataErrors);
}
