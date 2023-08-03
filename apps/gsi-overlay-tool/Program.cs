// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using GsiOverlayTool;
using GsiOverlayTool.Commands;

var rootCmd = new RootCommand("GSI Overlay Tool");

rootCmd.AddFixCommand();

return await rootCmd.InvokeAsync(args);
