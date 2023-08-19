using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GitRest;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
  }

  protected override void OnClosing(WindowClosingEventArgs e)
  {
    e.Cancel = true;
    base.OnClosing(e);
    Hide();
  }

  private App App => (App)Application.Current!;

  private void ToggleBtn_OnClick(object? sender, RoutedEventArgs e)
  {
    var btn = (Button)sender!;
    if (App.IsMonitoringGit)
    {
      App.StopMonitoringGit();
      btn.Content = "Start";
    }
    else
    {
      App.StartMonitoringGit();
      btn.Content = "Stop";
    }
  }

  private void AlertButton_OnClick(object? sender, RoutedEventArgs e)
  {
    App.OpenAlert();
  }

  private void MoveToScreen1_OnClick(object? sender, RoutedEventArgs e)
  {
    var screen = Screens.All[0];
    Position = screen.WorkingArea.Center;
  }

  private void MoveToScreen2_OnClick(object? sender, RoutedEventArgs e)
  {
    var screen = Screens.All[1];
    Position = screen.WorkingArea.Center;
  }
}
