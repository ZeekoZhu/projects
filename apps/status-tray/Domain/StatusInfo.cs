using System;

namespace Projects.StatusTray.Domain;

public class StatusInfo
{
  public string Id { get; set; }
  public string Name { get; set; }
  public StatusState State { get; set; }
  public Action<StatusInfo> OnGoToDetails { get; set; }
}

public enum StatusState
{
  Red,
  Green
}
