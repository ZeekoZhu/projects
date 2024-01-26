using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;

namespace Projects.StatusTray;

public partial class App : Application
{
  public override void Initialize() => AvaloniaXamlLoader.Load(this);


  private void TrayIcon_OnClicked(object? sender, EventArgs e)
  {
    var mainWindow = new MainWindow();
    mainWindow.Show();
  }
}
