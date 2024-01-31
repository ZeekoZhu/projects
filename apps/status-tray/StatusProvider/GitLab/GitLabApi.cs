using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace Projects.StatusTray.StatusProvider.GitLab;

public interface IGitLabApi
{
  public HttpClient Client { get; }
  [Get("/merge_requests")]
  Task<List<MergeRequestDto>> ListMergeRequests(
    MergeRequestQueryParams queryParams
  );

  [Get("/projects/{id}/merge_requests/{merge_request_iid}")]
  Task<SingleMergeRequestDto> GetMergeRequest(
    [AliasAs("id")] int projectId,
    [AliasAs("merge_request_iid")] int mergeRequestIid,
    [AliasAs("include_diverged_commits_count")]
    bool includeDivergedCommitsCount = false,
    [AliasAs("include_rebase_in_progress")] bool includeRebaseInProgress = false,
    [AliasAs("render_html")] bool renderHtml = false
  );

  [Get("/user")]
  Task<CurrentUserDto> GetCurrentUser();
}

public class MergeRequestQueryParams
{
  [Query(CollectionFormat.Multi), AliasAs("approved_by_ids")] public int[] ApprovedByIds { get; set; }

  [Query(CollectionFormat.Multi), AliasAs("approver_ids")] public int[] ApproverIds { get; set; }

  [AliasAs("approved")] public string Approved { get; set; }

  [AliasAs("assignee_id")] public int? AssigneeId { get; set; }

  [AliasAs("author_id")] public int? AuthorId { get; set; }

  [AliasAs("author_username")] public string AuthorUsername { get; set; }

  [AliasAs("created_after")] public DateTime? CreatedAfter { get; set; }

  [AliasAs("created_before")] public DateTime? CreatedBefore { get; set; }

  [AliasAs("deployed_after")] public DateTime? DeployedAfter { get; set; }

  [AliasAs("deployed_before")] public DateTime? DeployedBefore { get; set; }

  [AliasAs("environment")] public string Environment { get; set; }

  [AliasAs("in")] public string In { get; set; }

  [AliasAs("labels")] public string Labels { get; set; }

  [AliasAs("merge_user_id")] public int? MergeUserId { get; set; }

  [AliasAs("merge_user_username")] public string MergeUserUsername { get; set; }

  [AliasAs("milestone")] public string Milestone { get; set; }

  [AliasAs("my_reaction_emoji")] public string MyReactionEmoji { get; set; }

  [AliasAs("not")] public IDictionary<string, string> Not { get; set; }

  [AliasAs("order_by")] public string OrderBy { get; set; }

  [AliasAs("reviewer_id")] public int? ReviewerId { get; set; }

  [AliasAs("reviewer_username")] public string ReviewerUsername { get; set; }

  [AliasAs("scope")] public string Scope { get; set; }

  [AliasAs("search")] public string Search { get; set; }

  [AliasAs("sort")] public string Sort { get; set; }

  [AliasAs("source_branch")] public string SourceBranch { get; set; }

  [AliasAs("state")] public string State { get; set; }

  [AliasAs("target_branch")] public string TargetBranch { get; set; }

  [AliasAs("updated_after")] public DateTime? UpdatedAfter { get; set; }

  [AliasAs("updated_before")] public DateTime? UpdatedBefore { get; set; }

  [AliasAs("view")] public string View { get; set; }

  [AliasAs("with_labels_details")] public bool? WithLabelsDetails { get; set; }

  [AliasAs("with_merge_status_recheck")]
  public bool? WithMergeStatusRecheck { get; set; }

  [AliasAs("wip")] public string Wip { get; set; }
}

public static class MergeRequestEnums
{
  public static class ApprovedStatus
  {
    public const string Yes = "yes";
    public const string No = "no";
  }

  public static class WipStatus
  {
    public const string Yes = "yes";
    public const string No = "no";
  }

  public static class Scope
  {
    public const string CreatedByMe = "created_by_me";
    public const string AssignedToMe = "assigned_to_me";
    public const string All = "all";
  }

