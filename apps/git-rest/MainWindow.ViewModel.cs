using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GitRest.Infrastructure;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace GitRest;

[DataContract]
public class MainWindowViewModel : ReactiveObject, IEnableAppState
{
  public MainWindowViewModel()
  {
    var appState = this.GetAppState()
      .DefaultWorkingDuration;
    try
    {
      WorkingTimeSpanIndex = WorkingTimeSpans.IndexOf(appState);
    }
    catch (Exception e)
    {
      this.Log()
        .Info("Failed to load default working duration: {Error}", e.Message);
    }

    this.EnableAutoPersist(
      (it, state) =>
      {
        state.DefaultWorkingDuration =
          it.WorkingTimeSpans[it.WorkingTimeSpanIndex];
      });
  }

  [DataMember]
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
