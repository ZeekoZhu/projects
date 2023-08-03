using System.Xml.Linq;

namespace GsiOverlayTool.Functions.FixOverlay;

public class OverlayValuesConfigXmlFixer
{
  public void Fix(XElement doc, IEnumerable<OverlayValuesProblem> problems)
  {
    // remove all node with 'name' set to the value of the 'NonExistingAttribute' property
    var nonExistingAttributes = problems.Select(p => p.NonExistingAttribute)
      .Where(p => p != null)
      .ToHashSet();

    var nodes = doc.Descendants()
      .Where(
        it => it.Attribute("name") switch
        {
          { Value: var name } when nonExistingAttributes.Contains(name) =>
            true,
          _ => false
        }).ToList();
    foreach (var xElement in nodes)
    {
      xElement.Remove();
    }
  }
}
