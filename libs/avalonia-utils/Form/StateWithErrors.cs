using System.ComponentModel;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Form;

public class StateWithErrors<T> : State<T>, INotifyDataErrorInfo
{
  public StateWithErrors(T value, SignalOptions<T>? options = null) : base(
    value, options)
  {
    DataErrors.ErrorsChanged += (_, _) =>
      ErrorsChanged?.Invoke(this,
        new DataErrorsChangedEventArgs(nameof(Value)));
  }

  public DataErrors DataErrors { get; } = new();

  public IEnumerable GetErrors(string? propertyName)
  {
    return DataErrors.GetErrors(propertyName);
  }

  public bool HasErrors => DataErrors.HasErrors;
  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
