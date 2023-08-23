using System;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using GitRest.Service;
using Splat;

namespace GitRest.Component;

public partial class ConfigView : UserControl, IEnableLocator, IEnableLogger
{
  public ConfigView()
  {
    InitializeComponent();
  }

  private void EditIgnoreProjectsBtn_OnClick(object? sender, RoutedEventArgs e)
  {
    var ignoreProjectsFile = GitMonitorOptions.IgnoreProjectsFile;
    // create file, directory if not exists
    if (!File.Exists(ignoreProjectsFile))
    {
      Directory.CreateDirectory(Path.GetDirectoryName(ignoreProjectsFile)!);
      const string fileTemplate =
        @"# ignore git activities in these projects,
# one project per line
# `$HOME` and `~` will be replaced with your home directory
# e.g. ~/Documents/obsidian
";
      File.WriteAllText(ignoreProjectsFile, fileTemplate);
    }

    // open it with default app
    var process = Process.Start(
      new ProcessStartInfo
      {
        FileName = ignoreProjectsFile,
        UseShellExecute = true,
      }
    );
    Observable.Return(Unit.Default)
      .Delay(TimeSpan.FromMinutes(3))
      .Do(
        _ =>
        {
          if (!process!.HasExited)
          {
            process.Kill();
          }
        })
      .Subscribe();
  }
}
