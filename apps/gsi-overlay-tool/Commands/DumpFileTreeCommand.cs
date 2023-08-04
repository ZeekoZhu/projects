using System.CommandLine;
using GsiOverlayTool.Functions.DumpFileTree;

namespace GsiOverlayTool.Commands;

internal static class DumpFileTreeCommand
{
  public static void AddDumpFileTreeCommand(this Command command)
  {
    var rootDirArg = new Argument<DirectoryInfo>(
      "root-dir",
      "The root directory to dump"
    );
    var outFileArg = new Argument<FileInfo>(
      "output-file",
      "The output file to write the tree to");
    var dumpFileTreeCommand = new Command(
      "dump-file-tree",
      "Dump file tree of a directory")
    {
      rootDirArg,
      outFileArg
    };
    dumpFileTreeCommand.AddAlias("dft");
    dumpFileTreeCommand.SetHandler(
      ctx =>
      {
        var rootDir = ctx.ParseResult.GetValueForArgument(rootDirArg);
        var outFile = ctx.ParseResult.GetValueForArgument(outFileArg);
        FileTreeDump.Dump(rootDir, outFile);
      });
    command.Add(dumpFileTreeCommand);
  }
}
