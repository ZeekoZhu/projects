using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;

namespace Projects.MarkupViewSourceGenerator;

public class ConfigInfo
{
  public List<INamedTypeSymbol> ControlTypes { get; set; } = [];
}

public class ControlInfo
{
  public bool HasDefaultCtor { get; set; }
  public string DeclaringNamespace { get; set; } = "";
  public string DeclaringType { get; set; } = "";

  /// <summary>
  /// Name of the control class.
  /// </summary>
  public string ControlName { get; set; } = "";

  /// <summary>
  /// Full qualified type name of the control class.
  /// </summary>
  public string ControlClassName { get; set; } = "";

  public List<ControlPropertyInfo> Properties { get; set; } = [];

  public List<ControlEventInfo> Events { get; set; } = [];

  public string ExtensionClassName => ControlClassName.Replace('.', '_')
    .Replace("global::", string.Empty)
    .Replace("<", "_")
    .Replace(">", "_");
}

public class ControlPropertyInfo
{
  private static readonly Regex PropSuffixRegex = new("Property$");

  /// <summary>
  /// <see cref="Name"/>Property
  /// </summary>
  public string PropertyFieldName { get; set; } = "";

  /// <summary>
  /// The name of the Avalonia Property without the "Property" suffix.
  /// </summary>
  public string Name => PropSuffixRegex.Replace(PropertyFieldName, "");

  /// <summary>
  /// Full qualified type name of the property.
  /// </summary>
  public string Type { get; set; } = "";
}

public class ControlEventInfo
{

  private static readonly Regex SuffixRegex = new("Event$");

  /// <summary>
  /// The name of the routed event without the "Event" suffix.
  /// </summary>
  public string Name => SuffixRegex.Replace(EventFiledName, "");

  /// <summary>
  /// <see cref="Name"/>Event
  /// </summary>
  public string EventFiledName { get; set; } = "";

  /// <summary>
  /// Full qualified type name of the event.
  /// </summary>
  public string Type { get; set; } = "";
}
