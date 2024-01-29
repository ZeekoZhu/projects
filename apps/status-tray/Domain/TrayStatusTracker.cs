using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using DynamicData;

namespace Projects.StatusTray.Domain;

public class TrayStatusTracker : StatusTracker
{
  public TrayStatusTracker(IEnumerable<IStatusProvider> statusProviders) : base(
    statusProviders)
  {
    StateUpdates = StatusListUpdates.Connect().Count(it => it.Count == 0)
      .Select(it => it == 0 ? StatusState.Green : StatusState.Red);
  }

  public IObservable<StatusState> StateUpdates { get; }
}

public class StatusTracker
{
  private readonly SourceCache<StatusInfo, string> _activeStatusInfos =
    new(it => it.Id);

  public StatusTracker(IEnumerable<IStatusProvider> statusProvider)
  {
    foreach (var provider in statusProvider)
    {
      provider.StatusUpdates.Subscribe(status =>
      {
        _activeStatusInfos.AddOrUpdate(status);
      });
    }

    StatusListUpdates = _activeStatusInfos.AsObservableCache();
  }

  public IObservableCache<StatusInfo, string> StatusListUpdates { get; }
}
