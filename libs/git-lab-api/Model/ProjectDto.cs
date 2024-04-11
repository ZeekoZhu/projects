namespace Projects.GitLabApi.Model;

/// <summary>
/// Represents a GitLab project.
/// </summary>
public class ProjectDto
{
  /// <summary>
  /// The ID or URL-encoded path of the project.
  /// </summary>
  public required long Id { get; set; }

  /// <summary>
  /// The project description.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  /// The HTML-rendered project description.
  /// </summary>
  public string? DescriptionHtml { get; set; }

  /// <summary>
  /// The default branch of the project.
  /// </summary>
  public required string DefaultBranch { get; set; }

  /// <summary>
  /// The visibility level of the project.
  /// </summary>
  public required string Visibility { get; set; }

  /// <summary>
  /// The SSH URL to the project repository.
  /// </summary>
  public required string SshUrlToRepo { get; set; }

  /// <summary>
  /// The HTTP URL to the project repository.
  /// </summary>
  public required string HttpUrlToRepo { get; set; }

  /// <summary>
  /// The web URL of the project.
  /// </summary>
  public required string WebUrl { get; set; }

  /// <summary>
  /// The URL to the project's README file.
  /// </summary>
  public required string ReadmeUrl { get; set; }

  /// <summary>
  /// The list of tags associated with the project (deprecated, use `Topics` instead).
  /// </summary>
  public required List<string> TagList { get; set; }

  /// <summary>
  /// The list of topics associated with the project.
  /// </summary>
  public required List<string> Topics { get; set; }

  /// <summary>
  /// The owner of the project.
  /// </summary>
  public OwnerDto? Owner { get; set; }

  /// <summary>
  /// The name of the project.
  /// </summary>
  public required string Name { get; set; }

  /// <summary>
  /// The name of the project with its namespace.
  /// </summary>
  public required string NameWithNamespace { get; set; }

  /// <summary>
  /// The path of the project.
  /// </summary>
  public required string Path { get; set; }

  /// <summary>
  /// The path of the project with its namespace.
  /// </summary>
  public required string PathWithNamespace { get; set; }

  /// <summary>
  /// Indicates whether issues are enabled for the project.
  /// </summary>
  public bool IssuesEnabled { get; set; }

  /// <summary>
  /// The number of open issues for the project.
  /// </summary>
  public int OpenIssuesCount { get; set; }

  /// <summary>
  /// Indicates whether merge requests are enabled for the project.
  /// </summary>
  public bool MergeRequestsEnabled { get; set; }

  /// <summary>
  /// Indicates whether jobs are enabled for the project.
  /// </summary>
  public bool JobsEnabled { get; set; }

  /// <summary>
  /// Indicates whether the wiki is enabled for the project.
  /// </summary>
  public bool WikiEnabled { get; set; }

  /// <summary>
  /// Indicates whether snippets are enabled for the project.
  /// </summary>
  public bool SnippetsEnabled { get; set; }

  /// <summary>
  /// Indicates whether the user can create a merge request in the project.
  /// </summary>
  public bool CanCreateMergeRequestIn { get; set; }

  /// <summary>
  /// Indicates whether to resolve outdated diff discussions.
  /// </summary>
  public bool ResolveOutdatedDiffDiscussions { get; set; }

  /// <summary>
  /// Indicates whether the container registry is enabled for the project (deprecated, use `ContainerRegistryAccessLevel` instead).
  /// </summary>
  public bool ContainerRegistryEnabled { get; set; }

  /// <summary>
  /// The access level for the container registry.
  /// </summary>
  public required string ContainerRegistryAccessLevel { get; set; }

  /// <summary>
  /// The access level for security and compliance features.
  /// </summary>
  public required string SecurityAndComplianceAccessLevel { get; set; }

  /// <summary>
  /// The container expiration policy for the project.
  /// </summary>
  public required ContainerExpirationPolicyDto ContainerExpirationPolicy
  {
    get;
    set;
  }

