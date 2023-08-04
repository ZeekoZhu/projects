using GsiOverlayTool.Functions.DumpFileTree;
using Snapshooter.NUnit;

namespace GsiOverlayTool.Test;

public class FileScannerTest
{
  private string _tmpDir = null!;

  /// <summary>
  /// create a tmp directory with following layout
  /// /path/to/tmp/dump-file-tree
  /// ├── bar
  /// │   └── world-link -> ../foo/foo-1/world
  /// └── foo
  /// ├── foo-1
  /// │   └── world
  /// ├── foo-2 -> foo-1
  /// └── hello
  /// </summary>
  [SetUp]
  public void PrepareFixture()
  {
    _tmpDir = Path.Join(Path.GetTempPath(), "dump-file-tree");
    Directory.CreateDirectory(_tmpDir);
    Directory.CreateDirectory(Path.Join(_tmpDir, "foo"));
    Directory.CreateDirectory(Path.Join(_tmpDir, "foo", "foo-1"));
    new DirectoryInfo(Path.Join(_tmpDir, "foo", "foo-2")).CreateAsSymbolicLink(
      Path.Join(_tmpDir, "foo", "foo-1"));
    File.WriteAllText(Path.Join(_tmpDir, "foo/foo-1/world"), "world");

    Directory.CreateDirectory(Path.Join(_tmpDir, "bar"));
    new FileInfo(Path.Join(_tmpDir, "bar/world-link")).CreateAsSymbolicLink(
      Path.Join(_tmpDir, "foo/foo-1/world"));
  }

  [TearDown]
  public void CleanupFixture()
  {
    Directory.Delete(_tmpDir, true);
  }

  [Test]
  public void CanScan()
  {
    var baseDir = new DirectoryInfo(_tmpDir);
    var result = FileScanner.Scan(baseDir).ToList();
    var relativeFilePaths = result.Select(
      it => Path.GetRelativePath(baseDir.FullName, it.FullName));
    relativeFilePaths.MatchSnapshot();
  }
}
