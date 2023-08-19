using Avalonia.Controls;
using Avalonia.Media;

namespace GitRest;

public partial class AlertWindow : Window
{
  public AlertWindow()
  {
    InitializeComponent();
    // set semi-transparent background
    Background = new SolidColorBrush(Colors.Black) { Opacity = 0.7 };
    // remove the title bar
    ExtendClientAreaToDecorationsHint = true;
    // maximize the window
    WindowState = WindowState.Maximized;
  }
}
