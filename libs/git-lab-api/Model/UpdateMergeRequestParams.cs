namespace Projects.GitLabApi.Model;

/// <summary>
///   Represents the request parameters for updating a merge request.
/// </summary>
public class UpdateMergeRequestParams
{
  /// <summary>
  ///   Comma-separated label names to add to a merge request.
  /// </summary>
  public List<string>? AddLabels { get; set; }

  /// <summary>
  ///   Allow commits from members who can merge to the target branch.
  /// </summary>
  public bool? AllowCollaboration { get; set; }

  /// <summary>
  ///   The ID of the user to assign the merge request to. Set to 0 or provide an
  ///   empty value to unassign all assignees.
  /// </summary>
  public int? AssigneeId { get; set; }

  /// <summary>
  ///   The ID of the users to assign the merge request to. Set to 0 or provide an
  ///   empty value to unassign all assignees.
  /// </summary>
  public List<int>? AssigneeIds { get; set; }

  /// <summary>
  ///   Description of the merge request. Limited to 1,048,576 characters.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  ///   Flag indicating if the merge request’s discussion is locked. If the
  ///   discussion is locked only project members can add, edit or resolve comments.
  /// </summary>
  public bool? DiscussionLocked { get; set; }

  /// <summary>
  ///   Comma-separated label names for a merge request. Set to an empty string to
  ///   unassign all labels.
  /// </summary>
  public List<string>? Labels { get; set; }

  /// <summary>
  ///   The global ID of a milestone to assign the merge request to. Set to 0 or
  ///   provide an empty value to unassign a milestone.
  /// </summary>
  public int? MilestoneId { get; set; }

  /// <summary>
  ///   Comma-separated label names to remove from a merge request.
  /// </summary>
  public List<string>? RemoveLabels { get; set; }

  /// <summary>
  ///   Flag indicating if a merge request should remove the source branch when
  ///   merging.
  /// </summary>
  public bool? RemoveSourceBranch { get; set; }

  /// <summary>
  ///   The ID of the users set as a reviewer to the merge request. Set the value to
  ///   0 or provide an empty value to unset all reviewers.
  /// </summary>
  public List<int>? ReviewerIds { get; set; }

  /// <summary>
  ///   Indicates if the merge request is set to be squashed when merged. Project
  ///   settings may override this value.
  /// </summary>
  public bool? Squash { get; set; }

  /// <summary>
  ///   New state (close/reopen).
  /// </summary>
  public string? StateEvent { get; set; }

  /// <summary>
  ///   The target branch.
  /// </summary>
  public string? TargetBranch { get; set; }

  /// <summary>
  ///   Title of MR.
  /// </summary>
  public string? Title { get; set; }
}

/// <summary>
///   Enumeration class for state events.
/// </summary>
public static class StateEventEnum
{
  /// <summary>
  ///   Represents the state event for closing a merge request.
  /// </summary>
  public static readonly string Close = "close";

  /// <summary>
  ///   Represents the state event for reopening a merge request.
  /// </summary>
  public static readonly string Reopen = "reopen";
}
