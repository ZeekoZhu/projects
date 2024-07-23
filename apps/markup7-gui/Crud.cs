using System.Linq;
using DynamicData;
using LanguageExt;
using NanoidDotNet;
using Projects.AvaloniaUtils.Form;
using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;
using Projects.AvaloniaUtils.Styling;
using ReactiveUI;
using static Projects.AvaloniaUtils.Styling.StyleBuilder;
using Unit = System.Reactive.Unit;

namespace Projects.Markup7Gui;

public class CrudView : MarkupViewBase<CrudViewModel>
{
  public CrudView()
  {
    ViewModel = new CrudViewModel();
  }

  public override void View()
  {
    Model.Names.Connect()
      .Filter(Model.Filter.Select<string, Func<CrudViewModel.NameRecord, bool>>(
        term =>
          record =>
            string.IsNullOrEmpty(term) || record.Surname.StartsWith(term)))
      .Bind(out var nameList)
      .Subscribe();
    this
      .Styles(
        StyleFor<Panel>(out var panelStyle)
          .Margin(t => t.Bottom(8)),
        StyleFor<TextBox>(out var sFilterField)
          .Width(120),
        StyleFor<TextBlock>(out var labelStyle)
          .Margin(t => t.Right(8))
          .VerticalCenter(),
        StyleFor<TextBlock>(out var formLabelStyle)
          .Margin(t => t.Right(8).Top(8))
          .VerticalTop()
          .HorizontalRight(),
        StyleFor<TextBox>(out var sFromField)
          .Margin(m => m.Bottom(8))
          .VerticalTop()
          .Width(220),
        StyleFor<ListBox>(out var sNameList)
          .Margin(m => m.Right(16).Bottom(8)),
        StyleFor<Button>(out var mutationButton)
          .Margin(m => m.Right(8))
      )
      .Content(
        StackPanel()
          .VerticalAlignmentTop()
          .OrientationVertical()
          .Children(
            StackPanel()
              .OrientationHorizontal()
              .Classes(panelStyle)
              .Children(
                TextBlock()
                  .Classes(labelStyle)
                  .Text("Filter prefix:"),
                TextBox()
                  .Text(Model.Filter.Binding())
                  .Classes(sFilterField)
              ),
            Grid()
              .Classes(panelStyle)
              .RowDefinitions("auto")
              .ColumnDefinitions("*,*")
              .Children(
                ScrollViewer()
                  .Height(300d)
                  .Content(
                    ListBox()
                      .Classes(sNameList)
                      .ItemsSource(nameList)
                      .SelectedItem(Model.Selected.Binding())
                      .DataTemplates(
                        new FuncDataTemplate<CrudViewModel.NameRecord>(
                          (record, _) =>
                            TextBlock()
                              .Text($"{record.Name} {record.Surname}")))
                  ),
                Grid()
                  .Grid(1)
                  .RowDefinitions("auto,auto")
                  .ColumnDefinitions("auto,auto")
                  .Children(
                    TextBlock()
                      .Classes(formLabelStyle)
                      .Text("Name:")
                      .Grid(),
                    TextBox()
                      .Classes(sFromField)
                      .Text(Model.Name.WithValidation(Model.NameErrors)
                        .Binding())
                      .Grid(1),
                    TextBlock()
                      .Classes(formLabelStyle)
                      .Text("Surname:")
                      .Grid(0, 1),
                    TextBox()
                      .Grid(1, 1)
                      .Classes(sFromField)
                      .Text(Model.Surname.WithValidation(Model.SurnameErrors)
                        .Binding())
                  )
              ),
            StackPanel()
              .Classes(panelStyle)
              .OrientationHorizontal()
              .Children(
                Button()
                  .Classes(mutationButton)
                  .Command(Model.Create)
                  .CommandParameter(Model.CreateParams.ToBinding())
                  .Content("Create"),
                Button()
                  .Classes(mutationButton)
                  .Command(Model.Update)
                  .CommandParameter(Model.UpdateParams.ToBinding())
                  .Content("Update"),
                Button()
                  .Classes(mutationButton)
                  .Command(Model.Delete)
                  .CommandParameter(Model.UpdateParams.ToBinding())
                  .Content("Delete")
              )
          )
      );
  }
}

