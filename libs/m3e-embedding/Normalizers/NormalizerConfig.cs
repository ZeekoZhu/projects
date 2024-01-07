namespace Projects.M3eEmbedding.Normalizers;

public class NormalizerConfig(string type)
{
  public string Type { get; set; } = type;
  public bool CleanText { get; set; }
  public bool HandleChineseChars { get; set; }
  public bool Lowercase { get; set; }
  public bool? StripAccents { get; set; }
}
