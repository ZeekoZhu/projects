using System.Text.RegularExpressions;
using Microsoft.ML.Tokenizers;

namespace Projects.M3eEmbedding.PreTokenizer;

public class BertPreTokenizer : Microsoft.ML.Tokenizers.PreTokenizer
{
  private const string PunctuationRegex =
    @"\p{P}\u0021-\u002F\u003A-\u0040\u005B-\u0060\u007B-\u007E";

  private readonly Regex _pattern =
    new($@"[^\s{PunctuationRegex}]+|[{PunctuationRegex}]",
      RegexOptions.Multiline | RegexOptions.Compiled);

  public override IReadOnlyList<Split> PreTokenize(string sentence)
  {
    // split the sentence into tokens using the regex pattern
    // and return the tokens with their offsets
    var matches = _pattern.Matches(sentence);

    return matches
      .Select(m => new Split(m.Value,
        (m.Index, m.Length + m.Index)))
      .ToList();
  }
}
