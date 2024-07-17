using System.Reactive;
using Nito.Disposables;
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
    IsValid =
      new Computed<bool>(Value.ErrorState.Errors.Select(_ => !Value.HasErrors));
  }

  protected FormFieldOptions<T> Options { get; }

  public StateWithErrors<T> Value { get; }
  public Computed<bool> IsDirty { get; }
  public Computed<bool> IsValid { get; }

  public void ResetField()
  {
    Value.Set(_initValue.Get());
    Value.ErrorState.SetErrors([]);
  }

  public void ResetField(T value)
  {
    Value.Set(value);
    Value.ErrorState.SetErrors([]);
    _initValue.Set(value);
  }
}

public class FormFieldOptions<T> : SignalOptions<T>;

public class FormValidationTrigger
{
  private readonly Subject<Unit> _triggerValidation = new();

  public IObservable<Unit> TriggerValidation => _triggerValidation;

  public void Validate()
  {
    _triggerValidation.OnNext(Unit.Default);
  }

  public IDisposable TriggerOn<T>(IObservable<T> observable)
  {
    return observable.Subscribe(_ => Validate());
  }
}

public interface IFormValidator<in T>
{
  LanguageExt.Validation<string, LanguageExt.Unit> Validate(T value);
}

public static class FormValidators
{
  public static IFormValidator<T> Create<T>(
    Func<T, LanguageExt.Validation<string, LanguageExt.Unit>> validate)
  {
    return new FuncFormValidator<T>(validate);
  }

  public class FuncFormValidator<T>(
    Func<T, LanguageExt.Validation<string, LanguageExt.Unit>> validate)
    : IFormValidator<T>
  {
    public LanguageExt.Validation<string, LanguageExt.Unit> Validate(T value)
    {
      return validate(value);
    }
  }
}

public static class FormFieldExtension
{
  public static IDisposable ValidateOnChange<T>(this FormField<T> field,
    IFormValidator<T> validator, FormValidationTrigger trigger)
  {
    var d = new CollectionDisposable();
    d.Add(
      trigger.TriggerOn(field.Value)
    );
    d.Add(StartValidation(field, validator, trigger));
    return d;
  }

  private static IDisposable StartValidation<T>(FormField<T> field,
    IFormValidator<T> validator, FormValidationTrigger trigger)
  {
    return trigger.TriggerValidation.Subscribe(_ =>
    {
      var result = validator.Validate(field.Value.Get());
      field.Value.ErrorState.SetErrors(result.FailToArray());
    });
  }

  public static IDisposable ValidateOnTrigger<T>(this FormField<T> field,
    IFormValidator<T> validator, FormValidationTrigger trigger)
  {
    var d = new CollectionDisposable();
    d.Add(field.Value.Subscribe(_ =>
    {
      field.Value.ErrorState.SetErrors([]);
    }));
    d.Add(StartValidation(field, validator, trigger));
    return d;
  }
}
