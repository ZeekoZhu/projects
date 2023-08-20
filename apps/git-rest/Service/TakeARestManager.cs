using System;

namespace GitRest.Service;

public class TakeARestManager
{
  public record TakeARestEventArgs(TimeSpan Duration);

  private readonly TimeSpan _duration = TimeSpan.FromMinutes(45);
  private DateTime? _lastRestTime;

  public event EventHandler<TakeARestEventArgs>? ShouldRest;

  public void SuggestARest()
  {
    if (_lastRestTime is not null &&
        DateTime.Now - _lastRestTime < _duration)
    {
      return;
    }

    if (_lastRestTime is not null)
    {
      var duration = DateTime.Now - _lastRestTime.Value;
      ShouldRest?.Invoke(this, new TakeARestEventArgs(duration));
    }
    else
    {
      ShouldRest?.Invoke(this, new TakeARestEventArgs(_duration));
    }

    _lastRestTime = DateTime.Now;
  }
}
