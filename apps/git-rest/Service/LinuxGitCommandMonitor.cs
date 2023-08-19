using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using Serilog;

namespace GitRest.Service;

public class LinuxGitCommandMonitor : IDisposable
{
  private readonly GitCommandParser _parser = new();

  private readonly FileSystemWatcher _watcher;
  private ILogger Log => Serilog.Log.ForContext<LinuxGitCommandMonitor>();

  public LinuxGitCommandMonitor()
  {
    var userHome = Environment.GetEnvironmentVariable("HOME");
    Debug.Assert(userHome != null, nameof(userHome) + " != null");
    _watcher = new FileSystemWatcher(userHome);
    var gitconfig = ".gitconfig";
    _watcher.Filter = gitconfig;
    _watcher.NotifyFilter = NotifyFilters.LastAccess;
    _watcher.Changed += OnWatcherOnChanged;
    Log.Debug("Initialized with {Home} {Filter}", userHome, gitconfig);
  }

  public void Dispose()
  {
    _watcher.EnableRaisingEvents = false;
    _watcher.Dispose();
  }

  public event EventHandler<GitCommandEventArgs>? GitCommandStarted;

  public event EventHandler<GitCommandEventArgs>? GitCommandFinished;

  public void Start()
  {
    _watcher.EnableRaisingEvents = true;
  }

  private async void OnWatcherOnChanged(
    object sender,
    FileSystemEventArgs args)
  {
    var gitProc = Process.GetProcesses()
      .FirstOrDefault(p => _parser.IsGitCommand(p.ProcessName));

    if (gitProc == null)
    {
      // the git command has finished, ignore this event
      return;
    }

    Log.Debug("Git command started: {Pid}", gitProc.Id);

    var gitCmd = _parser.Parse(await ResolveCommandlineByPid(gitProc.Id));
    var commandEventArgs = new GitCommandEventArgs(
      gitCmd.IsGitCommit,
      gitCmd.IsGitPush);
    GitCommandStarted?.Invoke(this, commandEventArgs);

    if (gitProc.HasExited)
    {
      GitCommandFinished?.Invoke(this, commandEventArgs);
    }
    else
    {
      gitProc.Exited += (o, eventArgs) =>
      {
        GitCommandFinished?.Invoke(this, commandEventArgs);
      };
      gitProc.EnableRaisingEvents = true;
    }
  }


  private static async Task<string> ResolveCommandlineByPid(int pid)
  {
    var psCmd = Cli.Wrap("ps")
      .WithArguments(new[] { "-p", pid.ToString(), "-o", "cmd=" });
    var psInfo = await psCmd.ExecuteBufferedAsync();
    var commandline = psInfo.StandardOutput;
    Serilog.Log.ForContext<LinuxGitCommandMonitor>().Debug("ps output: {Output}", commandline);
    return commandline;
  }

  public void Stop()
  {
    _watcher.EnableRaisingEvents = false;
  }

  public class GitCommandEventArgs
  {
    public GitCommandEventArgs(bool isGitCommit, bool isGitPush)
    {
      IsGitCommit = isGitCommit;
      IsGitPush = isGitPush;
    }

    public bool IsGitCommit { get; }
    public bool IsGitPush { get; }
  }
}
