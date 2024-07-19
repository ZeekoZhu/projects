using System.Linq;
using System.Reactive;
using Projects.AvaloniaUtils.Form;
using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;
using ReactiveUI;

namespace Projects.Markup7Gui;

public class FlightBookerView : MarkupViewBase<FlightBookerViewModel>
{
  public FlightBookerView()
  {
    ViewModel = new FlightBookerViewModel();
  }

  public override void View()
  {
    this.Content(
      StackPanel()
        .VerticalAlignmentTop()
        .OrientationVertical()
        .Children(
          ComboBox()
            .ItemsSource(Model.Options)
            .SelectedItem(Model.Type.Binding())
            .ItemTemplate(
              new FuncDataTemplate<FlightType>((s, _) =>
                TextBlock().Text(s.ToString()))),
          TextBox()
            .Watermark("Start date: yyyy/MM/dd")
            .Text(Model.StartDate.WithValidation(Model.StartDateErrors)
              .Binding()),
          TextBox()
            .Text(Model.ReturnDate.WithValidation(Model.ReturnDateErrors)
              .Binding())
            .IsEnabled(Model.Type.Select(it => it == FlightType.Return))
            .Watermark("Return date: yyyy/MM/dd"),
          Button()
            .Content("Book")
            .IsEnabled(Model.IsInputValid)
            .Command(Model.BookCommand)
        )
    );
  }
}

public class FlightBookerViewModel : ViewModelBase
{
  private const string DatePattern = "yyyy/MM/dd";

  public readonly State<string> StartDate =
    new(DateTime.Now.ToString(DatePattern));

  public readonly DataErrors StartDateErrors = new();
  public readonly State<string> ReturnDate = new("");
  public readonly DataErrors ReturnDateErrors = new();
  public readonly State<FlightType> Type = new(FlightType.OneWay);
  public readonly FlightType[] Options = Enum.GetValues<FlightType>();
  public readonly IObservable<bool> IsInputValid;
  public readonly ReactiveCommand<Unit, Unit> BookCommand;

  public FlightBookerViewModel()
  {
    BookCommand =
      ReactiveCommand.Create(() => { Console.WriteLine("Booked!"); });

    StartDateErrors.SetErrors(StartDate.Select(ValidateDateInput).Skip(1));
    ReturnDateErrors.SetErrors(from returnDate in ReturnDate.Skip(1)
      from flightType in Type
      select flightType == FlightType.Return
        ? ValidateDateInput(returnDate)
        : []);
    IsInputValid =
      from startDateErrors in StartDateErrors.ObserveMessages()
      from returnDateErrors in ReturnDateErrors.ObserveMessages()
      select startDateErrors.Length == 0 && returnDateErrors.Length == 0;
  }

  public static string[] ValidateDateInput(string input) =>
    DateOnly.TryParseExact(input, DatePattern, out _)
      ? []
      : ["Invalid date format, expected yyyy/MM/dd"];
}

public enum FlightType
{
  OneWay,
  Return
}
