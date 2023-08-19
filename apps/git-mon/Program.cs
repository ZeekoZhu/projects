using System.Diagnostics;
using CliWrap;
using CliWrap.Buffered;
using Spectre.Console;

Console.WriteLine("hello");

// create a file system watcher to watch the access to `~/.gitconfig`

const string path = "/home/zhutao/";

var watcher = new FileSystemWatcher(path);
watcher.Filter = ".gitconfig";
watcher.NotifyFilter = NotifyFilters.LastAccess;

watcher.Changed += async (sender, args) =>
{
  Console.WriteLine($"File {args.FullPath} {args.ChangeType}");
  foreach (var s in Process.GetProcesses()
             .Where(p => p.ProcessName.Contains("git")))
  {
    s.EnableRaisingEvents = true;
    s.Exited += (o, eventArgs) =>
    {
      AnsiConsole.MarkupLine($"[red]process {s.Id} exited[/]");
    };
    var psCmd = Cli.Wrap("ps")
      .WithArguments(new[] { "-p", s.Id.ToString(), "-o", "cmd=" });
    var psInfo = await psCmd.ExecuteBufferedAsync();
    AnsiConsole.MarkupLine($"[green]inspect {psCmd}[/]");
    var commandline = psInfo.StandardOutput;
    // strip the first line
    AnsiConsole.MarkupLine($"[green]pid {s.Id}[/]");
    AnsiConsole.MarkupLine($"[green]name {s.ProcessName}[/]");
    AnsiConsole.MarkupLine($"[green]cmd {commandline}[/]");
  }
};

watcher.EnableRaisingEvents = true;

Console.WriteLine("Press enter to exit");
Console.ReadLine();
