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
    return context.Compilation.GetClasses(new ClassSpec(["IMarkupView"], false))
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