public class CrudViewModel : ViewModelBase
{
  public record NameRecord(string Name, string Surname)
  {
    public string Id { get; private init; } = Nanoid.Generate();

    public NameRecord Update(string name, string surname) =>
      new(name, surname) { Id = Id };
  }

  public SourceCache<NameRecord, string> Names = new(it => it.Id);

  public readonly State<string> Filter = new("");
  public readonly State<string> Name = new("");
  public readonly DataErrors NameErrors = new();
  public readonly State<string> Surname = new("");
  public readonly DataErrors SurnameErrors = new();
  public readonly State<NameRecord?> Selected = new(null);

  public ReactiveCommand<Option<NameRecord>, Unit> Create;
  public IObservable<Option<NameRecord>> CreateParams;
  public ReactiveCommand<Option<NameRecord>, Unit> Update;
  public IObservable<Option<NameRecord>> UpdateParams;
  public ReactiveCommand<Option<NameRecord>,Unit> Delete;

  public CrudViewModel()
  {
    var inputNameRecord = from name in Name
      from surname in Surname
      select TryToNameRecord(name, surname);
    CreateParams = inputNameRecord;
    Create = ReactiveCommand.Create<Option<NameRecord>>(name =>
      {
        name.IfSome(it =>
        {
          Names.AddOrUpdate(it);
          ResetFormFields(Option<NameRecord>.None);
        });
      }, inputNameRecord.Select(it => it.IsSome)
    );

    var selection = Selected.Select(Prelude.Optional);

    selection.Subscribe(selected =>
    {
      selected.IfSome(it =>
      {
        Name.Value = it.Name;
        Surname.Value = it.Surname;
      });
    });

    UpdateParams = from index in selection
      from record in inputNameRecord
      select ToUpdateRecord(record, index);

    Update = ReactiveCommand.Create<Option<NameRecord>>(update =>
    {
      update.IfSome(item =>
      {
        Names.AddOrUpdate(item);
        ResetFormFields(Option<NameRecord>.None);
      });
    }, UpdateParams.Select(it => it.IsSome));

    Delete = ReactiveCommand.Create<Option<NameRecord>>(delete =>
    {
      delete.IfSome(it =>
      {
        Names.Remove(it.Id);
        ResetFormFields(Option<NameRecord>.None);
        Selected.Value = null;
      });
    }, selection.Select(it => it.IsSome));


    NameErrors.SetErrors(Name.Skip(1).Select(ValidateName));
    SurnameErrors.SetErrors(Surname.Skip(1).Select(ValidateName));
  }

  private void ResetFormFields(Option<NameRecord> record)
  {
    Name.Value = record.Map(it => it.Name).IfNone("");
    Surname.Value = record.Map(it => it.Surname).IfNone("");
    NameErrors.SetErrors([]);
    SurnameErrors.SetErrors([]);
  }

  private Option<NameRecord> ToUpdateRecord(Option<NameRecord> inputRecord,
    Option<NameRecord> selected)
  {
    return from i in inputRecord
      from s in selected
      select s.Update(i.Name, i.Surname);
  }

  private Option<NameRecord> TryToNameRecord(string name, string surname)
  {
    var nameErrors = ValidateName(name);
    var surnameErrors = ValidateName(surname);
    if (nameErrors.Any() || surnameErrors.Any())
    {
      return Option<NameRecord>.None;
    }

    return new NameRecord(name, surname);
  }

  private IEnumerable<string> ValidateName(string name)
  {
    return string.IsNullOrEmpty(name)
      ? ["Name cannot be empty"]
      : Array.Empty<string>();
  }
}
