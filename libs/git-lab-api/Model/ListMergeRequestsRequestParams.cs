namespace Projects.GitLabApi.Model;

/// <summary>
/// Request parameters for listing merge requests.
/// </summary>
public class ListMergeRequestsRequestParams : IPaginationParams
{
  /// <summary>
  /// Returns merge requests which have been approved by all the users with the given id. Maximum of 5. None returns merge requests with no approvals. Any returns merge requests with an approval. Premium and Ultimate only.
  /// </summary>
  public int[]? ApprovedByIds { get; set; }

  /// <summary>
  /// Returns merge requests which have specified all the users with the given id as individual approvers. None returns merge requests without approvers. Any returns merge requests with an approver. Premium and Ultimate only.
  /// </summary>
  public int[]? ApproverIds { get; set; }

  /// <summary>
  /// Filters merge requests by their approved status. yes returns only approved merge requests. no returns only non-approved merge requests. Introduced in GitLab 15.11 with the flag mr_approved_filter. Disabled by default.
  /// </summary>
  public string? Approved { get; set; }

  /// <summary>
  /// Returns merge requests assigned to the given user id. None returns unassigned merge requests. Any returns merge requests with an assignee.
  /// </summary>
  public int? AssigneeId { get; set; }

  /// <summary>
  /// Returns merge requests created by the given user id. Mutually exclusive with author_username. Combine with scope=all or scope=assigned_to_me.
  /// </summary>
  public int? AuthorId { get; set; }

  /// <summary>
  /// Returns merge requests created by the given username. Mutually exclusive with author_id.
  /// </summary>
  public string? AuthorUsername { get; set; }

  /// <summary>
  /// Returns merge requests created on or after the given time. Expected in ISO 8601 format (2019-03-15T08:00:00Z).
  /// </summary>
  public DateTime? CreatedAfter { get; set; }

  /// <summary>
  /// Returns merge requests created on or before the given time. Expected in ISO 8601 format (2019-03-15T08:00:00Z).
  /// </summary>
  public DateTime? CreatedBefore { get; set; }

  /// <summary>
  /// Returns merge requests deployed after the given date/time. Expected in ISO 8601 format (2019-03-15T08:00:00Z).
  /// </summary>
  public DateTime? DeployedAfter { get; set; }

  /// <summary>
  /// Returns merge requests deployed before the given date/time. Expected in ISO 8601 format (2019-03-15T08:00:00Z).
  /// </summary>
  public DateTime? DeployedBefore { get; set; }

  /// <summary>
  /// Returns merge requests deployed to the given environment.
  /// </summary>
  public string? Environment { get; set; }

  /// <summary>
  /// Modify the scope of the search attribute. title, description, or a string joining them with comma. Default is title,description.
  /// </summary>
  public string? In { get; set; }

  /// <summary>
  /// Returns merge requests matching a comma-separated list of labels. None lists all merge requests with no labels. Any lists all merge requests with at least one label. Predefined names are case-insensitive.
  /// </summary>
  public string? Labels { get; set; }

  /// <summary>
  /// Returns merge requests which have been merged by the user with the given user id. Mutually exclusive with merge_user_username. Introduced in GitLab 16.9. Available only when the feature flag mr_merge_user_filter is enabled.
  /// </summary>
  public int? MergeUserId { get; set; }

  /// <summary>
  /// Returns merge requests which have been merged by the user with the given username. Mutually exclusive with merge_user_id. Introduced in GitLab 16.9. Available only when the feature flag mr_merge_user_filter is enabled.
  /// </summary>
  public string? MergeUserUsername { get; set; }

  /// <summary>
  /// Returns merge requests for a specific milestone. None returns merge requests with no milestone. Any returns merge requests that have an assigned milestone.
  /// </summary>
  public string? Milestone { get; set; }

  /// <summary>
  /// Returns merge requests reacted by the authenticated user by the given emoji. None returns issues not given a reaction. Any returns issues given at least one reaction.
  /// </summary>
  public string? MyReactionEmoji { get; set; }

  /// <summary>
  /// Returns merge requests that do not match the parameters supplied. Accepts: labels, milestone, author_id, author_username, assignee_id, assignee_username, reviewer_id, reviewer_username, my_reaction_emoji.
  /// </summary>
  public NotParams? Not { get; set; }

