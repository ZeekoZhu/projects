using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Projects.MarkupViewSourceGenerator.Model;

public class PropertyExtensionModel(
  string className,
  string namespaceName,
  List<PropertyModel> properties)
{
  public string ClassName { get; } = className;
  public string NamespaceName { get; } = namespaceName;
  public List<PropertyModel> Properties { get; } = properties;

  public void Deconstruct(out string className, out string namespaceName, out List<PropertyModel> properties)
  {
    className = ClassName;
    namespaceName = NamespaceName;
    properties = Properties;
  }
}

public class PropertyModel(
  string propertyName,
  string typeName)
{
  public string PropertyName { get; } = propertyName;
  public string TypeName { get; } = typeName;

  public void Deconstruct(out string propertyName, out string typeName)
  {
    propertyName = PropertyName;
    typeName = TypeName;
  }
}

public class PropertyExtensionModelCollector
{
  public IEnumerable<PropertyExtensionModel> Collect(
    GeneratorExecutionContext context)
  {
    return context.Compilation.GetClasses(new ClassSpec(["IMarkupView"]))
      .Select(c =>
      {
        var model = context.Compilation.GetSemanticModel(c.SyntaxTree);
        var symbol = model.GetDeclaredSymbol(c)!;
        var result = new PropertyExtensionModel(
          c.Identifier.ToString(),
          symbol.FullNamespace(),
          []);
        var fields = c.GetFields(new FieldSpec(["public", "static", "readonly"],
          new TypeSpec(true, "StyledProperty")));
        foreach (var field in fields)
        {
          var propName =
            field.Declaration.Variables[0]
              .Identifier.ToString()
              .Replace("Property", "");
          var propType = field.Declaration.Type is GenericNameSyntax gns
            ? gns.TypeArgumentList.Arguments[0].ToString()
            : "";
          result.Properties.Add(new PropertyModel(propName, propType));
        }

        return result;
      });
  }
}

public class EventExtensionModel(
  string className,
  string namespaceName,
  List<EventModel> events)
{
  public string ClassName { get; } = className;
  public string NamespaceName { get; } = namespaceName;
  public List<EventModel> Events { get; } = events;

  public void Deconstruct(out string className, out string namespaceName, out List<EventModel> events)
  {
    className = this.ClassName;
    namespaceName = this.NamespaceName;
    events = this.Events;
  }
}

public class EventModel(
  string eventName,
  string eventTypeName)
{
  public string EventName { get; } = eventName;
  public string EventTypeName { get; } = eventTypeName;

  public void Deconstruct(out string eventName, out string eventTypeName)
  {
    eventName = this.EventName;
    eventTypeName = this.EventTypeName;
  }
}

public class EventExtensionModelCollector
{
  public IEnumerable<EventExtensionModel> Collect(
    GeneratorExecutionContext context)
  {
    return context.Compilation.GetClasses(new ClassSpec(["IMarkupView"]))
      .Select(c =>
      {
        var model = context.Compilation.GetSemanticModel(c.SyntaxTree);
        var symbol = model.GetDeclaredSymbol(c)!;
        var result = new EventExtensionModel(
          c.Identifier.ToString(),
          symbol.FullNamespace(),
          []);
        var fields = c.GetFields(new FieldSpec(["public", "static", "readonly"],
          new TypeSpec(true, "RoutedEvent")));
        foreach (var field in fields)
        {
          var propName =
            field.Declaration.Variables[0]
              .Identifier.ToString()
              .Replace("Event", "");
          var propType = field.Declaration.Type is GenericNameSyntax gns ? gns.TypeArgumentList.Arguments[0].ToString() : "";
          result.Events.Add(new EventModel(propName, propType));
        }

        return result;
      });
  }
}
