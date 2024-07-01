namespace Projects.Project42.Extensions;

public static class StyleExtensions
{
  public static T Nested<T>(this T style, IStyle nestedStyle) where T : Style
  {
    style.Children.Add(nestedStyle);
    return style;
  }
}
