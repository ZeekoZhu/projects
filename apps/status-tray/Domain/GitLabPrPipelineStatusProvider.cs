using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using NGitLab;
using NGitLab.Models;
using Splat;

namespace Projects.StatusTray.Domain;

public class GitLabPrPipelineStatusProvider : IStatusProvider, IEnableLogger
{
  private readonly GitLabClient _client;

  public GitLabPrPipelineStatusProvider(GitLabStatusProviderConfig config)
  {
    this.Log().Debug("GitLabPrPipelineStatusProvider created");

    _client =
      new GitLabClient("https://gitlab.com", config.PersonalAccessToken);

    StatusUpdates = Observable.Interval(TimeSpan.FromMinutes(1))
      .StartWith(0)
      .SelectMany(_ => GetPipelineStatusOfCurrentUser())
      .Do(status => this.Log().Debug("Status: {Status}", status))
      .Catch(Observable.Return(new List<StatusInfo>()))
      .Replay(1)
      .RefCount();
  }


  public IObservable<IList<StatusInfo>> StatusUpdates { get; }

  private Task<List<StatusInfo>> GetPipelineStatusOfCurrentUser()
  {
    return Task.Run(() =>
    {
      this.Log().Debug("GetPipelineStatusOfCurrentUser");
      var requests = _client.MergeRequests
        .Get(new MergeRequestQuery
          { Scope = "all", State = MergeRequestState.opened }).ToList();
      return requests.Select(mr => new StatusInfo
      {
        Id = $"gitlab-pr-pipeline-{mr.Id}-{mr.HeadPipeline.Id}",
        Name = mr.Title,
        State = mr.HeadPipeline.Status switch
        {
          JobStatus.Failed => StatusState.Red,
          _ => StatusState.Green
        }
      }).ToList();
    });
  }
}

public class GitLabStatusProviderConfig
{
  public string PersonalAccessToken { get; set; }
}
