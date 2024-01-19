namespace Projects.M3eEmbedding.PostProcessor;

public class TemplateProcessing(TemplateProcessorConfig config) : IPostProcessor
{
  private List<TokenInfo> _single = config.Single;
  private List<TokenInfo> _pair = config.Pair;

  public PostProcessedOutput PostProcess(string[] tokens,
    string[]? tokensPair = null,
    PostProcessorConfig? config = null)
  {
    var type = tokensPair is null ? _single : _pair;
    var processedTokens = new List<string>();
    var types = new List<int>();
    var addSpecialTokens = config?.AddSpecialTokens ?? true;

    foreach (var item in type)
    {
      if (item.SpecialToken != null)
      {
        if (!addSpecialTokens) continue;
        processedTokens.Add(item.SpecialToken.Id);
        types.Add(item.SpecialToken.TypeId);
      }
      else if (item.Sequence != null)
      {
        if (item.Sequence.Id == "A")
        {
          processedTokens.AddRange(tokens);
          types.AddRange(Enumerable.Repeat(item.Sequence.TypeId,
            tokens.Length));
        }
        else if (item.Sequence.Id == "B" && tokensPair != null)
        {
          processedTokens.AddRange(tokensPair);
          types.AddRange(Enumerable.Repeat(item.Sequence.TypeId,
            tokensPair.Length));
        }
      }
    }

    return new PostProcessedOutput
    {
      Tokens = [.. processedTokens],
      TokenTypeIds = types
    };
  }
}

public class TemplateProcessorConfig
{
  public string Type { get; set; }
  public List<TokenInfo> Single { get; set; }
  public List<TokenInfo> Pair { get; set; }
  public Dictionary<string, SpecialTokenInfo> SpecialTokens { get; set; }
}

public class TokenInfo
{
  public TokenTypeInfo? SpecialToken { get; set; }
  public TokenTypeInfo? Sequence { get; set; }
}

public class TokenTypeInfo
{
  public string Id { get; set; }
  public int TypeId { get; set; }
}

public class SpecialTokenInfo
{
  public string Id { get; set; }
  public List<int> Ids { get; set; }
  public List<string> Tokens { get; set; }
}
