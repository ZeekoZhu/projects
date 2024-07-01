using LanguageExt;
using Microsoft.CodeAnalysis;
using Projects.MarkupViewSourceGenerator.Model;

namespace Projects.MarkupViewSourceGenerator;

public class ControlInfoExtractor
{
  public ControlInfo Extract(INamedTypeSymbol controlClass)
  {
    var avaloniaProps = controlClass.GetMembers()
      .OfType<IFieldSymbol>()
      .Filter(IsAvaloniaProperty)
      .Select(prop => GetAvaloniaPropValueType(prop.Type)
        .Map(fieldType => new ControlPropertyInfo
        {
          PropertyFieldName = prop.Name,
          Type = fieldType.FullQualifiedName()
        }))
      .Somes()
      .ToList();

    var avaloniaEvents = controlClass.GetMembers()
      .OfType<IFieldSymbol>()
      .Filter(IsAvaloniaEvent)
      .Map(ev => GetAvaloniaEventArgsType(ev.Type)
        .Map(argType => new ControlEventInfo
        {
          Type = argType.FullQualifiedName(),
          EventFiledName = ev.Name,
        })
      )
      .Somes()
      .ToList();

    return new ControlInfo
    {
      HasDefaultCtor =
        !controlClass.IsAbstract &&
        controlClass.Constructors.Any(ctor =>
          ctor.Parameters.IsEmpty),
      DeclaringNamespace = controlClass.FullNamespace(),
      DeclaringType = controlClass.FullContainingTypeName(),
      ControlName = controlClass.Name,
      ControlClassName = controlClass.FullQualifiedName(),
      Properties = avaloniaProps,
      Events = avaloniaEvents
    };
  }

  /// <summary>
  /// The field type either of AvaloniaProperty&lt;T&gt; , StyledProperty&lt;T&gt; or DirectProperty&lt;T&gt;
  /// </summary>
  /// <param name="field"></param>
  /// <returns></returns>
  private static bool IsAvaloniaProperty(IFieldSymbol field)
  {
    if (!field.IsStatic)
    {
      return false;
    }

    if (field.DeclaredAccessibility is not Accessibility.Public)
    {
      return false;
    }

    var type = field.Type;

    // Check if the field type is a generic type
    if (type is not INamedTypeSymbol { IsGenericType: true } namedType)
      return false;
    var genericTypeDefinition =
      namedType.ConstructUnboundGenericType().ToString();

    return genericTypeDefinition is "Avalonia.AvaloniaProperty<>"
      or "Avalonia.StyledProperty<>"
      or "Avalonia.DirectProperty<,>";
  }

  private static bool IsAvaloniaEvent(IFieldSymbol field)
  {
    if (!field.IsStatic) return false;
    if (field.DeclaredAccessibility is not Accessibility.Public) return false;

    var type = field.Type;

    if (type is not INamedTypeSymbol { IsGenericType: true } namedType)
      return false;
    var genericTypeDef = namedType.ConstructUnboundGenericType().ToString();

    return genericTypeDef is "Avalonia.Interactivity.RoutedEvent<>";
  }

  public static Option<ITypeSymbol> GetAvaloniaEventArgsType(
    ITypeSymbol fieldType)
  {
    if (fieldType is not INamedTypeSymbol { IsGenericType: true } namedType)
      return null;
    return namedType.TypeArguments.LastOrDefault().Apply(Prelude.Optional);
  }


  public static Option<ITypeSymbol> GetAvaloniaPropValueType(
    ITypeSymbol fieldType)
  {
    if (fieldType is not INamedTypeSymbol { IsGenericType: true } namedType)
      return null;
    return namedType.TypeArguments.LastOrDefault().Apply(Prelude.Optional);
  }
}
