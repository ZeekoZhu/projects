using System.Text;

namespace Projects.MarkupViewSourceGenerator.Helper;

/// <summary>
///   A thin wrapper around StringBuilder to help with writing source code.
/// </summary>
public class SourceWriter(string indentString = "  ")
{
  private int _indentLevel;

  public StringBuilder Builder { get; set; } = new();

  public SourceWriter Indent()
  {
    _indentLevel++;
    return this;
  }

  public SourceWriter Unindent()
  {
    _indentLevel--;
    return this;
  }

  public SourceWriter Line()
  {
    Builder.AppendLine();
    return this;
  }
  public SourceWriter Line(string value)
  {
    foreach (var s in Enumerable.Repeat(indentString, _indentLevel))
      Builder.Append(s);

    Builder.AppendLine(value);
    return this;
  }

  public SourceWriter Write(string value)
  {
    Builder.Append(value);
    return this;
  }

  public SourceWriter CodeBlock(Action block)
  {
    Line("{");
    Indent();
    block();
    Unindent();
    return Line("}");
  }

  public override string ToString()
  {
    return Builder.ToString();
  }
}
