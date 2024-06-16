namespace Projects.MarkupViewSourceGenerator.Model;

public class EventExtensionModel(
  string className,
  string namespaceName,
  List<EventModel> events)
{
  public string ClassName { get; } = className;
  public string NamespaceName { get; } = namespaceName;
  public List<EventModel> Events { get; } = events;
}
