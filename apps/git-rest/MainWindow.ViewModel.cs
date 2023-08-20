using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace GitRest;

public class MainWindowViewModel : ReactiveObject
{
  [Reactive]
  public int WorkingTimeSpanIndex { get; set; }

  public List<TimeSpan> WorkingTimeSpans { get; } = new()
  {
    TimeSpan.FromMinutes(25),
    TimeSpan.FromMinutes(30),
    TimeSpan.FromMinutes(35),
    TimeSpan.FromMinutes(40),
    TimeSpan.FromMinutes(45),
    TimeSpan.FromMinutes(50),
    TimeSpan.FromMinutes(55),
    TimeSpan.FromMinutes(60),
  };

  [Reactive]
  public bool IsMonitoringGit { get; set; }
}