  /// <summary>
  /// Returns requests ordered by created_at, title, or updated_at fields. Default is created_at. Introduced in GitLab 14.8.
  /// </summary>
  public string? OrderBy { get; set; }

  /// <summary>
  /// Returns merge requests which have the user as a reviewer with the given user id. None returns merge requests with no reviewers. Any returns merge requests with any reviewer. Mutually exclusive with reviewer_username.
  /// </summary>
  public int? ReviewerId { get; set; }

  /// <summary>
  /// Returns merge requests which have the user as a reviewer with the given username. None returns merge requests with no reviewers. Any returns merge requests with any reviewer. Mutually exclusive with reviewer_id.
  /// </summary>
  public string? ReviewerUsername { get; set; }

  /// <summary>
  /// Returns merge requests for the given scope: created_by_me, assigned_to_me or all. Defaults to created_by_me.
  /// </summary>
  public string? Scope { get; set; }

  /// <summary>
  /// Search merge requests against their title and description.
  /// </summary>
  public string? Search { get; set; }

  /// <summary>
  /// Returns requests sorted in asc or desc order. Default is desc.
  /// </summary>
  public string? Sort { get; set; }

  /// <summary>
  /// Returns merge requests with the given source branch.
  /// </summary>
  public string? SourceBranch { get; set; }

  /// <summary>
  /// Returns all merge requests or just those that are opened, closed, locked, or merged.
  /// </summary>
  public string? State { get; set; }

  /// <summary>
  /// Returns merge requests with the given target branch.
  /// </summary>
  public string? TargetBranch { get; set; }

  /// <summary>
  /// Returns merge requests updated on or after the given time. Expected in ISO 8601 format (2019-03-15T08:00:00Z).
  /// </summary>
  public DateTime? UpdatedAfter { get; set; }

  /// <summary>
  /// Returns merge requests updated on or before the given time. Expected in ISO 8601 format (2019-03-15T08:00:00Z).
  /// </summary>
  public DateTime? UpdatedBefore { get; set; }

  /// <summary>
  /// If simple, returns the iid, URL, title, description, and basic state of merge request.
  /// </summary>
  public string? View { get; set; }

  /// <summary>
  /// If true, response returns more details for each label in labels field: :name, :color, :description, :description_html, :text_color. Default is false.
  /// </summary>
  public bool? WithLabelsDetails { get; set; }

  /// <summary>
  /// If true, this projection requests (but does not guarantee) that the merge_status field be recalculated asynchronously. Default is false.In GitLab 15.11 and later, enable the restrict_merge_status_recheck feature flag for this attribute to be ignored when requested by users without at least the Developer role.
  /// </summary>
  public bool? WithMergeStatusRecheck { get; set; }

  /// <summary>
  /// Filter merge requests against their wip status. yes to return only draft merge requests, no to return non-draft merge requests.
  /// </summary>
  public string? Wip { get; set; }

  public int Page { get; set; }
  public int PerPage { get; set; }

  public class NotParams
  {
    public string[]? Labels { get; set; }
    public string? Milestone { get; set; }
    public int? AuthorId { get; set; }
    public string? AuthorUsername { get; set; }
    public int? AssigneeId { get; set; }
    public string? AssigneeUsername { get; set; }
    public int? ReviewerId { get; set; }
    public string? ReviewerUsername { get; set; }
    public string? MyReactionEmoji { get; set; }
  }

  public class OrderByParams
  {
    public const string CreatedAt = "created_at";
    public const string Title = "title";
    public const string UpdatedAt = "updated_at";
  }

  public class ScopeParams
  {
    public const string CreatedByMe = "created_by_me";
    public const string AssignedToMe = "assigned_to_me";
    public const string All = "all";
  }

  public class SortParams
  {
    public const string Asc = "asc";
    public const string Desc = "desc";
  }

  public class ViewStateParams
  {
    public const string Simple = "simple";
  }

  public class StateParams
  {
    public const string Opened = "opened";
    public const string Closed = "closed";
    public const string Locked = "locked";
    public const string Merged = "merged";
    public const string All = "all";
  }
}
