using System.Text.Json;
using Projects.GitLabApi.Model;

namespace Projects.GitLabApiTest.Models;

using GitLabApi.Concrete;

[TestFixture]
public class ProjectDtoTests
{
  [Test]
  public void CanDeserializeProjectDto()
  {
    var path = Path.Join(
      TestContext.CurrentContext.TestDirectory,
      "Models",
      "_assets",
      "get-single-project-1.json");
    var json = File.ReadAllText(path);

    Assert.DoesNotThrow(
      () =>
      {
        JsonSerializer.Deserialize<ProjectDto>(
          json,
          GitLabApi.JsonSerializerOptions);
      });
  }
}
