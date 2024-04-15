namespace Projects.GitLabApi.Model;

/// <summary>
/// Represents a merge request in GitLab.
/// </summary>
public class MergeRequestDto
{
    /// <summary>
    /// The ID of the merge request.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The internal ID of the merge request.
    /// </summary>
    public required int Iid { get; set; }

    /// <summary>
    /// The ID of the project the merge request belongs to.
    /// </summary>
    public required int ProjectId { get; set; }

    /// <summary>
    /// The title of the merge request.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The description of the merge request.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// The state of the merge request (opened, closed, locked, or merged).
    /// </summary>
    public required string State { get; set; }

    /// <summary>
    /// The user who merged the merge request.
    /// </summary>
    public UserDto? MergedBy { get; set; }

    /// <summary>
    /// The user who merged the merge request.
    /// </summary>
    public UserDto? MergeUser { get; set; }

    /// <summary>
    /// The timestamp when the merge request was merged.
    /// </summary>
    public DateTimeOffset? MergedAt { get; set; }

    /// <summary>
    /// The timestamp when the merge request was prepared.
    /// </summary>
    public DateTimeOffset? PreparedAt { get; set; }

    /// <summary>
    /// The user who closed the merge request.
    /// </summary>
    public UserDto? ClosedBy { get; set; }

    /// <summary>
    /// The timestamp when the merge request was closed.
    /// </summary>
    public DateTimeOffset? ClosedAt { get; set; }

    /// <summary>
    /// The timestamp when the merge request was created.
    /// </summary>
    public required DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the merge request was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// The target branch of the merge request.
    /// </summary>
    public required string TargetBranch { get; set; }

    /// <summary>
    /// The source branch of the merge request.
    /// </summary>
    public required string SourceBranch { get; set; }

    /// <summary>
    /// The number of upvotes for the merge request.
    /// </summary>
    public required int Upvotes { get; set; }

    /// <summary>
    /// The number of downvotes for the merge request.
    /// </summary>
    public required int Downvotes { get; set; }

    /// <summary>
    /// The author of the merge request.
    /// </summary>
    public required UserDto Author { get; set; }

    /// <summary>
    /// The assignee of the merge request.
    /// </summary>
    public UserDto? Assignee { get; set; }

    /// <summary>
    /// The list of assignees for the merge request.
    /// </summary>
    public required List<UserDto> Assignees { get; set; }

    /// <summary>
    /// The list of reviewers for the merge request.
    /// </summary>
    public required List<UserDto> Reviewers { get; set; }

    /// <summary>
    /// The ID of the source project for the merge request.
    /// </summary>
    public required int SourceProjectId { get; set; }

    /// <summary>
    /// The ID of the target project for the merge request.
    /// </summary>
    public required int TargetProjectId { get; set; }

    /// <summary>
    /// The labels associated with the merge request.
    /// </summary>
    public required List<string> Labels { get; set; }

    /// <summary>
    /// Indicates whether the merge request is a draft.
    /// </summary>
    public required bool Draft { get; set; }

    /// <summary>
    /// Indicates whether the merge request is a work in progress.
    /// </summary>
    public required bool WorkInProgress { get; set; }

    /// <summary>
    /// The milestone associated with the merge request.
    /// </summary>
    public MilestoneDto? Milestone { get; set; }

    /// <summary>
    /// Indicates whether the merge request should be merged when the pipeline succeeds.
    /// </summary>
    public required bool MergeWhenPipelineSucceeds { get; set; }

    /// <summary>
    /// The merge status of the merge request.
    /// </summary>
    public required string MergeStatus { get; set; }

    /// <summary>
    /// The detailed merge status of the merge request.
    /// </summary>
    public required string DetailedMergeStatus { get; set; }

    /// <summary>
    /// The SHA of the merge request.
    /// </summary>
    public required string Sha { get; set; }

    /// <summary>
    /// The SHA of the merge commit, if any.
    /// </summary>
    public string? MergeCommitSha { get; set; }

    /// <summary>
    /// The SHA of the squash commit, if any.
    /// </summary>
    public string? SquashCommitSha { get; set; }

    /// <summary>
    /// The number of user notes associated with the merge request.
    /// </summary>
    public required int UserNotesCount { get; set; }

