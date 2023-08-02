using System.Text.RegularExpressions;

namespace GsiOverlayTool;

// example output:
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute emailAddressTypes
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute imProtocols
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute organizationTypes
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute phoneTypes
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute postalAddressTypes
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute config_keySystemUuidMapping
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute carrier_properties
// Fatal: ./Lenovo/J716F/res/values/arrays.xml: defines a non-existing attribute common_nicknames
// we need to extract file path and the non-existing attribute name

public class TestOutputParser
{
  protected (string Path, OverlayValuesProblem Problem)? ParseNonExistingAttribute(
    string line)
  {
    var regex = new Regex(
      @"Fatal: (?<path>.+): defines a non-existing attribute (?<attribute>.+)");
    var match = regex.Match(line);
    if (!match.Success)
    {
      return null;
    }

    return (match.Groups["path"].Value, new OverlayValuesProblem
    {
      NonExistingAttribute = match.Groups["attribute"].Value
    });
  }


  public IList<ValueFileTestResult> Parse(Stream outputContent)
  {
    var results = new Dictionary<string, List<OverlayValuesProblem>>();
    using TextReader reader = new StreamReader(outputContent);
    var line = reader.ReadLine();
    while (line is not null)
    {
      if (ParseNonExistingAttribute(line) is
          ({ } path, { } problem))
      {
        AddToResult(results, path, problem);
      }

      line = reader.ReadLine();
    }

    return results.Select(
        it => new ValueFileTestResult
        {
          Path = it.Key,
          Problems = it.Value
        })
      .ToList();
  }

  /// <summary>
  /// Add the problem to the result dictionary
  /// </summary>
  /// <param name="results"></param>
  /// <param name="path"></param>
  /// <param name="problem"></param>
  private void AddToResult(
    Dictionary<string, List<OverlayValuesProblem>> results,
    string path,
    OverlayValuesProblem problem)
  {
    if (!results.TryGetValue(path, out var problems))
    {
      problems = new List<OverlayValuesProblem>();
      results.Add(path, problems);
    }

    problems.Add(problem);
  }
}