  /// <summary>
  /// The date and time when the project was created.
  /// </summary>
  public DateTime CreatedAt { get; set; }

  /// <summary>
  /// The date and time when the project was last updated.
  /// </summary>
  public DateTime UpdatedAt { get; set; }

  /// <summary>
  /// The date and time of the last activity on the project.
  /// </summary>
  public DateTime LastActivityAt { get; set; }

  /// <summary>
  /// The ID of the user who created the project.
  /// </summary>
  public int CreatorId { get; set; }

  /// <summary>
  /// The namespace of the project.
  /// </summary>
  public required NamespaceDto Namespace { get; set; }

  /// <summary>
  /// The URL to import the project from.
  /// </summary>
  public string? ImportUrl { get; set; }

  /// <summary>
  /// The type of import for the project.
  /// </summary>
  public string? ImportType { get; set; }

  /// <summary>
  /// The status of the import for the project.
  /// </summary>
  public required string ImportStatus { get; set; }

  /// <summary>
  /// The error message for the import, if any.
  /// </summary>
  public string? ImportError { get; set; }

  /// <summary>
  /// The permissions for the project.
  /// </summary>
  public required PermissionsDto Permissions { get; set; }

  /// <summary>
  /// Indicates whether the project is archived.
  /// </summary>
  public bool Archived { get; set; }

  /// <summary>
  /// The URL to the project's avatar.
  /// </summary>
  public required string AvatarUrl { get; set; }

  /// <summary>
  /// The URL to the project's license file.
  /// </summary>
  public string? LicenseUrl { get; set; }

  /// <summary>
  /// The license information for the project.
  /// </summary>
  public LicenseDto? License { get; set; }

  /// <summary>
  /// Indicates whether shared runners are enabled for the project.
  /// </summary>
  public bool SharedRunnersEnabled { get; set; }

  /// <summary>
  /// Indicates whether group runners are enabled for the project.
  /// </summary>
  public bool GroupRunnersEnabled { get; set; }

  /// <summary>
  /// The number of forks for the project.
  /// </summary>
  public int ForksCount { get; set; }

  /// <summary>
  /// The number of stars for the project.
  /// </summary>
  public int StarCount { get; set; }

  /// <summary>
  /// The runners token for the project.
  /// </summary>
  public required string RunnersToken { get; set; }

  /// <summary>
  /// The default Git depth for CI pipelines.
  /// </summary>
  public int CiDefaultGitDepth { get; set; }

  /// <summary>
  /// Indicates whether forward deployment is enabled for CI pipelines.
  /// </summary>
  public bool CiForwardDeploymentEnabled { get; set; }

  /// <summary>
  /// Indicates whether rollback is allowed for forward deployment in CI pipelines.
  /// </summary>
  public bool CiForwardDeploymentRollbackAllowed { get; set; }

  /// <summary>
  /// Indicates whether fork pipelines are allowed to run in the parent project.
  /// </summary>
  public bool CiAllowForkPipelinesToRunInParentProject { get; set; }

  /// <summary>
  /// Indicates whether separated caches are enabled for CI pipelines.
  /// </summary>
  public bool CiSeparatedCaches { get; set; }

  /// <summary>
  /// The role required to cancel pipelines.
  /// </summary>
  public required string CiRestrictPipelineCancellationRole { get; set; }

  /// <summary>
  /// Indicates whether public jobs are enabled for CI pipelines.
  /// </summary>
  public bool PublicJobs { get; set; }

  /// <summary>
  /// The list of groups with which the project is shared.
  /// </summary>
  public List<SharedWithGroupDto>? SharedWithGroups { get; set; }

  /// <summary>
  /// The storage location for the project's repository.
  /// </summary>
  public string? RepositoryStorage { get; set; }

  /// <summary>
  /// Indicates whether merge requests are only allowed if the pipeline succeeds.
  /// </summary>
  public bool OnlyAllowMergeIfPipelineSucceeds { get; set; }

