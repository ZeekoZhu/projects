using Microsoft.ML.Tokenizers;
using Projects.M3eEmbedding.PreTokenizer;

namespace Projects.M3eEmbedding.Test;

[TestFixture]
public class BertPreTokenizerTest
{
  [Test]
  public void PreTokenize_ShouldCorrectlySplitSentenceIntoTokens()
  {
    // Arrange
    var preTokenizer = new BertPreTokenizer();
    const string sentence = "The quick brown fox jumps over the lazy dog.";

    // Act
    var result = preTokenizer.PreTokenize(sentence);

    // Assert
    var expectedTokens = new List<Split>
    {
      new("The", (0, 3)),
      new("quick", (4, 9)),
      new("brown", (10, 15)),
      new("fox", (16, 19)),
      new("jumps", (20, 25)),
      new("over", (26, 30)),
      new("the", (31, 34)),
      new("lazy", (35, 39)),
      new("dog", (40, 43)),
      new(".", (43, 44))
    };
    result.Should().BeEquivalentTo(expectedTokens);
  }

  [Test]
  public void PreTokenize_ShouldHandlePunctuationCorrectly()
  {
    // Arrange
    var preTokenizer = new BertPreTokenizer();
    var sentence = "Well, this is a test-case!";

    // Act
    var result = preTokenizer.PreTokenize(sentence);

    // Assert
    var expectedTokens = new List<Split>
    {
      new("Well", (0, 4)),
      new(",", (4, 5)),
      new("this", (6, 10)),
      new("is", (11, 13)),
      new("a", (14, 15)),
      new("test", (16, 20)),
      new("-", (20, 21)),
      new("case", (21, 25)),
      new("!", (25, 26))
    };
    result.Should().BeEquivalentTo(expectedTokens);
  }

  [Test]
  public void PreTokenize_ShouldHandleLeadingAndTrailingWhitespacesCorrectly()
  {
    // Arrange
    var preTokenizer = new BertPreTokenizer();
    var sentence = "  Hello, World!  ";

    // Act
    var result = preTokenizer.PreTokenize(sentence);

    // Assert
    var expectedTokens = new List<Split>
    {
      new("Hello", (2, 7)),
      new(",", (7, 8)),
      new("World", (9, 14)),
      new("!", (14, 15))
    };
    result.Should().BeEquivalentTo(expectedTokens);
  }

  [Test]
  public void PreTokenize_ShouldReturnCorrectTokenOffsets()
  {
    // Arrange
    var preTokenizer = new BertPreTokenizer();
    var sentence = "Token1 Token2";

    // Act
    var result = preTokenizer.PreTokenize(sentence);

    // Assert
    var expectedTokens = new List<Split>
    {
      new("Token1", (0, 6)),
      new("Token2", (7, 13))
    };
    result.Should().BeEquivalentTo(expectedTokens);
  }

  [Test]
  public void PreTokenize_ShouldHandleEmptyInputCorrectly()
  {
    // Arrange
    var preTokenizer = new BertPreTokenizer();
    var sentence = "";

    // Act
    var result = preTokenizer.PreTokenize(sentence);

    // Assert
    var expectedTokens = new List<Split>();
    result.Should().BeEquivalentTo(expectedTokens);
  }
}
