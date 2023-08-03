namespace GsiOverlayTool.Functions.FixOverlay;

public class OverlayValuesProblem
{
  public string? NonExistingAttribute { get; init; }
}

public class ValueFileTestResult
{
  public string Path { get; init; } = "";
  public List<OverlayValuesProblem> Problems { get; init; } = new();
}
