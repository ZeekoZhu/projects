using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Projects.StatusTray.StatusProvider.GitLab;
using Splat;

namespace Projects.StatusTray.Domain;

public class GitLabPrPipelineStatusProvider : IStatusProvider, IEnableLogger
{
  private readonly IGitLabApi _client;

  public GitLabPrPipelineStatusProvider(IGitLabApi client)
  {
    _client = client;
    this.Log().Debug("GitLabPrPipelineStatusProvider created");

    StatusUpdates = Observable.Interval(TimeSpan.FromMinutes(1))
      .StartWith(0)
      .SelectMany(_ => GetPipelineStatusOfCurrentUser())
      .Catch((Exception e) =>
      {
        this.Log().Error("Error while getting status:\n{Error}", e);
        return Observable.Return(new List<StatusInfo>());
      })
      .Replay(1)
      .RefCount();
  }


  public IObservable<IList<StatusInfo>> StatusUpdates { get; }

  private async Task<List<StatusInfo>> GetPipelineStatusOfCurrentUser()
  {
    this.Log().Debug("GetPipelineStatusOfCurrentUser");
    var currentUser = await _client.GetCurrentUser();
    this.Log().Debug("Current user: {User}", currentUser);
    var myAuthoredMr = _client.ListMergeRequests(new MergeRequestQueryParams
    {
      Scope = MergeRequestEnums.Scope.All,
      AuthorId = currentUser.Id
    });
    var myAssignedMr = _client.ListMergeRequests(new MergeRequestQueryParams
    {
      Scope = MergeRequestEnums.Scope.All,
      AssigneeId = currentUser.Id
    });

    var mrWithFailedPipeline = await Observable
      .FromAsync(() => Task.WhenAll(myAuthoredMr, myAssignedMr))
      .Select(it => it.SelectMany(iit => iit))
      .SelectMany(it => Task.WhenAll(it.Select(mr =>
        _client.GetMergeRequest(mr.ProjectId, mr.Iid))))
      .Select(it => it.Where(mr =>
        mr.HeadPipeline.Status == PipelineEnums.Status.Failed).ToList())
      .ToTask();
    this.Log().Debug("Found {Count} MRs with failed pipeline",
      mrWithFailedPipeline.Count);
    return mrWithFailedPipeline.Select(it => new StatusInfo
    {
      Id = $"gitlab-mr-{it.ProjectId}-{it.Id}",
      Name = $"MR #{it.Iid} {it.Title}",
      State = StatusState.Red,
      OnGoToDetails = (info) =>
      {
        // todo: Open browser
      }
    }).ToList();
  }
}

public class GitLabStatusProviderConfig
{
  public string PersonalAccessToken { get; set; }
}

