namespace Projects.AvaloniaUtils.Markup;

public static class GridExtensions
{
  public static T RowDefinitions<T>(this T grid, RowDefinitions defs)
    where T : Grid
  {
    grid.RowDefinitions = defs;
    return grid;
  }

  public static T RowDefinitions<T>(this T grid, string defs) where T : Grid
  {
    grid.RowDefinitions = Avalonia.Controls.RowDefinitions.Parse(defs);
    return grid;
  }

  public static T ColumnDefinitions<T>(this T grid, ColumnDefinitions defs)
    where T : Grid
  {
    grid.ColumnDefinitions = defs;
    return grid;
  }

  public static T ColumnDefinitions<T>(this T grid, string defs) where T : Grid
  {
    grid.ColumnDefinitions = Avalonia.Controls.ColumnDefinitions.Parse(defs);
    return grid;
  }

  public static T Grid<T>(this T control, int column = 0, int row = 0)
    where T : Control
  {
    control.Column(column).Row(row);
    return control;
  }
}
