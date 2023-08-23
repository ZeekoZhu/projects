using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using GitRest.Service;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace GitRest.Component;

[DataContract]
public class TimerViewViewModel : ReactiveObject, IEnableAppState,
  IActivatableViewModel
{
  private readonly TakeARestManager _takeARest;

  public TimerViewViewModel()
  {
    _takeARest = this.GetService<TakeARestManager>();
    Activator = new ViewModelActivator();
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

    this.WhenActivated(OnActivated);
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

  public ViewModelActivator Activator { get; }

  private IEnumerable<IDisposable> OnActivated()
  {
    // persist data
    yield return this.EnableAutoPersist(
      (it, state) =>
      {
        state.DefaultWorkingDuration =
          it.WorkingTimeSpans[it.WorkingTimeSpanIndex];
      });

    // update duration
    yield return this.WhenAnyValue(vm => vm.WorkingTimeSpanIndex)
      .Select(index => WorkingTimeSpans[index])
      .Subscribe(ts => _takeARest.Duration = ts);
  }

  public void ToggleMonitoring()
  {
    if (_takeARest.IsRunning)
    {
      _takeARest.Stop();
    }
    else
    {
      _takeARest.Start();
    }
  }
}
