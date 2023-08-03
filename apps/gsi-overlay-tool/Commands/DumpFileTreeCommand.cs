using System.CommandLine;

namespace GsiOverlayTool.Commands;

internal static class DumpFileTreeCommand
{
  public static void AddDumpFileTreeCommand(this Command command)
  {
    var dumpFileTreeCommand = new Command(
      "dump-file-tree",
      "Dump file tree of a directory")
    {
      new Argument<DirectoryInfo>(
        "root-dir",
        "The root directory to dump"
      ),
      new Argument<FileInfo>(
        "output-file",
        "The output file to write the tree to")
    };
  }
}
