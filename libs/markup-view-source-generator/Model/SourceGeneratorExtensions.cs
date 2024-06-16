using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Projects.MarkupViewSourceGenerator.Model;

public class FieldSpec(
  string[] modifiers,
  TypeSpec type
)
{
  public string[] Modifiers { get; } = modifiers;
  public TypeSpec Type { get; } = type;

  public void Deconstruct(out string[] modifiers, out TypeSpec type)
  {
    modifiers = Modifiers;
    type = Type;
  }
}

public class TypeSpec(bool isGenericType, string genericTypeName)
{
  public bool IsGenericType { get; } = isGenericType;
  public string GenericTypeName { get; } = genericTypeName;

  public void Deconstruct(out bool isGenericType, out string genericTypeName)
  {
    isGenericType = IsGenericType;
    genericTypeName = GenericTypeName;
  }
}

public class ClassSpec(
  string[] interfaces,
  bool isAbstract
)
{
  public string[] Interfaces { get; } = interfaces;
  public bool IsAbstract { get; } = isAbstract;
}

public static class ClassDeclarationSyntaxExtensions
{
  public static IEnumerable<FieldDeclarationSyntax> GetFields(
    this ClassDeclarationSyntax classDeclaration,
    FieldSpec fieldSpec)
  {
    return classDeclaration.DescendantNodes()
      .OfType<FieldDeclarationSyntax>()
      .Where(p => p.Satisfy(fieldSpec));
  }
}

public static class FieldDeclarationSyntaxExtensions
{
  public static bool HasModifiers(
    this FieldDeclarationSyntax fieldDeclaration,
    IEnumerable<string> modifiers)
  {
    return fieldDeclaration.Modifiers.Any(m => modifiers.Contains(m.ValueText));
  }

  public static bool Satisfy(
    this FieldDeclarationSyntax fieldDeclaration,
    FieldSpec fieldSpec)
  {
    return fieldDeclaration.HasModifiers(fieldSpec.Modifiers) &&
           fieldDeclaration.Declaration.Type.IsGeneric(fieldSpec.Type
             .GenericTypeName);
  }
}

public static class TypeSyntaxExtensions
{
  public static bool IsGeneric(
    this TypeSyntax typeSyntax, string genericTypeName)
  {
    return typeSyntax is GenericNameSyntax gns &&
           gns.Identifier.ValueText == genericTypeName;
  }
}

public static class NamedTypeSymbolExtensions
{
  /// <summary>
  ///   The symbol implements all the interfaces.
  /// </summary>
  /// <param name="symbol"></param>
  /// <param name="interfaces"></param>
  /// <returns></returns>
  public static bool ImplementsInterfaces(
    this INamedTypeSymbol symbol, IEnumerable<string> interfaces)
  {
    // the symbol is a class and implements all the interfaces
    return symbol.TypeKind == TypeKind.Class &&
           interfaces.All(it => symbol.AllInterfaces.Any(i => i.Name == it));
  }
}

public static class CompilationExtensions
{
  public static IEnumerable<ClassDeclarationSyntax> GetClasses(
    this Compilation compilation, ClassSpec classSpec)
  {
    return compilation.SyntaxTrees
      .SelectMany(s =>
        s.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>())
      .Where(s =>
      {
        var model = compilation.GetSemanticModel(s.SyntaxTree);
        var symbol = model.GetDeclaredSymbol(s);
        return symbol is INamedTypeSymbol cs &&
               cs.ImplementsInterfaces(classSpec.Interfaces) &&
               cs.IsAbstract == classSpec.IsAbstract;
      });
  }
}

public static class SymbolExtensions
{
  public static string FullNamespace(this ISymbol symbol)
  {
    return string.Join(".",
      Parts(symbol).Where(it => !string.IsNullOrEmpty(it)).Reverse());

    IEnumerable<string> Parts(ISymbol s)
    {
      var ns = s.ContainingNamespace;
      while (ns != null)
      {
        yield return ns.Name;
        ns = ns.ContainingNamespace;
      }
    }
  }

  public static string FullContainingTypeName(this ISymbol symbol)
  {
    return string.Join(".",
      Parts(symbol).Where(it => !string.IsNullOrEmpty(it)).Reverse());

    IEnumerable<string> Parts(ISymbol s)
    {
      var c = s.ContainingType;
      while (c is not null)
      {
        yield return c.Name;
        c = c.ContainingType;
      }
    }
  }
}
