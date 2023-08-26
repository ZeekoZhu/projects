using System.CommandLine.Parsing;
using System.Linq;

namespace GitRest.Service;

public class GitCommandParser
{
  private readonly Parser _parser = new();

  public bool IsGitCommand(string processName)
  {
    // "git"
    // "/path/to/git"
    return processName.EndsWith("/git") || processName == "git";
  }

  public record ParseResult(bool IsGitCommit, bool IsGitPush);

  /// <summary>
  /// Parse the git command line.
  /// </summary>
  /// <param name="cmd">e.g. `git commit -m "foo"`</param>
  /// <returns></returns>
  public ParseResult Parse(string cmd)
  {
    var arguments = cmd.Substring(cmd.IndexOf(' '));
    var parseResult = _parser.Parse(arguments);
    var isCommit = parseResult.UnmatchedTokens.Contains("commit");
    var isPush = parseResult.UnmatchedTokens.Contains("push");
    return new ParseResult(isCommit, isPush);
  }
}
