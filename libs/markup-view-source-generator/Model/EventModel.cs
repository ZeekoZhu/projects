namespace Projects.MarkupViewSourceGenerator.Model;

public class EventModel(
  string eventName,
  string eventTypeName)
{
  public string EventName { get; } = eventName;
  public string EventTypeName { get; } = eventTypeName;
}
