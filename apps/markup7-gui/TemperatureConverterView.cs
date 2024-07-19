using System.Reactive;
using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;
using ReactiveUI;
using TextBlock = Avalonia.Controls.TextBlock;
using TextBox = Avalonia.Controls.TextBox;

namespace Projects.Markup7Gui;

public class
  TemperatureConverterView : MarkupViewBase<TemperatureConverterViewModel>
{
  public TemperatureConverterView()
  {
    ViewModel = new TemperatureConverterViewModel();
  }

  public override void View()
  {
    this.Content(
      StackPanel()
        .VerticalAlignmentTop()
        .Height(32)
        .OrientationHorizontal()
        .Styles(
          Style(it => it.OfType<TextBox>())
            .Setter(MarginProperty, new Thickness(0, 0, 10, 0)),
          Style(it => it.OfType<TextBlock>())
            .Setter(VerticalAlignmentProperty,
              VerticalAlignment.Center)
            .Setter(MarginProperty, new Thickness(0, 0, 10, 0))
        )
        .Children(
          TextBox()
            .OnKeyUpHandler((it, _) =>
              Model.UpdateCelsius(it.Text ?? string.Empty))
            .Text(Model.Celsius.Binding()),
          TextBlock()
            .Text("°C"),
          TextBlock()
            .Text("="),
          TextBox()
            .OnKeyUpHandler((it, _) =>
              Model.UpdateFahrenheit(it.Text ?? string.Empty))
            .Text(Model.Fahrenheit.Binding()),
          TextBlock()
            .Text("°F")
        )
    );
  }
}

public class TemperatureConverterViewModel : ViewModelBase
{
  private static decimal CelsiusToFahrenheit(decimal celsius) =>
    celsius * 9m / 5m + 32m;

  private static decimal FahrenheitToCelsius(decimal fahrenheit) =>
    (fahrenheit - 32m) * 5m / 9m;

  public readonly State<string> Celsius = new("0");

  public readonly State<string> Fahrenheit =
    new(CelsiusToFahrenheit(0).ToString("F"));

  public void UpdateCelsius(string val)
  {
    if (decimal.TryParse(val, out var celsius))
      Fahrenheit.Value = CelsiusToFahrenheit(celsius).ToString("F");
  }

  public void UpdateFahrenheit(string val)
  {
    if (decimal.TryParse(val, out var fahrenheit))
      Celsius.Value = FahrenheitToCelsius(fahrenheit).ToString("F");
  }
}
