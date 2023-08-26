using GitRest.Service;

namespace GitRest.Test;

[TestFixture]
public class GitCommandParserTests
{
  private GitCommandParser _gitCommandParser = null!;

  [SetUp]
  public void Setup()
  {
    _gitCommandParser = new GitCommandParser();
  }

  [Test]
  public void IsGitCommand_GitProcessName_ReturnsTrue()
  {
    var result = _gitCommandParser.IsGitCommand("git");
    Assert.IsTrue(result);
  }

  [Test]
  public void IsGitCommand_NonGitProcessName_ReturnsFalse()
  {
    var result = _gitCommandParser.IsGitCommand("notgit");
    Assert.IsFalse(result);
  }

  [Test]
  public void Parse_CommitCommand_ReturnsTrueForIsCommit()
  {
    var result = _gitCommandParser.Parse("git commit -m \"test\"");
    Assert.IsTrue(result.IsGitCommit);
    Assert.IsFalse(result.IsGitPush);
  }

  [Test]
  public void Parse_PushCommand_ReturnsTrueForIsPush()
  {
    var result = _gitCommandParser.Parse("git push origin master");
    Assert.IsFalse(result.IsGitCommit);
    Assert.IsTrue(result.IsGitPush);
  }

  [Test]
  public void Parse_AddCommand_ReturnsFalseForIsCommitAndIsPush()
  {
    var result = _gitCommandParser.Parse("git -c credential.helper= -c core.quotepath=false -c log.showSignature=false add --ignore-errors -A -- apps/git-rest/Service/GitCommandParser.cs");
    Assert.IsFalse(result.IsGitCommit);
    Assert.IsFalse(result.IsGitPush);
  }
}
