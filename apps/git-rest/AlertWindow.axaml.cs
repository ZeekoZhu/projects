using System;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace GitRest;

public partial class AlertWindow : Window
{
  public PixelPoint? OpenDestination { get; set; }

  public AlertWindow()
  {
    InitializeComponent();
    // set semi-transparent background
    Background = new SolidColorBrush(Colors.Black) { Opacity = 0.7 };
    Width = 1;
    Height = 1;
  }

  protected override void OnOpened(EventArgs e)
  {
    Observable.Return(1)
      .Delay(TimeSpan.FromMilliseconds(10))
      .Subscribe(
        _ =>
        {
          Dispatcher.UIThread.InvokeAsync(
            () =>
            {
              if (OpenDestination is not null)
              {
                // move the window to the destination
                Position = OpenDestination.Value;
                // remove the title bar
                ExtendClientAreaToDecorationsHint = true;
                // maximize the window
                WindowState = WindowState.Maximized;
              }
            });
        });
    base.OnOpened(e);
  }
}
