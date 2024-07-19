using Projects.AvaloniaUtils.Markup;
using static Projects.Markup7Gui.MarkupBuilder;

namespace Projects.Markup7Gui;

public class MainWindow : MarkupWindowBase<MainWindowViewModel>
{
  public MainWindow()
  {
    ViewModel = new MainWindowViewModel();
  }

  public override void View()
  {
    this.Height(600)
      .Width(800)
      .WindowStartupLocation(WindowStartupLocation.CenterScreen)
      .Title("Markup7 GUI")
      .Content(
        TabControl()
          .ItemsSource(
            TabItem()
              .Header("Counter")
              .Content(
                CounterView()
              ),
            TabItem()
              .Header("Temperature Converter")
              .Content(
                TemperatureConverterView()
              ),
            TabItem()
              .Header("Flight Booker")
              .Content(
                FlightBookerView()
              )
          )
      );
  }
}

public class MainWindowViewModel : ViewModelBase;
