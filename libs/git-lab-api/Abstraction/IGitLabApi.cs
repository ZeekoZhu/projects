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
  ///   Get all merge requests for this project.
  /// </summary>
  /// <param name="projectId">
  ///   The ID or URL-encoded path of the project owned by the
  ///   authenticated user.
  /// </param>
  /// <param name="requestParams"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public Task<PaginationResult<MergeRequestDto>?> ListProjectMergeRequestsAsync(
    string projectId,
    ListMergeRequestsRequestParams requestParams,
    CancellationToken cancellationToken = default);

  /// <summary>
  /// </summary>
  /// <param name="projectId">
  ///   The ID or URL-encoded path of the project owned by the authenticated user.
  ///   Required.
  /// </param>
  /// <param name="createMergeRequestParams"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public Task<MergeRequestDto> CreateMergeRequestAsync(string projectId,
    CreateMergeRequestParams createMergeRequestParams,
    CancellationToken cancellationToken = default);

  /// <summary>
  ///   Update an existing merge request.
  /// </summary>
  /// <param name="projectId">
  ///   The ID or URL-encoded path of the project owned by the authenticated user.
  ///   Required.
  /// </param>
  /// <param name="mergeRequestIid">
  ///   The ID of a merge request. Required.
  /// </param>
  /// <param name="updateMergeRequestParams"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public Task<MergeRequestDto?> UpdateMergeRequestAsync(
    string projectId,
    string mergeRequestIid,
    UpdateMergeRequestParams updateMergeRequestParams,
    CancellationToken cancellationToken = default);
}

public interface IProjectEndpoint
{
  /// <summary>
  ///   Get a single project.
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
