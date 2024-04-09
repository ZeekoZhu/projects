using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Projects.GitLabApi.Concrete;

public class AttributeFormatter : IAttributeFormatter
{
  private readonly List<IAttributeFormatter> _formatters;

  public AttributeFormatter()
  {
    _formatters = new List<IAttributeFormatter>
    {
      new SimpleAttributeFormatter(),
      new NullableAttributeFormatter(this),
      new ArrayAttributeFormatter(this),
      new HashAttributeFormatter(this)
    };
  }

  public IEnumerable<KeyValuePair<string, string>> FormatAttributes(object obj)
  {
    var ctx = new AttributeFormatterContext();
    var path = new AttributePath(obj.GetType(), "");
    ctx.Path.Push(path);
    FormatAttribute(obj, ctx);

    return ctx.Result;
  }

  public bool CanFormat(AttributeFormatterContext ctx)
  {
    return true;
  }

  public void FormatAttribute(object? value, AttributeFormatterContext ctx)
  {
    var formatter = _formatters.FirstOrDefault(it => it.CanFormat(ctx));
    ArgumentNullException.ThrowIfNull(formatter);
    formatter.FormatAttribute(value, ctx);
  }
}


public class AttributePath
{
  public string Name { get; set; }
  public Type ValueType { get; set; }

  string FormatCase(string attrName)
  {
    return JsonNamingPolicy.SnakeCaseLower.ConvertName(attrName);
  }

  public AttributePath(PropertyInfo prop)
  {
    Name = FormatCase(prop.Name);
    ValueType = prop.PropertyType;
  }

  public AttributePath(Type type, string name)
  {
    Name = FormatCase(name);
    ValueType = type;
  }
}

public class AttributeFormatterContext
{
  public Stack<AttributePath> Path { get; set; } = new();
  public List<KeyValuePair<string, string>> Result { get; set; } = [];

  public void AddAttribute(string attrValue)
  {
    var sb = new StringBuilder();

    foreach (var s in Path.Reverse())
    {
      if (string.IsNullOrWhiteSpace(s.Name))
      {
        continue;
      }

      if (sb.Length > 0)
      {
        sb.Append($"[{s.Name}]");
      }
      else
      {
        sb.Append(s.Name);
      }
    }

    var key = sb.ToString();
    Result.Add(new KeyValuePair<string, string>(key, attrValue));
  }

  public Type ValueType
  {
    get
    {
      if (Path.TryPeek(out var prop))
      {
        return prop.ValueType;
      }

      throw new InvalidOperationException("Path is empty");
    }
  }
}

public interface IAttributeFormatter
{
  public bool CanFormat(AttributeFormatterContext ctx);
  public void FormatAttribute(object? value, AttributeFormatterContext ctx);
}

public class SimpleAttributeFormatter : IAttributeFormatter
{
  public bool CanFormat(AttributeFormatterContext ctx)
  {
    return ctx.ValueType.IsAssignableTo(typeof(string))
           || ctx.ValueType.IsAssignableTo(typeof(bool))
           || ctx.ValueType.IsAssignableTo(typeof(int))
           || ctx.ValueType.IsAssignableTo(typeof(long))
           || ctx.ValueType.IsAssignableTo(typeof(double))
           || ctx.ValueType.IsAssignableTo(typeof(decimal))
           || ctx.ValueType.IsAssignableTo(typeof(DateTime));
  }

  public void FormatAttribute(object? value, AttributeFormatterContext ctx)
  {
    if (value is null)
    {
      return;
    }

    var attrValue = value switch
    {
      bool b => b ? "true" : "false",
      DateTime dt => dt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
      _ => value.ToString()
    };

    if (attrValue is not null)
    {
      ctx.AddAttribute(attrValue);
    }
  }
}

public class ArrayAttributeFormatter(IAttributeFormatter formatter)
  : IAttributeFormatter
{
  public bool CanFormat(AttributeFormatterContext ctx)
  {
    return ctx.ValueType.IsAssignableTo(typeof(IEnumerable));
  }

  public void FormatAttribute(object? obj, AttributeFormatterContext ctx)
  {
    if (obj is null) return;

    var enumerable = obj as IEnumerable;
    ArgumentNullException.ThrowIfNull(enumerable);

    var index = 0;

    foreach (var item in enumerable)
    {
      if (item is null) continue;

      var newPath = new AttributePath(item.GetType(), index.ToString());
      ctx.Path.Push(newPath);
      formatter.FormatAttribute(item, ctx);
      ctx.Path.Pop();
      index++;
    }
  }
}

public class HashAttributeFormatter(IAttributeFormatter formatter)
  : IAttributeFormatter
{
  public bool CanFormat(AttributeFormatterContext ctx)
  {
    return true;
  }

  public void FormatAttribute(object? value, AttributeFormatterContext ctx)
  {
    if (value is null) return;

    var notNullProps = value.GetType()
      .GetProperties()
      .Where(prop => prop.GetValue(value) != null)
      .ToList();

    foreach (var prop in notNullProps)
    {
      var newPath = new AttributePath(prop);
      ctx.Path.Push(newPath);
      formatter.FormatAttribute(prop.GetValue(value), ctx);
      ctx.Path.Pop();
    }
  }
}

public class NullableAttributeFormatter(IAttributeFormatter formatter)
  : IAttributeFormatter
{
  public bool CanFormat(AttributeFormatterContext ctx)
  {
    return ctx.ValueType.IsGenericType
           && ctx.ValueType.GetGenericTypeDefinition() == typeof(Nullable<>);
  }

  public void FormatAttribute(object? value, AttributeFormatterContext ctx)
  {
    if (value is null) return;

    var nullablePath = ctx.Path.Pop();
    var underlyingType = Nullable.GetUnderlyingType(nullablePath.ValueType);
    ArgumentNullException.ThrowIfNull(underlyingType);
    nullablePath.ValueType = underlyingType;
    ctx.Path.Push(nullablePath);

    formatter.FormatAttribute(value, ctx);
  }
}
