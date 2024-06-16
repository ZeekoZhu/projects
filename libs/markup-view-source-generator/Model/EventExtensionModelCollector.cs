using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Projects.MarkupViewSourceGenerator.Model;

public class EventExtensionModelCollector
{
  public IEnumerable<EventExtensionModel> Collect(
    GeneratorExecutionContext context)
  {
    return context.Compilation.GetClasses(new ClassSpec(["IMarkupView"], false))
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
          var propType = field.Declaration.Type is GenericNameSyntax gns
            ? GetQualifiedName(context, gns.TypeArgumentList.Arguments[0])
            : "";
          result.Events.Add(new EventModel(propName, propType));
        }

        return result;
      });
  }

  private static string GetQualifiedName(GeneratorExecutionContext context,
    TypeSyntax symbol)
  {
    var model = context.Compilation.GetSemanticModel(symbol.SyntaxTree);
    var type = model.GetTypeInfo(symbol).Type!;
    var fullQualifiedName =
      new List<string>
          { type.FullNamespace(), type.FullContainingTypeName(), type.Name }
        .Where(it => !string.IsNullOrEmpty(it));
    return
      $"global::{string.Join(".", fullQualifiedName)}";
  }
}
