using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using Splat;

namespace Projects.StatusTray.Domain;

public class TrayStatusTracker : StatusTracker, IEnableLogger
{
  public TrayStatusTracker(IEnumerable<IStatusProvider> statusProviders) : base(
    statusProviders)
  {
    StateUpdates = StatusListUpdates.Connect()
      .QueryWhenChanged(it =>
      {
        return it.Items.All(s => s.State == StatusState.Green)
          ? StatusState.Green
          : StatusState.Red;
      });
  }

  public IObservable<StatusState> StateUpdates { get; }
}

public class StatusTracker : IEnableLogger
{
  private readonly SourceCache<StatusInfo, string> _activeStatusInfos =
    new(it => it.Id);

  public StatusTracker(IEnumerable<IStatusProvider> statusProvider)
  {
    StatusListUpdates = _activeStatusInfos.AsObservableCache();
    foreach (var provider in statusProvider)
    {
      provider.StatusUpdates.Subscribe(status =>
      {
        this.Log().Debug("{Count} Status got update", status.Count);
        this.Log().Debug("Status: {Status}", status);
        _activeStatusInfos.AddOrUpdate(status);
      });
    }
  }

  public IObservableCache<StatusInfo, string> StatusListUpdates { get; }
}
