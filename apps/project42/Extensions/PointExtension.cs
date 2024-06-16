namespace Projects.Project42.Extensions;

public static class PointExtension
{
  public static Point Constraint(this Point point, Point min, Point max)
  {
    var x = Math.Max(min.X, Math.Min(max.X, point.X));
    var y = Math.Max(min.Y, Math.Min(max.Y, point.Y));
    return new Point(x, y);
  }

  /// <summary>
  /// Creates a new point from the <see cref="Size"/> object with the width and height as X and Y respectively.
  /// </summary>
  /// <param name="size"></param>
  /// <returns></returns>
  public static Point ToPoint(this Size size)
  {
    return new Point(size.Width, size.Height);
  }

}
