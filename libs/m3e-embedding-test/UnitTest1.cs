using FluentAssertions;

namespace Projects.M3eEmbedding.Test;

public class TextUtilsTest
{
    [Test]
    public void TestStripAccents()
    {
      "àéêöhello".StripAccents().Should().Be("aeeohello");
    }
}
