namespace Projects.GitLabApi.Model;

/// <summary>
///   Represents a merge request DTO for creating a new merge request.
/// </summary>
public class CreateMergeRequestParams
{
  /// <summary>
  ///   The source branch.
  /// </summary>
  public required string SourceBranch { get; set; }

  /// <summary>
  ///   The target branch.
  /// </summary>
  public required string TargetBranch { get; set; }

  /// <summary>
  ///   Title of the merge request.
  /// </summary>
  public required string Title { get; set; }

  /// <summary>
  ///   Allow commits from members who can merge to the target branch.
  /// </summary>
  public bool? AllowCollaboration { get; set; }

  /// <summary>
  ///   Number of approvals required before this can be merged.
  /// </summary>
  public int? ApprovalsBeforeMerge { get; set; }

  /// <summary>
  ///   Alias of allow_collaboration.
  /// </summary>
  public bool? AllowMaintainerToPush { get; set; }

  /// <summary>
  ///   Assignee user ID.
  /// </summary>
  public int? AssigneeId { get; set; }

  /// <summary>
  ///   The ID of the users to assign the merge request to.
  /// </summary>
  public int[]? AssigneeIds { get; set; }

  /// <summary>
  ///   Description of the merge request. Limited to 1,048,576 characters.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  ///   Labels for the merge request, as a comma-separated list.
  /// </summary>
  public string? Labels { get; set; }

  /// <summary>
  ///   The global ID of a milestone.
  /// </summary>
  public int? MilestoneId { get; set; }

  /// <summary>
  ///   Flag indicating if a merge request should remove the source branch when
  ///   merging.
  /// </summary>
  public bool? RemoveSourceBranch { get; set; }

  /// <summary>
  ///   The ID of the users added as a reviewer to the merge request.
  /// </summary>
  public int[]? ReviewerIds { get; set; }

  /// <summary>
  ///   Indicates if the merge request is set to be squashed when merged.
  /// </summary>
  public bool Squash { get; set; }

  /// <summary>
  ///   Numeric ID of the target project.
  /// </summary>
  public int? TargetProjectId { get; set; }
}
