namespace Projects.GitLabApi.Model;

public class PaginationResult<T>
{
  public PaginationInfo Pagination { get; set; }
  public T[] Items { get; set; }
}

public class PaginationInfo
{
  /// <summary>
  /// The index of the next page.
  /// </summary>
  public int NextPage { get; set; }

  /// <summary>
  /// The index of the current page (starting at 1).
  /// </summary>
  public int Page { get; set; }

  /// <summary>
  /// The number of items per page.
  /// </summary>
  public int PerPage { get; set; }

  /// <summary>
  /// The index of the previous page.
  /// </summary>
  public int PrevPage { get; set; }

  /// <summary>
  /// The total number of items. GitLab may return null for this field for performance reasons.
  /// </summary>
  public int? Total { get; set; }

  /// <summary>
  /// The total number of pages. GitLab may return null for this field for performance reasons.
  /// </summary>
  public int? TotalPages { get; set; }
}
