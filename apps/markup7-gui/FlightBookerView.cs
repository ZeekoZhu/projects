using MsBox.Avalonia;
using Projects.AvaloniaUtils;
using Projects.AvaloniaUtils.Form;
using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;

namespace Projects.Markup7Gui;

public class FlightBookerView : MarkupViewBase<FlightBookerViewModel>
{
  public FlightBookerView()
  {
    ViewModel = new FlightBookerViewModel();
  }

  public override void View()
  {
    void HandleBookClicked(Button sender, RoutedEventArgs args)
    {
      MessageBoxManager.GetMessageBoxStandard("Booked", "Flight booked!")
        .ShowWindowDialogAsync(this.GetTopLevelWindow());
    }

    this
      .Styles(
        Style(x => x.OfType<StackPanel>().Child().Is<Control>())
          .SetLayoutableMargin(Thickness.Parse("0,0,0,10")),
        Style(x => x.OfType<TextBox>())
          .SetLayoutableWidth(200)
          .SetLayoutableHorizontalAlignment(HorizontalAlignment.Left)
      )
      .Content(
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
              .OnClickHandler(HandleBookClicked)
          )
      );
  }
}

public class FlightBookerViewModel : ViewModelBase
{
  private const string DatePattern = "yyyy/MM/dd";
  public readonly FlightType[] Options = Enum.GetValues<FlightType>();

  public readonly State<string> StartDate =
    new(DateTime.Now.ToString(DatePattern));

  public readonly DataErrors StartDateErrors = new();
  public readonly State<string> ReturnDate = new("");
  public readonly DataErrors ReturnDateErrors = new();
  public readonly State<FlightType> Type = new(FlightType.OneWay);

  public readonly IObservable<bool> IsInputValid;

  public FlightBookerViewModel()
  {
    StartDateErrors.SetErrors(StartDate.Select(ValidateDateInput).Skip(1));
    ReturnDateErrors.SetErrors(from returnDate in ReturnDate.Skip(1)
      from flightType in Type
      select flightType == FlightType.Return
        ? ValidateDateInput(returnDate)
        : []);
    IsInputValid =
      from startDateErrors in StartDateErrors
      from returnDateErrors in ReturnDateErrors
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
