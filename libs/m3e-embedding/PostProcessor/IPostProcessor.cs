namespace Projects.M3eEmbedding.PostProcessor;

// https://github.com/xenova/transformers.js/blob/07df34ff3308cf3b1ab830a547bd9bcf22869783/src/tokenizers.js#L2770
public interface IPostProcessor
{
  public PostProcessedOutput PostProcess(string[] tokens,
    string[]? tokensPair = null, PostProcessorConfig? config = null);
}

public class PostProcessorConfig
{
  public bool? AddSpecialTokens { get; set; }
}

public class PostProcessedOutput
{
  /// <summary>
  /// List of token produced by the post-processor.
  /// </summary>
  public string[] Tokens { get; init; }

  /// <summary>
  /// List of token type ids produced by the post-processor.
  /// </summary>
  public List<int> TokenTypeIds { get; init; }
}
