using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace GitRest;

public partial class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public IClassicDesktopStyleApplicationLifetime Desktop =>
    (ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!;

  public MainWindow? MainWindow { get; set; }

  private void QuitMenuItem_OnClick(object? sender, EventArgs e)
  {
    // quit the app
    Environment.Exit(0);
  }

  private void TrayIcon_OnClicked(object? sender, EventArgs e)
  {
    if (MainWindow is null)
    {
      MainWindow = new MainWindow();
      Desktop.MainWindow = MainWindow;
      MainWindow.Show();
    }
    else
    {
      // toggle the window visibility
      if (MainWindow.IsVisible)
      {
        MainWindow.Hide();
      }
      else
      {
        MainWindow.Show();
      }
    }
  }
}
