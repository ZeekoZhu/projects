using Projects.AvaloniaUtils.Form;
using Projects.AvaloniaUtils.Signal;
using Projects.Project42.Markup;
using ReactiveUI;
using Splat;
using Unit = System.Reactive.Unit;

namespace Projects.Project42.Dashboard;

public class
  ShellCommandConfigWindow : MarkupWindowBase<ShellCommandConfigWindowViewModel>
{
  public ShellCommandConfigWindow(ShellCommandConfig config)
  {
    ViewModel = new ShellCommandConfigWindowViewModel(config);
  }

  public override void View()
  {
    this
      .Width(600)
      .Height(400)
      .Content(
        Grid()
          .ColumnDefinitions(ColumnDefinitions.Parse("200, *"))
          .RowDefinitions(RowDefinitions.Parse("Auto, Auto"))
          .Children(
            TextBlock()
              .Column(0)
              .Row(0)
              .Text("Name"),
            TextBox()
              .Column(1)
              .Row(0)
              .Text(Model.Form.Name.Value.Binding()),
            TextBlock()
              .Row(1)
              .Column(0)
              .Text(Model.Form.Name.Value.Binding(BindingMode.OneWay)),
            StackPanel()
              .OrientationHorizontal()
              .Row(1)
              .Column(1)
              .Children(
                Button()
                  .Content("Reset")
                  .Command(Model.Form.ResetForm),
                Button()
                  .Content("Save")
                  .Command(Model.Form.SaveForm)
              )
          )
      );
    Model.Form.Name.ValidateOnTrigger(
      FormValidators.Create<string>(Model.Form.NameValidation),
      Model.Form.Validation);
  }
}

public class ShellCommandConfigWindowViewModel(
  ShellCommandConfig config) : ViewModelBase
{
  public ShellCommandConfigFormModel Form { get; } = new(config);
}

public class ShellCommandConfigFormModel : IEnableLogger
{
  public readonly ReactiveCommand<Unit, Unit> ResetForm;
  public readonly ReactiveCommand<Unit, Unit> SaveForm;
  public readonly FormValidationTrigger Validation = new();

  public FormValidation NameValidation(string it) =>
    it switch
    {
      "ddd" => "Name cannot be ddd",
      not null when string.IsNullOrWhiteSpace(it) => "Name is required",
      _ => FormValidation.Success(LUnit.Default)
    };

  public ShellCommandConfigFormModel(ShellCommandConfig initial)
  {
    Name = new(initial.Name);
    Script = new(initial.Script);
    Shell = new(initial.Shell);
    ShellOption = new(initial.ShellOption);


    ResetForm = ReactiveCommand.Create(() =>
    {
      Name.ResetField();
      Script.ResetField();
      Shell.ResetField();
      ShellOption.ResetField();
    });

    SaveForm = ReactiveCommand.Create(() =>
      {
        Validation.Validate();
        if (!Name.IsValid.Get())
        {
          this.Log().Info("Form is not valid");
          return;
        }

        Name.ResetField(Name.Value.Get());
        this.Log().Info("Save Form");
      },
      from valid in Name.IsValid
      from dirty in Name.IsDirty
      select valid && dirty);
  }

  public FormField<string> Name { get; }
  public FormField<string> Script { get; }
  public FormField<string> Shell { get; }
  public FormField<string> ShellOption { get; }
}
