using FluentAssertions;
using Projects.M3eEmbedding.Normalizers;

namespace Projects.M3eEmbedding.Test;

public class BertNormalizerTests
{
  [Test]
  public void
    Normalize_ShouldHandleChineseChars_WhenInputContainsCJKCharacters()
  {
    // Arrange
    var config = new NormalizerConfig("bert") { HandleChineseChars = true };
    var normalizer = new BertNormalizer(config);
    var inputText = "你好World";
    var expectedNormalizedText = " 你  好 World";

    // Act
    var result = normalizer.Normalize(inputText);

    // Assert
    result.Normalized.Should().BeEquivalentTo(expectedNormalizedText);
  }

  [Test]
  public void
    Normalize_ShouldHandleCleanText_WhenInputContainsControlCharactersAndWhitespace()
  {
    // Arrange
    var config = new NormalizerConfig("bert") { CleanText = true };
    var normalizer = new BertNormalizer(config);
    var inputText = "Hello\tWorld\n";
    var expectedNormalizedText = "Hello World ";

    // Act
    var result = normalizer.Normalize(inputText);

    // Assert
    result.Normalized.Should().BeEquivalentTo(expectedNormalizedText);
  }

  [Test]
  public void
    Normalize_ShouldHandleLowercase_WhenInputContainsUppercaseCharacters()
  {
    // Arrange
    var config = new NormalizerConfig("bert") { Lowercase = true };
    var normalizer = new BertNormalizer(config);
    var inputText = "Hello WORLD";
    var expectedNormalizedText = "hello world";

    // Act
    var result = normalizer.Normalize(inputText);

    // Assert
    result.Normalized.Should().Be(expectedNormalizedText);
  }

  [Test]
  public void
    Normalize_ShouldHandleLowercaseAndStripAccents_WithMixedCaseAndAccents()
  {
    // Arrange
    var config = new NormalizerConfig("bert")
    {
      Lowercase = true,
      StripAccents = true
    };
    var normalizer = new BertNormalizer(config);
    var input = "ÁbCđÊfG";
    var expectedOutput = "abcđefg";
    // đ won't be stripped because it's not an accent

    // Act
    var normalizedString = normalizer.Normalize(input);

    // Assert
    normalizedString.Normalized.Should().Be(expectedOutput);
  }

  [Test]
  public void
    GetCharSegments_WithMultiCharacterInputAndHighSurrogate_ReturnsCorrectSegments()
  {
    // Arrange
    var normalizer =
      new BertNormalizer(new NormalizerConfig("bert")).AsPrivateProxy();
    string
      input =
        "Hello\uD83D\uDE03World"; // Hello😃World - The emoji is a high surrogate pair
    var expectedSegments = new List<CharSegment>
    {
      new("H"),
      new("e"),
      new("l"),
      new("l"),
      new("o"),
      new("\uD83D\uDE03"), // The emoji surrogate pair
      new("W"),
      new("o"),
      new("r"),
      new("l"),
      new("d")
    };

    // Act
    var segments = normalizer.GetCharSegments(input);

    // Assert
    segments.Should().BeEquivalentTo(expectedSegments);
  }

  [Test]
  public void GetCharSegments_WithSpecialCharacters_ReturnsExpectedResult()
  {
    // Arrange
    var normalizer =
      new BertNormalizer(new NormalizerConfig("bert")).AsPrivateProxy();
    string input = "ÁbCđÊfG";
    var expectedResult = new List<CharSegment>
    {
      new("Á"),
      new("b"),
      new("C"),
      new("đ"),
      new("Ê"),
      new("f"),
      new("G")
    };

    // Act
    var result = normalizer.GetCharSegments(input);

    // Assert
    result.Should().BeEquivalentTo(expectedResult);
  }
}