  public static class DetailedMergeStatus
  {
    public const string BlockedStatus = "blocked_status";
    public const string BrokenStatus = "broken_status";
    public const string Checking = "checking";
    public const string Unchecked = "unchecked";
    public const string CiMustPass = "ci_must_pass";
    public const string CiStillRunning = "ci_still_running";
    public const string DiscussionsNotResolved = "discussions_not_resolved";
    public const string DraftStatus = "draft_status";
    public const string ExternalStatusChecks = "external_status_checks";
    public const string Mergeable = "mergeable";
    public const string NotApproved = "not_approved";
    public const string NotOpen = "not_open";
    public const string PoliciesDenied = "policies_denied";
    public const string JiraAssociationMissing = "jira_association_missing";
  }
}

public class MergeRequestAuthorDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Username { get; set; }
  public string State { get; set; }
  public string AvatarUrl { get; set; }
  public string WebUrl { get; set; }
}

public class MergeRequestAssigneeDto : MergeRequestAuthorDto
{
}

public class MergeRequestReviewerDto : MergeRequestAuthorDto
{
}

public class MergeRequestMilestoneDto
{
  public int Id { get; set; }
  public int Iid { get; set; }
  public int ProjectId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string State { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime? DueDate { get; set; }
  public DateTime StartDate { get; set; }
  public string WebUrl { get; set; }
}

public class MergeRequestDto
{
  public int Id { get; set; }
  public int Iid { get; set; }
  public int ProjectId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string State { get; set; }
  public MergeRequestAuthorDto MergedBy { get; set; }
  public MergeRequestAuthorDto MergeUser { get; set; }
  public DateTime? MergedAt { get; set; }
  public DateTime? PreparedAt { get; set; }
  public MergeRequestAuthorDto ClosedBy { get; set; }
  public DateTime? ClosedAt { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string TargetBranch { get; set; }
  public string SourceBranch { get; set; }
  public int Upvotes { get; set; }
  public int Downvotes { get; set; }
  public MergeRequestAuthorDto Author { get; set; }
  public MergeRequestAssigneeDto Assignee { get; set; }
  public IEnumerable<MergeRequestAssigneeDto> Assignees { get; set; }
  public IEnumerable<MergeRequestReviewerDto> Reviewers { get; set; }
  public int SourceProjectId { get; set; }
  public int TargetProjectId { get; set; }
  public IEnumerable<string> Labels { get; set; }
  public bool Draft { get; set; }
  public bool WorkInProgress { get; set; }
  public MergeRequestMilestoneDto Milestone { get; set; }
  public bool MergeWhenPipelineSucceeds { get; set; }
  public string MergeStatus { get; set; }
  public string DetailedMergeStatus { get; set; }
  public string Sha { get; set; }
  public string MergeCommitSha { get; set; }
  public string SquashCommitSha { get; set; }
  public int UserNotesCount { get; set; }
  public bool? DiscussionLocked { get; set; }
  public bool? ShouldRemoveSourceBranch { get; set; }
  public bool? ForceRemoveSourceBranch { get; set; }
  public bool AllowCollaboration { get; set; }
  public bool AllowMaintainerToPush { get; set; }
  public string WebUrl { get; set; }
  public MergeRequestReferencesDto References { get; set; }
  public MergeRequestTimeStatsDto TimeStats { get; set; }
  public bool Squash { get; set; }
  public MergeRequestTaskCompletionStatusDto TaskCompletionStatus { get; set; }
}

public class MergeRequestTimeStatsDto
{
  public int TimeEstimate { get; set; }
  public int TotalTimeSpent { get; set; }
  public string HumanTimeEstimate { get; set; }
  public string HumanTotalTimeSpent { get; set; }
}

public class MergeRequestTaskCompletionStatusDto
{
  public int Count { get; set; }
  public int CompletedCount { get; set; }
}

public class CurrentUserDto
{
  public int Id { get; set; }
  public string Username { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }
  public string State { get; set; }
  public bool Locked { get; set; }
  public string AvatarUrl { get; set; }
  public string WebUrl { get; set; }
  public DateTime CreatedAt { get; set; }
  public string Bio { get; set; }
  public string Location { get; set; }
  public string PublicEmail { get; set; }
  public string Skype { get; set; }
  public string Linkedin { get; set; }
  public string Twitter { get; set; }
  public string Discord { get; set; }
  public string WebsiteUrl { get; set; }
  public string Organization { get; set; }
  public string JobTitle { get; set; }
  public string Pronouns { get; set; }
  public bool Bot { get; set; }
  public object WorkInformation { get; set; }
  public int Followers { get; set; }
  public int Following { get; set; }
  public string LocalTime { get; set; }
  public DateTime LastSignInAt { get; set; }
  public DateTime ConfirmedAt { get; set; }
  public int ThemeId { get; set; }
  public DateTime LastActivityOn { get; set; }
  public int ColorSchemeId { get; set; }
  public int ProjectsLimit { get; set; }
  public DateTime CurrentSignInAt { get; set; }
  public List<UserIdentityDto> Identities { get; set; }
  public bool CanCreateGroup { get; set; }
  public bool CanCreateProject { get; set; }
  public bool TwoFactorEnabled { get; set; }
  public bool External { get; set; }
  public bool PrivateProfile { get; set; }
  public string CommitEmail { get; set; }
}

public class UserIdentityDto
{
  public string Provider { get; set; }
  public string ExternUid { get; set; }
}

public static class CurrentUserEnums
{
  public static class State
  {
    public const string Active = "active";
    public const string Locked = "locked";
  }
}

public class SingleMergeRequestDto
{
  public int Id { get; set; }
  public int Iid { get; set; }
  public int ProjectId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string State { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public object MergeUser { get; set; }
  public DateTime? MergedAt { get; set; }
  public DateTime? PreparedAt { get; set; }
  public object ClosedBy { get; set; }
  public DateTime? ClosedAt { get; set; }
  public string TargetBranch { get; set; }
  public string SourceBranch { get; set; }
  public int UserNotesCount { get; set; }
  public int Upvotes { get; set; }
  public int Downvotes { get; set; }
  public object Author { get; set; }
  public IEnumerable<object> Assignees { get; set; }
  public object Assignee { get; set; }
  public IEnumerable<object> Reviewers { get; set; }
  public int SourceProjectId { get; set; }
  public int TargetProjectId { get; set; }
  public IEnumerable<string> Labels { get; set; }
  public bool Draft { get; set; }
  public bool WorkInProgress { get; set; }
  public object Milestone { get; set; }
  public bool MergeWhenPipelineSucceeds { get; set; }
  public string MergeStatus { get; set; }
  public string DetailedMergeStatus { get; set; }
  public string Sha { get; set; }
  public string MergeCommitSha { get; set; }
  public string SquashCommitSha { get; set; }
  public object DiscussionLocked { get; set; }
  public object ShouldRemoveSourceBranch { get; set; }
  public bool? ForceRemoveSourceBranch { get; set; }
  public string Reference { get; set; } // Deprecated. Use `References` instead.
  public MergeRequestReferencesDto References { get; set; }
  public string WebUrl { get; set; }
  public MergeRequestTimeStatsDto TimeStats { get; set; }
  public bool Squash { get; set; }
  public MergeRequestTaskCompletionStatusDto TaskCompletionStatus { get; set; }
  public bool HasConflicts { get; set; }
  public bool BlockingDiscussionsResolved { get; set; }

  public bool Subscribed { get; set; }
  public string ChangesCount { get; set; }
  public DateTime? LatestBuildStartedAt { get; set; }
  public DateTime? LatestBuildFinishedAt { get; set; }
  public DateTime? FirstDeployedToProductionAt { get; set; }
  public MergeRequestPipelineDto HeadPipeline { get; set; }
  public MergeRequestDiffRefsDto DiffRefs { get; set; }
  public string MergeError { get; set; }
  public bool FirstContribution { get; set; }
  public object User { get; set; }
}

public class MergeRequestReferencesDto
{
  public string Short { get; set; }
  public string Relative { get; set; }
  public string Full { get; set; }
}

public class MergeRequestPipelineDto
{
  public int Id { get; set; }
  public int Iid { get; set; }
  public int ProjectId { get; set; }
  public string Sha { get; set; }
  public string Ref { get; set; }
  public string Status { get; set; }
  public string Source { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string WebUrl { get; set; }
}

public class MergeRequestDiffRefsDto
{
  public string BaseSha { get; set; }
  public string HeadSha { get; set; }
  public string StartSha { get; set; }
}

public static class PipelineEnums
{
  public static class Status
  {

  public const string Created = "created";
  public const string WaitingForResource = "waiting_for_resource";
  public const string Preparing = "preparing";
  public const string Pending = "pending";
  public const string Running = "running";
  public const string Success = "success";
  public const string Failed = "failed";
  public const string Canceled = "canceled";
  public const string Skipped = "skipped";
  public const string Manual = "manual";
  public const string Scheduled = "scheduled";
  }
}
