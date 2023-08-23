using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GitRest.Infrastructure;
using GitRest.Service;
using ReactiveUI;
using Splat;

namespace GitRest;

public partial class App : Application, IEnableLocator
{
  private readonly TakeARestManager _takeARestManager;
  private readonly AlertWindowManager _alertWindowManager;

  public App()
  {
    _alertWindowManager = this.GetService<AlertWindowManager>();
    _takeARestManager = this.GetService<TakeARestManager>();
  }

  public IClassicDesktopStyleApplicationLifetime Desktop =>
    (ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!;

  public MainWindow? MainWindow { get; set; }


  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
    _takeARestManager.SetupMonitor();
  }

  public override void OnFrameworkInitializationCompleted()
  {
    // Create the AutoSuspendHelper.
    var suspension = new SuspendHelper(Desktop);
    Locator.CurrentMutable.Register(() => suspension);
    RxApp.SuspensionHost.CreateNewAppState = () => new AppState();
    RxApp.SuspensionHost.SetupDefaultSuspendResume(
      new JsonSuspensionDriver(GetAppStatePath(), typeof(AppState)));
    suspension.OnFrameworkInitializationCompleted();
    base.OnFrameworkInitializationCompleted();
  }

  private string GetAppStatePath()
  {
    // ~/.config/git-rest/state.json
    var configPath = Environment.GetFolderPath(
      Environment.SpecialFolder.ApplicationData);
    var appConfigPath = Path.Combine(configPath, "git-rest");
    if (!Directory.Exists(appConfigPath))
    {
      Directory.CreateDirectory(appConfigPath);
    }

    return Path.Combine(appConfigPath, "state.json");
  }

  private void QuitMenuItem_OnClick(object? sender, EventArgs e)
  {
    // quit the app
    Desktop.Shutdown();
  }

  private void TrayIcon_OnClicked(object? sender, EventArgs e)
  {
    if (MainWindow is null)
    {
      MainWindow = Locator.Current.GetService<MainWindow>()!;
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

  public void OpenAlert()
  {
    // get screen list
    _alertWindowManager.ShowAlert();
  }

  public void CloseAlert()
  {
    _alertWindowManager.CloseAlert();
  }
}
