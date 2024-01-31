using System;

namespace Projects.StatusTray.Domain;

public class StatusInfo
{
  public string Id { get; set; }
  public string Name { get; set; }
  public StatusState State { get; set; }
  public Action<StatusInfo> OnGoToDetails { get; set; }

  public override string ToString()
  {
    var sb = new System.Text.StringBuilder();
    sb.Append("StatusInfo {");
    sb.Append("Id: ");
    sb.Append(Id);
    sb.Append(", Name: ");
    sb.Append(Name);
    sb.Append(", State: ");
    // emoji state
    sb.Append(State == StatusState.Red ? "🔴" : "🟢");
    sb.Append('}');
    return sb.ToString();
}
}

public enum StatusState
{
  Red,
  Green
}
