using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Splat;

namespace GitRest.Service;

public class LinuxGitCommandMonitor : IDisposable, IEnableLogger
{
  private readonly GitCommandParser _parser = new();

  private readonly FileSystemWatcher _watcher;

  public LinuxGitCommandMonitor()
  {
    var userHome = Environment.GetEnvironmentVariable("HOME");
    Debug.Assert(userHome != null, nameof(userHome) + " != null");
    _watcher = new FileSystemWatcher(userHome);
    var gitconfig = ".gitconfig";
    _watcher.Filter = gitconfig;
    _watcher.NotifyFilter = NotifyFilters.LastAccess;
    _watcher.Changed += OnWatcherOnChanged;
    this.Log().Debug("Initialized with {Home} {Filter}", userHome, gitconfig);
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
    await Task.WhenAll(
      Process.GetProcesses()
        .Where(p => _parser.IsGitCommand(p.ProcessName))
        .Select(HandleGitProcess)
    );
  }

  private async Task HandleGitProcess(Process gitProc)
  {
    this.Log().Debug("Git command detected: {Pid}", gitProc.Id);

    try
    {
      var cmdline = await ResolveCommandlineByPid(gitProc.Id);
      var workingDirectory = ResolveCommandWorkingDirectoryByPid(gitProc.Id);
      var processInfo = new SimpleProcessInfo(cmdline, workingDirectory);
      var gitCmd = _parser.Parse(cmdline);
      var commandEventArgs = new GitCommandEventArgs(
        gitCmd.IsGitCommit,
        gitCmd.IsGitPush,
        processInfo
      );
      GitCommandStarted?.Invoke(this, commandEventArgs);

      if (gitProc.HasExited)
      {
        GitCommandFinished?.Invoke(this, commandEventArgs);
      }
      else
      {
        gitProc.Exited += (_, _) =>
        {
          GitCommandFinished?.Invoke(this, commandEventArgs);
        };
        gitProc.EnableRaisingEvents = true;
      }
    }
    catch (Exception e)
    {
      this.Log()
        .Error(
          e,
          "Failed to retreive command info of {ProcessId}",
          gitProc.Id);
    }
  }


  private static async Task<string> ResolveCommandlineByPid(int pid)
  {
    var commandline =
      (await File.ReadAllTextAsync($"/proc/{pid}/cmdline")).Replace('\0', ' ');
    Serilog.Log.ForContext<LinuxGitCommandMonitor>()
      .Debug("resolve cmdline: {Output}", commandline);
    return commandline;
  }

  private static string? ResolveCommandWorkingDirectoryByPid(int pid)
  {
    var workingDirectory =
      File.ResolveLinkTarget($"/proc/{pid}/cwd", true)?.FullName;
    Serilog.Log.ForContext<LinuxGitCommandMonitor>()
      .Debug("resolve cwd: {Output}", workingDirectory);
    return workingDirectory;
  }

  public void Stop()
  {
    _watcher.EnableRaisingEvents = false;
  }
}
