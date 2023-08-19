using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using GitRest.Service;
using Serilog;

namespace GitRest;

public partial class App : Application
{
  private ILogger Log => Serilog.Log.ForContext<App>();
  private readonly LinuxGitCommandMonitor _commandMonitor = new();

  public bool IsMonitoringGit { get; set; }
  private Subject<bool> MonitoringGitSubject { get; } = new();

  public void StartMonitoringGit()
  {
    if (IsMonitoringGit)
    {
      return;
    }

    MonitoringGitSubject.OnNext(true);
    Observable.FromEventPattern(
        _commandMonitor,
        nameof(_commandMonitor.GitCommandFinished))
      .TakeUntil(MonitoringGitSubject.Where(it => it == false))
      // side effect
      .Do(_ => Log.Information("Git command finished"))
      .Throttle(TimeSpan.FromSeconds(1))
      .Subscribe(
        _ =>
        {
          Dispatcher.UIThread.InvokeAsync(OpenAlert);
        });
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
    MonitoringGitSubject.OnNext(false);
    Log.Information("Stopped monitoring git commands");
    IsMonitoringGit = false;
  }

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

  private AlertManager _alertManager = new();

  public void OpenAlert()
  {
    // get screen list
    _alertManager.ShowAlert();
    Observable.Return(1)
      .Delay(TimeSpan.FromSeconds(15))
      .Subscribe(
        _ =>
        {
          // switch to the avalonia thread
          Dispatcher.UIThread.InvokeAsync(CloseAlert);
        });
  }

  public void CloseAlert()
  {
    _alertManager.CloseAlert();
  }
}
