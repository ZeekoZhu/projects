using System;
using System.Collections.Generic;

namespace Projects.StatusTray.Domain;

public interface IStatusProvider
{
  IObservable<IList<StatusInfo>> StatusUpdates { get; }
}
