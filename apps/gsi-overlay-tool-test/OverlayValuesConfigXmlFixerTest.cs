using System.Xml.Linq;
using FluentAssertions;
using Snapshooter.NUnit;

namespace GsiOverlayTool.Test;

public class OverlayValuesConfigXmlFixerTest
{
  readonly OverlayValuesConfigXmlFixer _fixer = new();

  readonly string _testXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<resources>
  <fraction name=""config_autoBrightnessAdjustmentMaxGamma"">300.0%</fraction>
  <fraction name=""config_dimBehindFadeDuration"">100.0%</fraction>
  <fraction name=""config_maximumScreenDimRatio"">20.000004%</fraction>
  <fraction name=""config_prescaleAbsoluteVolume_index1"">60.000004%</fraction>
  <fraction name=""config_prescaleAbsoluteVolume_index2"">79.99999%</fraction>
  <fraction name=""config_prescaleAbsoluteVolume_index3"">90.0%</fraction>
  <fraction name=""config_screenAutoBrightnessDozeScaleFactor"">100.0%</fraction>
  <fraction name=""docked_stack_divider_fixed_ratio"">34.150005%</fraction>
  <fraction name=""thumbnail_fullscreen_scale"">60.000004%</fraction>
  <array name=""config_allowedSystemInstantAppSettings"" />
  <integer-array name=""config_ambientBrighteningThresholds"">
      <item>100</item>
  </integer-array>
  <bool name=""config_sendPackageName"">false</bool>
  <bool name=""config_showDefaultAssistant"">true</bool>
  <bool name=""config_showDefaultEmergency"">false</bool>
  <bool name=""config_showDefaultHome"">true</bool>
</resources>
";

  [Test]
  public void CanRemoveFraction()
  {
    var problems = new List<OverlayValuesProblem>
    {
      new()
      {
        NonExistingAttribute = "config_autoBrightnessAdjustmentMaxGamma"
      }
    };
    var doc = XElement.Parse(_testXml);
    _fixer.Fix(doc, problems);
    var result = doc.ToString();
    result.Should().NotContain("config_autoBrightnessAdjustmentMaxGamma");
    result.MatchSnapshot();
  }

  [Test]
  public void CanRemoveEmptyArray()
  {
    var problems = new List<OverlayValuesProblem>
    {
      new()
      {
        NonExistingAttribute = "config_allowedSystemInstantAppSettings"
      }
    };
    var doc = XElement.Parse(_testXml);
    _fixer.Fix(doc, problems);
    var result = doc.ToString();
    result.Should().NotContain("config_allowedSystemInstantAppSettings");
    result.MatchSnapshot();
  }

  [Test]
  public void CanRemoveIntegerArray()
  {
    var problems = new List<OverlayValuesProblem>
    {
      new()
      {
        NonExistingAttribute = "config_ambientBrighteningThresholds"
      }
    };
    var doc = XElement.Parse(_testXml);
    _fixer.Fix(doc, problems);
    var result = doc.ToString();
    result.Should().NotContain("config_ambientBrighteningThresholds");
    result.MatchSnapshot();
  }

  [Test]
  public void CanRemoveMutiple()
  {
    var problems = new List<OverlayValuesProblem>
    {
      new()
      {
        NonExistingAttribute = "config_ambientBrighteningThresholds"
      },
      new()
      {
        NonExistingAttribute = "config_allowedSystemInstantAppSettings"
      }
    };
    var doc = XElement.Parse(_testXml);
    _fixer.Fix(doc, problems);
    var result = doc.ToString();
    result.Should().NotContain("config_ambientBrighteningThresholds");
    result.Should().NotContain("config_allowedSystemInstantAppSettings");
    result.MatchSnapshot();
  }

  [Test]
  public void CanRemoveBools()
  {
    var problems = new List<OverlayValuesProblem>
    {
      new()
      {
        NonExistingAttribute = "config_sendPackageName"
      },
      new()
      {
        NonExistingAttribute = "config_showDefaultAssistant"
      },
      new()
      {
        NonExistingAttribute = "config_showDefaultEmergency"
      },
    };

    var doc = XElement.Parse(_testXml);
    _fixer.Fix(doc, problems);
    var result = doc.ToString();
    result.Should().NotContain("config_sendPackageName");
    result.Should().NotContain("config_showDefaultAssistant");
    result.Should().NotContain("config_showDefaultEmergency");
    result.MatchSnapshot();
    
  }
}
