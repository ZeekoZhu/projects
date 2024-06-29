namespace Projects.MarkupViewExtension;

/// <summary>
/// An attribute that marks a static class as a markup view extension.
/// </summary>
/// <param name="controlType">The control type that the markup view extension is for.</param>
[AttributeUsage(AttributeTargets.Class)]
public class MarkupViewsAttribute(Type[] controlType) : Attribute
{
  public Type[] ControlType { get; } = controlType;
}

/// <summary>
/// An attribute that marks a static class as a markup view extension.
/// </summary>
/// <param name="controlTypes">Add all control types in the assembly of the type</param>
public class MarkupViewsInNamespaceAttribute(Type[] controlTypes) : Attribute
{
  public Type[] ControlType { get; } = controlTypes;
}