  /// <summary>
  /// Indicates whether merge requests are allowed if the pipeline is skipped.
  /// </summary>
  public bool AllowMergeOnSkippedPipeline { get; set; }

  /// <summary>
  /// Indicates whether user-defined variables are restricted.
  /// </summary>
  public bool RestrictUserDefinedVariables { get; set; }

  /// <summary>
  /// Indicates whether merge requests are only allowed if all discussions are resolved.
  /// </summary>
  public bool OnlyAllowMergeIfAllDiscussionsAreResolved { get; set; }

  /// <summary>
  /// Indicates whether the source branch should be removed after a merge.
  /// </summary>
  public bool RemoveSourceBranchAfterMerge { get; set; }

  /// <summary>
  /// Indicates whether the printing of merge request links is enabled.
  /// </summary>
  public bool PrintingMergeRequestsLinkEnabled { get; set; }

  /// <summary>
  /// Indicates whether request access is enabled for the project.
  /// </summary>
  public bool RequestAccessEnabled { get; set; }

  /// <summary>
  /// The merge method for the project.
  /// </summary>
  public required string MergeMethod { get; set; }

  /// <summary>
  /// The squash option for the project.
  /// </summary>
  public required string SquashOption { get; set; }

  /// <summary>
  /// Indicates whether Auto DevOps is enabled for the project.
  /// </summary>
  public bool AutoDevOpsEnabled { get; set; }

  /// <summary>
  /// The Auto DevOps deployment strategy for the project.
  /// </summary>
  public string? AutoDevOpsDeployStrategy { get; set; }

  /// <summary>
  /// The number of approvals required before merge (deprecated, use merge request approvals API instead).
  /// </summary>
  public int ApprovalsBeforeMerge { get; set; }

  /// <summary>
  /// Indicates whether the project is a mirror.
  /// </summary>
  public bool Mirror { get; set; }

  /// <summary>
  /// The ID of the user who owns the mirror.
  /// </summary>
  public int? MirrorUserId { get; set; }

  /// <summary>
  /// Indicates whether builds are triggered for mirror updates.
  /// </summary>
  public bool MirrorTriggerBuilds { get; set; }

  /// <summary>
  /// Indicates whether only protected branches are mirrored.
  /// </summary>
  public bool OnlyMirrorProtectedBranches { get; set; }

  /// <summary>
  /// Indicates whether diverged branches are overwritten on mirror updates.
  /// </summary>
  public bool MirrorOverwritesDivergedBranches { get; set; }

  /// <summary>
  /// The external authorization classification label for the project.
  /// </summary>
  public string? ExternalAuthorizationClassificationLabel { get; set; }

  /// <summary>
  /// Indicates whether packages are enabled for the project.
  /// </summary>
  public bool PackagesEnabled { get; set; }

  /// <summary>
  /// Indicates whether the service desk is enabled for the project.
  /// </summary>
  public bool ServiceDeskEnabled { get; set; }

  /// <summary>
  /// The service desk email address for the project.
  /// </summary>
  public string? ServiceDeskAddress { get; set; }

  /// <summary>
  /// Indicates whether referenced issues are automatically closed.
  /// </summary>
  public bool AutocloseReferencedIssues { get; set; }

  /// <summary>
  /// The suggested commit message for the project.
  /// </summary>
  public string? SuggestionCommitMessage { get; set; }

  /// <summary>
  /// Indicates whether authentication checks are enforced on uploads.
  /// </summary>
  public bool EnforceAuthChecksOnUploads { get; set; }

  /// <summary>
  /// The merge commit template for the project.
  /// </summary>
  public string? MergeCommitTemplate { get; set; }

  /// <summary>
  /// The squash commit template for the project.
  /// </summary>
  public string? SquashCommitTemplate { get; set; }

  /// <summary>
  /// The issue branch template for the project.
  /// </summary>
  public required string IssueBranchTemplate { get; set; }

