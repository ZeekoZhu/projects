// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.Xml;
using System.Xml.Linq;
using GsiOverlayTool;

var rootCmd = new RootCommand("GSI Overlay Tool");

var testOutputArg = new Argument<FileInfo>(
  "test-output",
  "The test output file to parse");
var overlayDir = new Argument<DirectoryInfo>(
  "overlay-dir",
  "The directory containing the overlay files"
);
var fixCommand = new Command("fix", "Parse test output")
{
  testOutputArg,
  overlayDir
};

fixCommand.SetHandler(
  ctx =>
  {
    var testOutputFile = ctx.ParseResult.GetValueForArgument(testOutputArg);
    var overlayDirPath = ctx.ParseResult.GetValueForArgument(overlayDir);
    if (!testOutputFile.Exists)
    {
      Console.WriteLine($"Test output file {testOutputFile} does not exist");
      ctx.ExitCode = 1;
      return;
    }

    if (!overlayDirPath.Exists)
    {
      Console.WriteLine($"Overlay directory {overlayDirPath} does not exist");
      ctx.ExitCode = 1;
      return;
    }

    var testOutputParser = new TestOutputParser();
    using var testOutputContent = testOutputFile.OpenRead();
    var results = testOutputParser.Parse(testOutputContent);
    var fixer = new OverlayValuesConfigXmlFixer();
    foreach (var fileTestResult in results)
    {
      var filePath = Path.Join(overlayDirPath.FullName, fileTestResult.Path);
      Console.WriteLine(
        "Fixing {0} problems in {1}",
        fileTestResult.Problems.Count,
        filePath);
      var doc = XElement.Load(filePath);
      fixer.Fix(doc, fileTestResult.Problems);
      // indent with 4 spaces
      var settings = new XmlWriterSettings
      {
        Indent = true,
        IndentChars = "    "
      };
      using var writer = XmlWriter.Create(filePath, settings);
      doc.WriteTo(writer);
    }
  });

rootCmd.AddCommand(fixCommand);

return await rootCmd.InvokeAsync(args);
