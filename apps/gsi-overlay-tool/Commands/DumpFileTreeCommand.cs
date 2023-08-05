using System.CommandLine;
using GsiOverlayTool.Functions.DumpFileTree;

namespace GsiOverlayTool.Commands;

internal static class DumpFileTreeCommand
{
  private static void AddDumpCommand(Command command)
  {
    var rootDirArg = new Argument<DirectoryInfo>(
      "root-dir",
      "The root directory to dump"
    );
    var outFileArg = new Argument<FileInfo>(
      "output-file",
      "The output file to write the tree to");
    var dumpFileTreeCommand = new Command(
      "dump",
      "Dump file tree of a directory")
    {
      rootDirArg,
      outFileArg
    };
    dumpFileTreeCommand.SetHandler(
      ctx =>
      {
        var rootDir = ctx.ParseResult.GetValueForArgument(rootDirArg);
        var outFile = ctx.ParseResult.GetValueForArgument(outFileArg);
        FileTreeDump.Dump(rootDir, outFile);
      });
    command.Add(dumpFileTreeCommand);
  }

  public static void AddFileTreeCommand(this Command command)
  {
    var fileTreeCommand = new Command(
      "file-tree",
      "File tree related commands");
    fileTreeCommand.AddAlias("ft");
    AddDumpCommand(fileTreeCommand);
    command.Add(fileTreeCommand);
  }
}
