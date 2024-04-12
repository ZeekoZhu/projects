using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Projects.GitLabApi.Abstraction;
using Projects.GitLabApi.Model;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Projects.GitLabApi.Concrete;

public class GitLabApi(IRestClient client, LogInterceptor interceptor)
  : IGitLabApi
{
  public static readonly JsonSerializerOptions JsonSerializerOptions =
    new(JsonSerializerDefaults.Web)
    {
      Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
      PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
      UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
    };

  public IProjectEndpoint Project { get; } =
    new ProjectEndpoint(client, interceptor);

  public IMergeRequestEndpoint MergeRequest { get; } =
    new MergeRequestEndpoint(client, interceptor);

  public static GitLabApi Create(
    string baseUrl,
    string token,
    ILogger<IGitLabApi> logger)
  {
    var client = new RestClient(
        new RestClientOptions(baseUrl),
        configureSerialization: s => s.UseSystemTextJson(JsonSerializerOptions))
      .AddDefaultHeader("Authorization", $"Bearer {token}");

    return new GitLabApi(client, new LogInterceptor(logger));
  }
}

public class MergeRequestEndpoint(
  IRestClient client,
  LogInterceptor interceptor) : IMergeRequestEndpoint
{
  public async Task<PaginationResult<MergeRequestDto>?>
    ListProjectMergeRequestsAsync(
      string projectId,
      ListMergeRequestsRequestParams requestParams,
      CancellationToken cancellationToken = default)
  {
    var req = new RestRequest("/projects/{id}/merge_requests")
      .AddUrlSegment("id", projectId)
      .AddAttribute(requestParams)
      .LogRequest(interceptor);
    var resp =
      await client.ExecuteGetAsync<MergeRequestDto[]>(req, cancellationToken);

    resp.ThrowIfError();
    return new PaginationResult<MergeRequestDto>
    {
      Items = resp.Data ?? [],
      Pagination = resp.ToPaginationInfo()
    };
  }

  public async Task<MergeRequestDto> CreateMergeRequestAsync(
    string projectId,
    CreateMergeRequestParams createMergeRequestParams,
    CancellationToken cancellationToken = default)
  {
    var req = new RestRequest("/projects/{id}/merge_requests", Method.Post)
      .AddUrlSegment("id", projectId)
      .AddJsonBody(createMergeRequestParams)
      .LogRequest(interceptor);

    return (await client.PostAsync<MergeRequestDto>(req, cancellationToken))!;
  }

  public Task<MergeRequestDto?> UpdateMergeRequestAsync(
    string projectId,
    string mergeRequestIid,
    UpdateMergeRequestParams updateMergeRequestParams,
    CancellationToken cancellationToken = default)
  {
    var req = new RestRequest("/projects/{id}/merge_requests/{mergeRequestIid}", Method.Put)
      .AddUrlSegment("id", projectId)
      .AddUrlSegment("mergeRequestIid", mergeRequestIid)
      .AddJsonBody(updateMergeRequestParams)
      .LogRequest(interceptor);

    return client.PutAsync<MergeRequestDto>(req, cancellationToken);
  }
}

public class ProjectEndpoint(IRestClient client, LogInterceptor interceptor)
  : IProjectEndpoint
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
      .AddAttribute(requestParams)
      .LogRequest(interceptor);

    return client.GetAsync<ProjectDto>(
      req,
      cancellationToken);
  }
}

internal static class GitLabApiExtensions
{
  private static readonly AttributeFormatter Formatter = new();

  /// <summary>
  ///   Convert Pascal case to snake_case
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>
  public static string ToAttributeName(this string str)
  {
    return JsonNamingPolicy.SnakeCaseLower.ConvertName(str);
  }

  public static RestRequest AddAttribute<T>(
    this RestRequest req,
    T? value)
  {
    if (value == null) return req;

    foreach (var (key, val) in Formatter.FormatAttributes(value))
      req.AddQueryParameter(key, val);

    return req;
  }

  public static PaginationInfo ToPaginationInfo(this RestResponse response)
  {
    var result = new PaginationInfo
    {
      NextPage = 0,
      PrevPage = 0,
      Page = 0,
      PerPage = 0,
      Total = null,
      TotalPages = null
    };

    if (response.Headers is not null)
    {
      var headers = response.Headers.ToLookup(
        it => it.Name!,
        it => it.Value as string);

      int? TryReadInt(ILookup<string, string?> respHeaders, string key)
      {
        if (!respHeaders.Contains(key)) return null;

        var value = respHeaders[key]
          .FirstOrDefault();

        if (value != null && int.TryParse(value, out var parsed))
          return parsed;

        return null;
      }

      result.NextPage = TryReadInt(headers, "x-next-page") ?? 0;
      result.Page = TryReadInt(headers, "x-page") ?? 0;
      result.PerPage = TryReadInt(headers, "x-per-page") ?? 0;
      result.PrevPage = TryReadInt(headers, "x-prev-page") ?? 0;
      result.Total = TryReadInt(headers, "x-total");
      result.TotalPages = TryReadInt(headers, "x-total-pages");
    }

    return result;
  }
}
