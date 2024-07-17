using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Form;

public class FormField<T>
{
  private readonly IWritableSignal<T> _initValue;

  public FormField(T value, FormFieldOptions<T>? options = null)
  {
    Options = options ?? new FormFieldOptions<T>();
    _initValue = new State<T>(value);
    Value = new StateWithErrors<T>(value);
    IsDirty = new Computed<bool>(from init in _initValue
      from field in Value
      select !Options.Equal.Equals(init, field));
    IsValid = new Computed<bool>(Value.Select(_ => !Value.HasErrors));
  }

  protected FormFieldOptions<T> Options { get; }

  public StateWithErrors<T> Value { get; }
  public Computed<bool> IsDirty { get; }
  public Computed<bool> IsValid { get; }

  public void ResetField()
  {
    Value.Set(_initValue.Get());
    Value.Errors.SetErrors([]);
  }

  public void ResetField(T value)
  {
    Value.Set(value);
    Value.Errors.SetErrors([]);
    _initValue.Set(value);
  }
}

public class FormFieldOptions<T> : SignalOptions<T>
{}

public static class FormFieldExtension
{
  public static IDisposable ValidationRule<T>(this FormField<T> field,
    IObservable<LanguageExt.Validation<string, LanguageExt.Unit>> errors)
  {
    return
      errors.Skip(1)
        .Subscribe(it =>
        {
          Console.WriteLine($"Errors: {it}");
          field.Value.Errors.SetErrors(it.FailToArray());
        });
  }
}
