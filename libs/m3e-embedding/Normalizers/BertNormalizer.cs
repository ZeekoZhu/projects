using System.Text;
using Microsoft.ML.Tokenizers;

namespace Projects.M3eEmbedding.Normalizers;

/**
 * Adds whitespace around any CJK (Chinese, Japanese, or Korean) character in the input text.
 */
public class BertNormalizer : Normalizer
{
  public override NormalizedString Normalize(string original)
  {
    throw new NotImplementedException("BertNormalizer.Normalize");
  }


  protected bool IsChineseChar(int cp)
  {
    return
      (cp >= 0x4E00 && cp <= 0x9FFF) ||
      (cp >= 0x3400 && cp <= 0x4DBF) ||
      (cp >= 0x20000 && cp <= 0x2A6DF) ||
      (cp >= 0x2A700 && cp <= 0x2B73F) ||
      (cp >= 0x2B740 && cp <= 0x2B81F) ||
      (cp >= 0x2B820 && cp <= 0x2CEAF) ||
      (cp >= 0xF900 && cp <= 0xFAFF) ||
      (cp >= 0x2F800 && cp <= 0x2FA1F);
  }
}
