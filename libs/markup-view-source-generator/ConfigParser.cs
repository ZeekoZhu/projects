using LanguageExt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Projects.MarkupViewSourceGenerator.Model;

namespace Projects.MarkupViewSourceGenerator;

public class ConfigParser
{
  public IEnumerable<ConfigInfo> GetConfigClasses(
    GeneratorExecutionContext context,
    SyntaxReceiver receiver)
  {
    return receiver.CandidateClasses
      .Select(classDecl => GetClassSymbol(context, classDecl))
      .Somes()
      .Select(configClassSymbol =>
        new ConfigInfo
        {
          ControlTypes = GetControlsFromMarkupViewsAttr(configClassSymbol)
            .Concat(GetControlsFromMarkupViewsInNsAttr(configClassSymbol))
            .ToList()
        });
  }

  private Option<INamedTypeSymbol> GetClassSymbol(
    GeneratorExecutionContext context, ClassDeclarationSyntax classDecl)
  {
    var model = context.Compilation.GetSemanticModel(classDecl.SyntaxTree);
    return (model.GetDeclaredSymbol(classDecl) as INamedTypeSymbol).Apply(
      Prelude.Optional);
  }

  private Option<string> GetMarkupViewGeneratorConfig(
    INamedTypeSymbol classSymbol)
  {
    return classSymbol.GetAttributes()
      .FirstOrDefault(attr =>
        attr.AttributeClass?.Name == "MarkupViewGeneratorConfigAttribute")
      .Apply(Prelude.Optional)
      .Bind(attr => attr.ConstructorArguments.FirstOrDefault()
        .Apply(Prelude.Optional))
      .Bind(it => (it.Value?.ToString()).Apply(Prelude.Optional));
  }

  private IEnumerable<INamedTypeSymbol> GetControlsFromMarkupViewsAttr(
    INamedTypeSymbol classSymbol)
  {
    return classSymbol.GetAttributes()
      .FirstOrDefault(attr =>
        attr.AttributeClass?.Name == "MarkupViewsAttribute")
      .Apply(Prelude.Optional)
      .Map(attr => attr.ConstructorArguments.FirstOrDefault()
        .Values
        .Select(typedConstant => typedConstant.Value as INamedTypeSymbol)
        .Where(symbol => symbol is not null)
        .Cast<INamedTypeSymbol>()
      )
      .IfNone([]);
  }

  private IEnumerable<INamedTypeSymbol> GetControlsFromMarkupViewsInNsAttr(
    INamedTypeSymbol classSymbol
  )
  {
    return classSymbol.GetAttributes()
      .FirstOrDefault(attr =>
        attr.AttributeClass?.Name == "MarkupViewsInNamespaceAttribute")
      .Apply(Prelude.Optional)
      .Map(attr => attr.ConstructorArguments.FirstOrDefault()
        .Values
        .Select(typedConstant => typedConstant.Value as INamedTypeSymbol)
        .Where(symbol => symbol is not null)
        .Cast<INamedTypeSymbol>()
        .Bind(GetControlClassesInTheSameNs)
      )
      .IfNone([]);
  }

  private IEnumerable<INamedTypeSymbol> GetControlClassesInTheSameNs(
    INamedTypeSymbol classSymbol)
  {
    return classSymbol.ContainingNamespace.GetTypeMembers()
      .Filter(IsAvaloniaControl);
  }

  private static bool IsAvaloniaControl(INamedTypeSymbol it)
  {
    var baseType = it.BaseType;
    while (baseType is not null)
    {
      if (baseType.FullQualifiedName().EndsWith("Avalonia.Controls.Control"))
      {
        return true;
      }

      baseType = baseType.BaseType;
    }

    return false;
  }
}