    /// <summary>
    /// Indicates whether the discussion is locked.
    /// </summary>
    public bool? DiscussionLocked { get; set; }

    /// <summary>
    /// Indicates whether the source branch should be removed after merging.
    /// </summary>
    public bool? ShouldRemoveSourceBranch { get; set; }

    /// <summary>
    /// Indicates whether the source branch should be forcibly removed after merging.
    /// </summary>
    public bool? ForceRemoveSourceBranch { get; set; }

    /// <summary>
    /// Indicates whether collaboration is allowed.
    /// </summary>
    public bool? AllowCollaboration { get; set; }

    /// <summary>
    /// Indicates whether maintainers are allowed to push.
    /// </summary>
    public bool? AllowMaintainerToPush { get; set; }

    /// <summary>
    /// The web URL of the merge request.
    /// </summary>
    public required string WebUrl { get; set; }

    /// <summary>
    /// The references for the merge request.
    /// </summary>
    public required ReferenceDto References { get; set; }

    /// <summary>
    /// The time statistics for the merge request.
    /// </summary>
    public required TimeStatsDto TimeStats { get; set; }

    /// <summary>
    /// Indicates whether the merge request should be squashed.
    /// </summary>
    public required bool Squash { get; set; }

    /// <summary>
    /// The task completion status for the merge request.
    /// </summary>
    public required TaskCompletionStatusDto TaskCompletionStatus { get; set; }
}

/// <summary>
/// Represents a reference for a merge request.
/// </summary>
public class ReferenceDto
{
    /// <summary>
    /// The short reference for the merge request.
    /// </summary>
    public required string Short { get; set; }

    /// <summary>
    /// The relative reference for the merge request.
    /// </summary>
    public required string Relative { get; set; }

    /// <summary>
    /// The full reference for the merge request.
    /// </summary>
    public required string Full { get; set; }
}

/// <summary>
/// Represents a user in GitLab.
/// </summary>
public class UserDto
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The name of the user.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The username of the user.
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// The current state of the user.
    /// </summary>
    public required string State { get; set; }

    /// <summary>
    /// The URL of the user's avatar image.
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// The web URL of the user's profile.
    /// </summary>
    public required string WebUrl { get; set; }
}

/// <summary>
/// Represents a milestone in GitLab.
/// </summary>
public class MilestoneDto
{
    /// <summary>
    /// The unique identifier of the milestone.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// The internal ID of the milestone.
    /// </summary>
    public required int Iid { get; set; }

    /// <summary>
    /// The project ID of the milestone.
    /// </summary>
    public required int ProjectId { get; set; }

    /// <summary>
    /// The title of the milestone.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// The description of the milestone.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The state of the milestone.
    /// </summary>
    public required string State { get; set; }

    /// <summary>
    /// The timestamp when the milestone was created.
    /// </summary>
    public required DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the milestone was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// The due date of the milestone.
    /// </summary>
    public DateTimeOffset? DueDate { get; set; }

    /// <summary>
    /// The start date of the milestone.
    /// </summary>
    public DateTimeOffset? StartDate { get; set; }

    /// <summary>
    /// The web URL of the milestone.
    /// </summary>
    public required string WebUrl { get; set; }
}

/// <summary>
/// Represents time statistics for a merge request.
/// </summary>
public class TimeStatsDto
{
    /// <summary>
    /// The estimated time for the merge request.
    /// </summary>
    public required int TimeEstimate { get; set; }

    /// <summary>
    /// The total time spent on the merge request.
    /// </summary>
    public required int TotalTimeSpent { get; set; }

    /// <summary>
    /// The human-readable representation of the estimated time.
    /// </summary>
    public string? HumanTimeEstimate { get; set; }

    /// <summary>
    /// The human-readable representation of the total time spent.
    /// </summary>
    public string? HumanTotalTimeSpent { get; set; }
}

/// <summary>
/// Represents the task completion status for a merge request.
/// </summary>
public class TaskCompletionStatusDto
{
    /// <summary>
    /// The total number of tasks.
    /// </summary>
    public required int Count { get; set; }

    /// <summary>
    /// The number of completed tasks.
    /// </summary>
    public required int CompletedCount { get; set; }
}
