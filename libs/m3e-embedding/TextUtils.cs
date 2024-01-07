using System.Text;
using System.Text.RegularExpressions;

namespace Projects.M3eEmbedding;

public static class TextUtils
{
  /// <summary>
  /// Strip accents from the given text
  /// </summary>
  /// <param name="text"></param>
  /// <returns></returns>
  public static string StripAccents(this string text)
  {
    string nonSpacingMarkRegex = @"\p{Mn}";
    var normalized = text.Normalize(NormalizationForm.FormD);
    return Regex.Replace(normalized, nonSpacingMarkRegex, string.Empty);
  }
}
