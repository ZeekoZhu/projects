using FluentAssertions;
using Projects.M3eEmbedding.Normalizers;

namespace Projects.M3eEmbedding.Test;

/**
 * notes
 * use NUnit
 * use FluentAssertions
 * use PrivateProxy to access private members
 */
public class CharSegmentTests
{
  [Test]
  public void StripAccent_ShouldRemoveAccent_WhenInputIsSingleCharacterWithAccent()
  {
    // Arrange
    var inputCharSegment = new CharSegment("Á");
    var expectedCharSegment = new CharSegment("A");

    // Act
    var result = inputCharSegment.StripAccent();

    // Assert
    result.Should().NotBeNull();
    result?.Char.Should().Be(expectedCharSegment.Char);
  }

  [Test]
  public void StripAccent_ShouldNotAlterSurrogatePair_WhenInputIsSurrogatePairCharacter()
  {
    // Arrange
    var inputCharSegment = new CharSegment("\uD83D\uDE03"); // Surrogate pair for 😃 emoji
    var expectedCharSegment = new CharSegment("\uD83D\uDE03"); // Surrogate pairs should remain unchanged

    // Act
    var result = inputCharSegment.StripAccent();

    // Assert
    result.Should().NotBeNull();
    result?.Char.Should().Be(expectedCharSegment.Char);
  }

  [Test]
  public void StripAccent_ShouldNotAlterCharacter_WhenInputCharacterHasNoAccent()
  {
    // Arrange
    var inputCharSegment = new CharSegment("B");
    var expectedCharSegment = new CharSegment("B");

    // Act
    var result = inputCharSegment.StripAccent();

    // Assert
    result.Should().NotBeNull();
    result?.Char.Should().Be(expectedCharSegment.Char);
  }
}
