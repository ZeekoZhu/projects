using FluentAvalonia.UI.Controls;
using Projects.MarkupViewExtension;
using Projects.Project42.Dashboard;

namespace Projects.Project42.Markup;

[MarkupViewGeneratorConfig]
[MarkupViewsInNamespace([
  typeof(NumberBox), typeof(DashboardCanvasView), typeof(CustomLabel)
])]
// ReSharper disable once UnusedType.Global
public class MarkupExtensionsConfig;


public static class GridExtensions
{
  public static T RowDefinitions<T>(this T grid, RowDefinitions defs) where T : Grid
  {
    grid.RowDefinitions = defs;
    return grid;
  }

  public static T ColumnDefinitions<T>(this T grid, ColumnDefinitions defs) where T : Grid
  {
    grid.ColumnDefinitions = defs;
    return grid;
  }
}
