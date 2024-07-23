using NanoidDotNet;
using Control = Avalonia.Controls.Control;
using Layoutable = Avalonia.Layout.Layoutable;

namespace Projects.AvaloniaUtils.Styling;

public static class StyleBuilder
{
  /// <summary>
  /// Shortcut for new Style(x => x.OfType&lt;T&gt;().Class(className))
  /// </summary>
  /// <param name="className"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static Style StyleOf<T>(out string className) where T : Control
  {
    var typeName = typeof(T).Name;
    var classId = Nanoid.Generate(size: 7);
    var name = $"{typeName}-{classId}";
    className = name;
    return new Style(x => x.OfType<T>().Class(name));
  }

  /// <summary>
  /// Shortcut for new Style(x => x.Is&lt;T&gt;().Class(className))
  /// </summary>
  /// <param name="className"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static Style StyleFor<T>(out string className) where T : Control
  {
    var typeName = typeof(T).Name;
    var classId = Nanoid.Generate(size: 7);
    var name = $"{typeName}-{classId}";
    className = name;
    return new Style(x => x.Is<T>().Class(name));
  }
}

public static class StyleExtensions
{
  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.VerticalAlignmentProperty"/> to <see cref="Avalonia.Layout.VerticalAlignment.Center"/>
  /// </summary>
  /// <param name="style"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T VerticalCenter<T>(this T style) where T : Style
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.VerticalAlignmentProperty,
      Value = VerticalAlignment.Center
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.VerticalAlignmentProperty"/> to <see cref="Avalonia.Layout.VerticalAlignment.Top"/>
  /// </summary>
  /// <param name="style"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T VerticalTop<T>(this T style) where T : Style
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.VerticalAlignmentProperty,
      Value = VerticalAlignment.Top
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.VerticalAlignmentProperty"/> to <see cref="Avalonia.Layout.VerticalAlignment.Bottom"/>
  /// </summary>
  /// <param name="style"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T VerticalBottom<T>(this T style) where T : Style
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.VerticalAlignmentProperty,
      Value = VerticalAlignment.Bottom
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.HorizontalAlignmentProperty"/> to <see cref="Avalonia.Layout.HorizontalAlignment.Left"/>
  /// </summary>
  /// <param name="style"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T HorizontalLeft<T>(this T style) where T : Style
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.HorizontalAlignmentProperty,
      Value = HorizontalAlignment.Left
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.HorizontalAlignmentProperty"/> to <see cref="Avalonia.Layout.HorizontalAlignment.Right"/>
  /// </summary>
  /// <param name="style"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T HorizontalRight<T>(this T style) where T : Style
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.HorizontalAlignmentProperty,
      Value = HorizontalAlignment.Right
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.HorizontalAlignmentProperty"/> to <see cref="Avalonia.Layout.HorizontalAlignment.Center"/>
  /// </summary>
  /// <param name="style"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T HorizontalCenter<T>(this T style) where T : Style
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.HorizontalAlignmentProperty,
      Value = HorizontalAlignment.Center
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.MarginProperty"/> to the specified thickness
  /// </summary>
  /// <param name="style"></param>
  /// <param name="setThickness"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T Margin<T>(this T style,
    Func<ThicknessExtensions.ThicknessSetter,
      ThicknessExtensions.ThicknessSetter> setThickness) where T : Style
  {
    var setter = setThickness(new ThicknessExtensions.ThicknessSetter(0));
    style.Setters.Add(new Setter
    {
      Property = Layoutable.MarginProperty,
      Value = setter.Build()
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.WidthProperty"/>
  /// </summary>
  /// <param name="style"></param>
  /// <param name="width"></param>
  /// <returns></returns>
  public static Style Width(this Style style, double width)
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.WidthProperty,
      Value = width
    });
    return style;
  }

  /// <summary>
  /// Set the <see cref="Avalonia.Layout.Layoutable.HeightProperty"/>
  /// </summary>
  /// <param name="style"></param>
  /// <param name="height"></param>
  /// <returns></returns>
  public static Style Height(this Style style, double height)
  {
    style.Setters.Add(new Setter
    {
      Property = Layoutable.HeightProperty,
      Value = height
    });
    return style;
  }
}

public static class ThicknessExtensions
{
  public struct ThicknessSetter
  {
    private double _left;
    private double _top;
    private double _right;
    private double _bottom;

    public ThicknessSetter(double uniformLength)
    {
      _left = _top = _right = _bottom = uniformLength;
    }

    public ThicknessSetter Left(double left)
    {
      _left = left;
      return this;
    }

    public ThicknessSetter Top(double top)
    {
      _top = top;
      return this;
    }

    public ThicknessSetter Right(double right)
    {
      _right = right;
      return this;
    }

    public ThicknessSetter Bottom(double bottom)
    {
      _bottom = bottom;
      return this;
    }

    public ThicknessSetter X(double horizontal)
    {
      _left = _right = horizontal;
      return this;
    }

    public ThicknessSetter Y(double vertical)
    {
      _top = _bottom = vertical;
      return this;
    }

    public ThicknessSetter All(double uniformLength)
    {
      _left = _top = _right = _bottom = uniformLength;
      return this;
    }

    public static explicit operator Thickness(ThicknessSetter setter)
    {
      return setter.Build();
    }

    public Thickness Build()
    {
      return new Thickness(_left, _top, _right, _bottom);
    }
  }
}
