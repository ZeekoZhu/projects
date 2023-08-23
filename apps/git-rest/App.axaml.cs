using System;
using System.IO;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GitRest.Infrastructure;
using GitRest.Service;
using ReactiveUI;
using Splat;
using ILogger = Serilog.ILogger;

namespace GitRest;

public partial class App : Application, IEnableLocator
{
  private readonly LinuxGitCommandMonitor _commandMonitor = new();
  private readonly TakeARestManager _takeARestManager = new();
  private readonly AlertWindowManager _alertWindowManager = new();
  private ILogger Log => Serilog.Log.ForContext<App>();

  public bool IsMonitoringGit { get; set; }

  public IClassicDesktopStyleApplicationLifetime Desktop =>
    (ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!;

  public MainWindow? MainWindow { get; set; }

  private void SetupMonitor()
  {
    _takeARestManager.ShouldRest += (sender, args) =>
    {
      Log.Information(
        "Should rest, you have been working {Duration}",
        args.Duration);
      OpenAlert();
    };
    Observable.FromEventPattern(
        _commandMonitor,
        nameof(_commandMonitor.GitCommandFinished))
      .Where(
        it => it.EventArgs is GitCommandEventArgs)
      .Select(it => (GitCommandEventArgs)it.EventArgs)
      .Where(_ => IsMonitoringGit)
      .Where(
        // todo: add ignore list
        it => it.ProcessInfo.WorkingDirectory?.Contains(
          "project",
          StringComparison.OrdinalIgnoreCase) ?? true)
      .Where(it => it.IsGitCommit || it.IsGitPush)
      .Do(_ => Log.Information("Git commit/push finished"))
      .Throttle(TimeSpan.FromSeconds(15))
      .Subscribe(
        _ =>
        {
          _takeARestManager.SuggestARest();
        });
  }

  public void StartMonitoringGit()
  {
    if (IsMonitoringGit)
    {
      return;
    }

    Log.Information("Started monitoring git commands");
    _commandMonitor.Start();
    IsMonitoringGit = true;
  }

  public void StopMonitoringGit()
  {
    if (!IsMonitoringGit)
    {
      return;
    }

    _commandMonitor.Stop();
    Log.Information("Stopped monitoring git commands");
    IsMonitoringGit = false;
  }

  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
    SetupMonitor();
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
