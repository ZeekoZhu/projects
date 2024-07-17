using System.ComponentModel;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Form;

public class StateWithErrors<T> : State<T>, INotifyDataErrorInfo
{
  public StateWithErrors(T value, SignalOptions<T>? options = null) : base(
    value, options)
  {
    ErrorState.ErrorsChanged += (_, _) =>
      ErrorsChanged?.Invoke(this,
        new DataErrorsChangedEventArgs(nameof(Value)));
  }

  public ErrorState ErrorState { get; } = new();

  public IEnumerable GetErrors(string? propertyName)
  {
    return ErrorState.GetErrors(propertyName);
  }

  public bool HasErrors => ErrorState.HasErrors;
  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
