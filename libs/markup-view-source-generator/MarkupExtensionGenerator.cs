using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Projects.MarkupViewSourceGenerator;

[Generator]
public class MarkupExtensionGenerator : ISourceGenerator
{
  public void Initialize(GeneratorInitializationContext context)
  {
    context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
  }

  public void Execute(GeneratorExecutionContext context)
  {
    if (context.SyntaxReceiver is not SyntaxReceiver receiver)
    {
      return;
    }

    var configParser = new ConfigParser();
    var configInfos = configParser.GetConfigClasses(context, receiver);
    var writer = new MarkupExtensionSourceWriter(context);

    foreach (var configInfo in configInfos)
    {
      writer.GenerateExtensionSource(configInfo);
    }
  }
}

public class SyntaxReceiver : ISyntaxReceiver
{
  public List<ClassDeclarationSyntax> CandidateClasses { get; } = [];

  public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
  {
    if (syntaxNode is ClassDeclarationSyntax
        {
          AttributeLists.Count: > 0
        } classDeclarationSyntax)
    {
      CandidateClasses.Add(classDeclarationSyntax);
    }
  }
}
