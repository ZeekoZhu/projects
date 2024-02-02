using ReactiveUI.Fody.Helpers;

namespace Projects.StatusTray.Domain;

public class StatusInfo
{
  [Reactive]
  public required string Id { get; set; }
  [Reactive]
  public required string Name { get; set; }

  [Reactive] public StatusState State { get; set; } = StatusState.Red;

  [Reactive]
  public required string DetailWebUrl { get; set; }

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
