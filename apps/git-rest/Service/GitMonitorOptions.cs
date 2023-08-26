using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Splat;

namespace GitRest.Service;

public class GitMonitorOptions : IEnableLogger
{
  public static string IgnoreProjectsFile =>
    Path.Combine(
      Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
      "git-rest",
      "ignore-projects.txt");

  public static GitMonitorOptions Load()
  {
    var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    var homePattern = new Regex(@"\$HOME|~");
    var options = new GitMonitorOptions();
    var ignoreProjectsFile = IgnoreProjectsFile;
    if (File.Exists(ignoreProjectsFile))
    {
      var lines = File.ReadAllLines(ignoreProjectsFile);
      foreach (var line in lines)
      {
        if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
        {
          continue;
        }

        var replaced = homePattern.Replace(line, home).Trim(' ');
        Locator.Current.GetService<ILogManager>()
          ?.GetLogger<GitMonitorOptions>()
          .Debug("Ignore directory: {Directory}", replaced);
        options.IgnoreDirectory.Add(replaced);
      }
    }

    return options;
  }

  public List<string> IgnoreDirectory { get; set; } = new();
}
