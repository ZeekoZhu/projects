using System;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GitRest.Service;
using Splat;
using ILogger = Serilog.ILogger;

namespace GitRest;

public partial class App : Application
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
      .Where(
        it => it.ProcessInfo.WorkingDirectory?.Contains(
          "project",
          StringComparison.OrdinalIgnoreCase) ?? true)
      .Where(_ => IsMonitoringGit)
      .Do(_ => Log.Information("Git command finished"))
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

  private void QuitMenuItem_OnClick(object? sender, EventArgs e)
  {
    // quit the app
    Environment.Exit(0);
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
