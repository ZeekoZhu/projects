using System;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using Splat;

namespace GitRest.Service;

public class TakeARestManager : ReactiveObject, IEnableLocator
{
  private readonly GitMonitorOptions _gitMonitorOptions;
  private TimeSpan _duration = TimeSpan.FromMinutes(45);

  public TimeSpan Duration
  {
    get => _duration;
    set
    {
      _duration = value;
      LastRestTime = DateTime.Now;
    }
  }

  public DateTime LastRestTime { get; private set; } = DateTime.Now;

  [Reactive]
  public bool IsRunning { get; set; }


  [ObservableAsProperty]
  public TimeSpan Elapsed { get; }

  public event EventHandler<TakeARestEventArgs>? ShouldRest;

  public TakeARestManager()
  {
    _gitMonitorOptions = this.GetService<GitMonitorOptions>();
    // elapsed time
    this.WhenAnyValue(vm => vm.IsRunning)
      .Select(
        it =>
        {
          switch (it)
          {
            case false:
              return Observable.Return(TimeSpan.Zero);
            default:
            {
              var elapsedSeconds = (DateTime.Now - LastRestTime)
                .TotalSeconds;
              return Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(n => TimeSpan.FromSeconds(elapsedSeconds + n + 1));
            }
          }
        })
      .Switch()
      .ToPropertyEx(this, x => x.Elapsed);
  }

  private bool ShouldIgnoreGitActivity(SimpleProcessInfo proc)
  {
    if (proc.WorkingDirectory is null)
    {
      this.Log()
        .Warn(
          "Unable to determine working directory of {Cmd}",
          proc.CommandLine);
      return true;
    }

    StringComparison comparison = PlatformHelper.IsWindows()
      ? StringComparison.CurrentCultureIgnoreCase
      : StringComparison.Ordinal;

    var shouldIgnoreGitActivity = _gitMonitorOptions.IgnoreDirectory.Any(
      path => proc.WorkingDirectory.StartsWith(path, comparison));
    if (shouldIgnoreGitActivity)
    {
      this.Log().Debug("Ignore git activity in {Path}", proc.WorkingDirectory);
    }

    return shouldIgnoreGitActivity;
  }

  public void SetupMonitor()
  {
    var commandMonitor = this.GetService<LinuxGitCommandMonitor>();
    var alertWindowManager = this.GetService<AlertWindowManager>();
    ShouldRest += (_, args) =>
    {
      this.Log()
        .Info(
          "Should rest, you have been working {Duration}",
          args.Duration);
      alertWindowManager.ShowAlert();
    };
    Observable.FromEventPattern(
        commandMonitor,
        nameof(commandMonitor.GitCommandFinished))
      .Where(
        it => it.EventArgs is GitCommandEventArgs)
      .Select(it => (GitCommandEventArgs)it.EventArgs)
      .Where(_ => IsRunning)
      .Where(it => !ShouldIgnoreGitActivity(it.ProcessInfo))
      .Where(it => it.IsGitCommit || it.IsGitPush)
      .Do(_ => Log.Information("Git commit/push finished"))
      .Throttle(TimeSpan.FromSeconds(15))
      .Subscribe(
        _ =>
        {
          SuggestARest();
        });
  }

  public void SuggestARest()
  {
    // ignore if last rest time is too close
    if (DateTime.Now - LastRestTime < Duration)
    {
      return;
    }

    var duration = DateTime.Now - LastRestTime;
    LastRestTime = DateTime.Now;
    ShouldRest?.Invoke(this, new TakeARestEventArgs(duration));
  }

  public void Start()
  {
    LastRestTime = DateTime.Now;
    if (IsRunning)
    {
      return;
    }

    var commandMonitor = this.GetService<LinuxGitCommandMonitor>();
    commandMonitor.Start();
    IsRunning = true;
  }

  public void Stop()
  {
    if (!IsRunning)
    {
      return;
    }

    var commandMonitor = this.GetService<LinuxGitCommandMonitor>();
    commandMonitor.Stop();
    IsRunning = false;
  }

  public record TakeARestEventArgs(TimeSpan Duration);
}
