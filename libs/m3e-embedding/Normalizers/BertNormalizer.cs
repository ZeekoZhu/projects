using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.ML.Tokenizers;

namespace Projects.M3eEmbedding.Normalizers;

/// <summary>
/// Adds whitespace around any CJK (Chinese, Japanese, or Korean) character in the input text.
/// </summary>
/// <param name="config"></param>
public class BertNormalizer(NormalizerConfig config) : Normalizer
{
  protected IEnumerable<CharSegment> GetCharSegments(string text)
  {
    for (var i = 0; i < text.Length; i++)
    {
      var ch = text[i];
      if (char.IsHighSurrogate(ch))
      {
        yield return new CharSegment(text.Substring(i, 2));
        i++;
      }
      else
      {
        yield return new CharSegment(text.Substring(i, 1));
      }
    }
  }

  public override NormalizedString Normalize(string original)
  {
    var chars = GetCharSegments(original);
    if (config.CleanText)
    {
      chars = CleanText(chars);
    }

    if (config.HandleChineseChars)
    {
      chars = TokenizeChineseChars(chars);
    }

    if (config.Lowercase)
    {
      chars = Lowercase(chars);
      if (config.StripAccents is not false)
      {
        chars = StripAccents(chars);
      }
    }
    else if (config.StripAccents == true)
    {
      chars = StripAccents(chars);
    }

    return new NormalizedString(original,
      string.Join(null, chars.Select(it => it.Char)), null, false);
  }

  private IEnumerable<CharSegment> StripAccents(IEnumerable<CharSegment> chars)
  {
    return chars.Select(c => c.StripAccent()).OfType<CharSegment>();
  }

  private IEnumerable<CharSegment> Lowercase(IEnumerable<CharSegment> chars)
  {
    return chars.Select(it => it.ToLowerCase());
  }

  /// <summary>
  /// Add whitespaces around any CJK character in the input text.
  /// </summary>
  /// <param name="text"></param>
  /// <returns></returns>
  protected IEnumerable<CharSegment> TokenizeChineseChars(
    IEnumerable<CharSegment> text)
  {
    foreach (CharSegment ch in text)
    {
      if (ch.IsChineseChar)
      {
        yield return new CharSegment(" ");
        yield return ch;
        yield return new CharSegment(" ");
      }
      else
      {
        yield return ch;
      }
    }
  }

  protected IEnumerable<CharSegment> CleanText(IEnumerable<CharSegment> text)
  {
    foreach (CharSegment ch in text)
    {
      if (ch.CodePoint == '\u0000' || ch.CodePoint == '\uFFFD' || ch.IsControl)
      {
        continue;
      }

      if (string.IsNullOrWhiteSpace(ch.Char)) // is whitespace
      {
        yield return new CharSegment(" ");
      }
      else
      {
        yield return ch;
      }
    }
  }
}

public class CharSegment(string c)
{
  private static readonly Regex NonSpacingMarkRegex = new(@"\p{Mn}");

  /// <summary>
  /// A single char or a surrogate pair
  /// </summary>
  public string Char { get; set; } = c;

  public int CodePoint => char.ConvertToUtf32(Char, 0);

  public bool IsControl
  {
    get
    {
      var code = Char[0];
      if (code is '\t' or '\n' or '\r')
      {
        return false;
      }

      return char.GetUnicodeCategory(code)
        is UnicodeCategory.Control
        or UnicodeCategory.Format
        or UnicodeCategory.PrivateUse
        or UnicodeCategory.Surrogate;
    }
  }

  public bool IsChineseChar =>
    CodePoint is >= 0x_4E00 and <= 0x_9FFF // CJK Unified Ideographs
      or >= 0x_3400 and <= 0x_4DBF // CJK Unified Ideographs Extension A
      or >= 0x_F900 and <= 0x_FAFF // CJK Compatibility Ideographs
      or >= 0x_20000 and <= 0x_2A6DF // CJK Unified Ideographs Extension B
      or >= 0x_2A700 and <= 0x_2B73F // CJK Unified Ideographs Extension C
      or >= 0x_2B740 and <= 0x_2B81F // CJK Unified Ideographs Extension D
      or >= 0x_2B820 and <= 0x_2CEAF // CJK Unified Ideographs Extension E
      or >= 0x_2F800 and <= 0x_2FA1F; // CJK Compatibility Ideographs Supplement

  public CharSegment ToLowerCase()
  {
    return new CharSegment(Char.ToLower());
  }

  public CharSegment? StripAccent()
  {
    var normalized = Char.Normalize(NormalizationForm.FormD);
    var stripped = NonSpacingMarkRegex.Replace(normalized, string.Empty);
    return string.IsNullOrEmpty(stripped) ? null : new CharSegment(stripped);
  }
}
