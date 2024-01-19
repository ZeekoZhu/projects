using Projects.M3eEmbedding.PostProcessor;

namespace Projects.M3eEmbedding.Test;

[TestFixture]
public class TemplateProcessingTests
{
  [Test]
  public void PostProcess_WithEmptyConfig_ShouldOutputEmpty()
  {
    // Arrange
    var config = new TemplateProcessorConfig
    {
      Single = [], // Assuming TokenInfo is defined elsewhere
      Pair = [] // Assuming TokenInfo is defined elsewhere
    };
    var templateProcessing = new TemplateProcessing(config);
    string[] tokens = ["token1", "token2"];
    string[] tokensPair = ["token3", "token4"];

    // Act
    var result = templateProcessing.PostProcess(tokens, tokensPair);

    // Assert
    result.Tokens.Should().BeEmpty();
    result.TokenTypeIds.Should().BeEmpty();
  }
}
