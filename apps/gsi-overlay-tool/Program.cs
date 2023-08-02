// See https://aka.ms/new-console-template for more information

using System.CommandLine;

var rootCmd = new RootCommand("GSI Overlay Tool");

var testOutputArg = new Argument<FileInfo>(
  "test-output",
  "The test output file to parse");
var overlayDir = new Argument<DirectoryInfo>(
  "overlay-dir",
  "The directory containing the overlay files"
);
var parseTestOutputCmd = new Command("fix", "Parse test output")
{
  testOutputArg,
  overlayDir
};

parseTestOutputCmd.SetHandler(
  ctx =>
  {
    var testOutputFile = ctx.ParseResult.GetValueForArgument(testOutputArg);
    var overlayDirPath = ctx.ParseResult.GetValueForArgument(overlayDir);
  });
