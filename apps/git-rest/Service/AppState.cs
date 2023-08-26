using System;

namespace GitRest.Service;

public class AppState
{
  public TimeSpan DefaultWorkingDuration { get; set; } =
    TimeSpan.FromMinutes(25);
}
