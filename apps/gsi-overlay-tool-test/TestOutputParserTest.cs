using System.Text;
using System.Text.Unicode;
using FluentAssertions;
using GsiOverlayTool.Functions.FixOverlay;
using Snapshooter.NUnit;

namespace GsiOverlayTool.Test;

public class TestOutputParserTest
{
  [Test]
  public void CanParseNonExistingAttribute()
  {
    var parser = new TestOutputParser();
    using var outputContent = ToStream(
      @"
Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute carrier_properties
");
    var result = parser.Parse(outputContent);
    result.Should().HaveCount(1);
    result.MatchSnapshot();
  }

  private static MemoryStream ToStream(string testOutput)
  {
    return new MemoryStream(Encoding.UTF8.GetBytes(testOutput));
  }

  [Test]
  public void CanIgnoreUnknownError()
  {
    var parser = new TestOutputParser();
    using var outputContent = ToStream(
      @"
Fatal: ./Lenovo/J716F: Overlay ./Lenovo/J716F is defining config_allowAllRotations which is forbidden
Fatal: ./Lenovo/J716F: Overlay ./Lenovo/J716F is defining config_volumeAdjustmentForRemoteGroupSessions which is forbidden
");
    var result = parser.Parse(outputContent);
    result.Should().HaveCount(0);
  }
}
