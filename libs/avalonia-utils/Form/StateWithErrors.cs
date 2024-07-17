using System.ComponentModel;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Form;

public class StateWithErrors<T> : State<T>, INotifyDataErrorInfo
{
  public StateWithErrors(T value, SignalOptions<T>? options = null) : base(
    value, options)
  {
    Errors.ErrorsChanged += (_, _) =>
      ErrorsChanged?.Invoke(this,
        new DataErrorsChangedEventArgs(nameof(Value)));
  }

  public ErrorState Errors { get; } = new();

  public IEnumerable GetErrors(string? propertyName)
  {
    return Errors.GetErrors(propertyName);
  }

  public bool HasErrors => Errors.HasErrors;
  public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
