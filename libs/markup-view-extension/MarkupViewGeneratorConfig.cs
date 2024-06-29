namespace Projects.MarkupViewExtension;

/// <summary>
/// Apply this attribute to a class to configure the markup view generator.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class MarkupViewGeneratorConfigAttribute
  : Attribute
{
}