  /// <summary>
  /// The date when the project is marked for deletion (deprecated, use `MarkedForDeletionOn` instead).
  /// </summary>
  public string? MarkedForDeletionAt { get; set; }

  /// <summary>
  /// The date when the project is marked for deletion.
  /// </summary>
  public string? MarkedForDeletionOn { get; set; }

  /// <summary>
  /// The list of compliance frameworks associated with the project.
  /// </summary>
  public required List<string> ComplianceFrameworks { get; set; }

  /// <summary>
  /// Indicates whether to warn about potentially unwanted characters.
  /// </summary>
  public bool WarnAboutPotentiallyUnwantedCharacters { get; set; }

  /// <summary>
  /// The statistics for the project.
  /// </summary>
  public StatisticsDto? Statistics { get; set; }

  /// <summary>
  /// The image prefix for the project's container registry.
  /// </summary>
  public required string ContainerRegistryImagePrefix { get; set; }

  /// <summary>
  /// The links related to the project.
  /// </summary>
  public Dictionary<string, string>? Links { get; set; }

  /// <summary>
  /// Indicates whether merge requests are only allowed if all status checks have passed (GitLab Ultimate).
  /// </summary>
  public bool? OnlyAllowMergeIfAllStatusChecksPassed { get; set; }

  /// <summary>
  /// Indicates whether the project is a fork.
  /// </summary>
  public bool? MrDefaultTargetSelf { get; set; }

  /// <summary>
  /// The project from which this project was forked.
  /// </summary>
  public ProjectDto? ForkedFromProject { get; set; }
}

/// <summary>
/// Represents the container expiration policy for a project.
/// </summary>
public class ContainerExpirationPolicyDto
{
  /// <summary>
  /// The cadence of the policy.
  /// </summary>
  public string? Cadence { get; set; }

  /// <summary>
  /// Indicates whether the policy is enabled.
  /// </summary>
  public bool Enabled { get; set; }

  /// <summary>
  /// The number of container images to keep.
  /// </summary>
  public int? KeepN { get; set; }

  /// <summary>
  /// The age threshold for container images to be deleted.
  /// </summary>
  public string? OlderThan { get; set; }

  /// <summary>
  /// The regular expression pattern for container image names to delete.
  /// </summary>
  [Obsolete(
    "This property will be deprecated in GitLab 13.0 in favor of NameRegexDelete.")]
  public string? NameRegex { get; set; }

  /// <summary>
  /// The regular expression pattern for container image names to delete.
  /// </summary>
  public string? NameRegexDelete { get; set; }

  /// <summary>
  /// The regular expression pattern for container image names to keep.
  /// </summary>
  public string? NameRegexKeep { get; set; }

  /// <summary>
  /// The timestamp of the next scheduled run.
  /// </summary>
  public DateTimeOffset? NextRunAt { get; set; }
}

/// <summary>
/// Represents the license information for a project.
/// </summary>
public class LicenseDto
{
  /// <summary>
  /// The key or identifier of the license.
  /// </summary>
  public required string Key { get; set; }

  /// <summary>
  /// The full name of the license.
  /// </summary>
  public required string Name { get; set; }

  /// <summary>
  /// The nickname or short name of the license.
  /// </summary>
  public string? Nickname { get; set; }

  /// <summary>
  /// The URL to the license's HTML page.
  /// </summary>
  public required string HtmlUrl { get; set; }

  /// <summary>
  /// The URL to the license's source text.
  /// </summary>
  public required string SourceUrl { get; set; }
}

/// <summary>
/// Represents a group that the project is shared with.
/// </summary>
public class SharedWithGroupDto
{
  /// <summary>
  /// The ID of the group.
  /// </summary>
  public required int GroupId { get; set; }

  /// <summary>
  /// The name of the group.
  /// </summary>
  public required string GroupName { get; set; }

  /// <summary>
  /// The full path of the group.
  /// </summary>
  public required string GroupFullPath { get; set; }

