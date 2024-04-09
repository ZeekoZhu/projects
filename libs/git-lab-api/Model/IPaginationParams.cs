namespace Projects.GitLabApi.Model;

public interface IPaginationParams
{
  /// <summary>
  /// Page number (default: 1).
  /// </summary>
  public int? Page { get; set; }

  /// <summary>
  /// Number of items to list per page (default: 20, max: 100).
  /// </summary>
  public int? PerPage { get; set; }
}
