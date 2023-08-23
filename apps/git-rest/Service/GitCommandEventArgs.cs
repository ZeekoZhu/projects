namespace GitRest.Service;

public class GitCommandEventArgs
{
  public GitCommandEventArgs(
    bool isGitCommit,
    bool isGitPush,
    SimpleProcessInfo processInfo)
  {
    IsGitCommit = isGitCommit;
    IsGitPush = isGitPush;
    ProcessInfo = processInfo;
  }

  public bool IsGitCommit { get; }
  public bool IsGitPush { get; }
  public SimpleProcessInfo ProcessInfo { get; set; }
}

public record SimpleProcessInfo(
  string CommandLine,
  string? WorkingDirectory
);