  /// <summary>
  /// The access level of the group to the project.
  /// </summary>
  public required int GroupAccessLevel { get; set; }
}

/// <summary>
/// Represents the statistics for a project.
/// </summary>
public class StatisticsDto
{
  /// <summary>
  /// The total number of commits in the project.
  /// </summary>
  public required int CommitCount { get; set; }

  /// <summary>
  /// The total size of the project's repository, including LFS objects.
  /// </summary>
  public required long StorageSize { get; set; }

  /// <summary>
  /// The size of the project's repository, excluding LFS objects.
  /// </summary>
  public required long RepositorySize { get; set; }

  /// <summary>
  /// The size of the project's wiki.
  /// </summary>
  public required long WikiSize { get; set; }

  /// <summary>
  /// The size of the project's LFS objects.
  /// </summary>
  public required long LfsObjectsSize { get; set; }

  /// <summary>
  /// The size of the project's job artifacts.
  /// </summary>
  public required long JobArtifactsSize { get; set; }

  /// <summary>
  /// The size of the project's pipeline artifacts.
  /// </summary>
  public required long PipelineArtifactsSize { get; set; }

  /// <summary>
  /// The size of the project's packages.
  /// </summary>
  public required long PackagesSize { get; set; }

  /// <summary>
  /// The size of the project's snippets.
  /// </summary>
  public required long SnippetsSize { get; set; }

  /// <summary>
  /// The size of the project's uploads.
  /// </summary>
  public required long UploadsSize { get; set; }
}

/// <summary>
/// Represents the permissions for the project.
/// </summary>
public class PermissionsDto
{
  /// <summary>
  /// Gets or sets the project access permissions.
  /// </summary>
  public ProjectAccessDto? ProjectAccess { get; set; }

  /// <summary>
  /// Gets or sets the group access permissions.
  /// </summary>
  public GroupAccessDto? GroupAccess { get; set; }
}

/// <summary>
/// Represents the project access permissions.
/// </summary>
public class ProjectAccessDto
{
  /// <summary>
  /// Gets or sets the access level.
  /// </summary>
  public int AccessLevel { get; set; }

  /// <summary>
  /// Gets or sets the notification level.
  /// </summary>
  public int NotificationLevel { get; set; }
}

/// <summary>
/// Represents the group access permissions.
/// </summary>
public class GroupAccessDto
{
  /// <summary>
  /// Gets or sets the access level.
  /// </summary>
  public int AccessLevel { get; set; }

  /// <summary>
  /// Gets or sets the notification level.
  /// </summary>
  public int NotificationLevel { get; set; }
}

/// <summary>
/// Represents the owner of a project.
/// </summary>
public class OwnerDto
{
  /// <summary>
  /// The ID of the owner.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// The name of the owner.
  /// </summary>
  public string Name { get; set; } = null!;

  /// <summary>
  /// The date and time when the owner was created.
  /// </summary>
  public DateTime CreatedAt { get; set; }
}

/// <summary>
/// Represents the namespace of a GitLab project.
/// </summary>
public class NamespaceDto
{
  /// <summary>
  /// The ID of the namespace.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// The name of the namespace.
  /// </summary>
  public string Name { get; set; } = null!;

  /// <summary>
  /// The path of the namespace.
  /// </summary>
  public string Path { get; set; } = null!;

  /// <summary>
  /// The kind of the namespace (e.g., group, user).
  /// </summary>
  public string Kind { get; set; } = null!;

  /// <summary>
  /// The full path of the namespace.
  /// </summary>
  public string FullPath { get; set; } = null!;

  /// <summary>
  /// The URL of the namespace avatar.
  /// </summary>
  public string? AvatarUrl { get; set; }

  /// <summary>
  /// The web URL of the namespace.
  /// </summary>
  public string? WebUrl { get; set; }

  /// <summary>
  /// The ID of the parent namespace, if any.
  /// </summary>
  public int? ParentId { get; set; }
}
