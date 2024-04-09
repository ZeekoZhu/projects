using Projects.GitLabApi.Model;

namespace Projects.GitLabApi.Abstraction;

public interface IGitLabApi
{
  public IProjectEndpoint Project { get; }
  public IMergeRequestEndpoint MergeRequest { get; }
}

public interface IMergeRequestEndpoint
{
  /// <summary>
  /// Get all merge requests for this project.
  /// </summary>
  /// <param name="projectId">The ID or URL-encoded path of the project owned by the authenticated user.</param>
  /// <param name="requestParams"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public Task<PaginationResult<MergeRequestDto>?> ListProjectMergeRequestsAsync(
    string projectId,
    ListMergeRequestsRequestParams requestParams,
    CancellationToken cancellationToken = default);
}

public interface IProjectEndpoint
{
  /// <summary>
  /// Get a single project.
  /// </summary>
  /// The ID or path of the project.
  /// <param name="projectId"></param>
  /// <param name="requestParams"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public Task<ProjectDto?> GetProjectAsync(
    string projectId,
    GetProjectRequestParams requestParams,
    CancellationToken cancellationToken = default);
}
