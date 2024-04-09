using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Projects.GitLabApi.Abstraction;
using Projects.GitLabApi.Model;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Projects.GitLabApi.Concrete;

public class GitLabApi(IRestClient client) : IGitLabApi
{
  public IProjectEndpoint Project { get; } = new ProjectEndpoint(client);

  public IMergeRequestEndpoint MergeRequest { get; } =
    new MergeRequestEndpoint(client);

  public static readonly JsonSerializerOptions JSONSerializerOptions =
    new(JsonSerializerDefaults.Web)
    {
      Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
      PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
      UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
    };

  public static GitLabApi Create(string baseUrl, string token)
  {
    var client = new RestClient(
        new RestClientOptions(baseUrl),
        configureSerialization: s => s.UseSystemTextJson(JSONSerializerOptions))
      .AddDefaultHeader("Authorization", $"Bearer {token}");

    return new GitLabApi(client);
  }
}

public class MergeRequestEndpoint(IRestClient client) : IMergeRequestEndpoint
{
  public Task<PaginationResult<MergeRequestDto>?> ListProjectMergeRequestsAsync(
    string projectId,
    ListMergeRequestsRequestParams requestParams,
    CancellationToken cancellationToken = default)
  {
    var req = new RestRequest("/projects/{id}/merge_requests")
      .AddUrlSegment(
        nameof(projectId).ToAttributeName(),
        projectId);

    req.AddAttribute(requestParams);

    return client.GetAsync<PaginationResult<MergeRequestDto>>(
      req,
      cancellationToken: cancellationToken);
  }
}

public class ProjectEndpoint(IRestClient client) : IProjectEndpoint
{
  public Task<ProjectDto?> GetProjectAsync(
    string id,
    GetProjectRequestParams requestParams,
    CancellationToken cancellationToken = default)
  {
    var req = new RestRequest("/projects/{id}")
      .AddUrlSegment(
        nameof(id).ToAttributeName(),
        id)
      .AddAttribute(requestParams);

    return client.GetAsync<ProjectDto>(
      req,
      cancellationToken: cancellationToken);
  }
}

internal static class GitLabApiExtensions
{
  /// <summary>
  /// Convert Pascal case to snake_case
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>
  public static string ToAttributeName(this string str)
  {
    return JsonNamingPolicy.SnakeCaseLower.ConvertName(str);
  }

  private static readonly AttributeFormatter Formatter = new();

  public static RestRequest AddAttribute<T>(
    this RestRequest req,
    T? value)
  {
    if (value == null) return req;

    foreach (var (key, val) in Formatter.FormatAttributes(value))
    {
      req.AddQueryParameter(key, val);
    }

    return req;
  }
}
