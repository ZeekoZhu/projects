namespace Projects.GitLabApi.Model;

/// <summary>
/// Represents the request parameters for getting a specific project.
/// </summary>
public class GetProjectRequestParams
{

  /// <summary>
  /// Include project license data.
  /// </summary>
  public bool? License { get; set; }

  /// <summary>
  /// Include project statistics. Available only to users with at least the Reporter role.
  /// </summary>
  public bool? Statistics { get; set; }

  /// <summary>
  /// Include custom attributes in response. (administrators only)
  /// </summary>
  public bool? WithCustomAttributes { get; set; }
}
