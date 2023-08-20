using System;

namespace GitRest.Service;

public class TakeARestManager
{
  public record TakeARestEventArgs(TimeSpan Duration);

  public TimeSpan Duration
  {
    get => _duration;
    set
    {
      _duration = value;
      _lastRestTime = null;
    }
  }

  private DateTime? _lastRestTime;
  private TimeSpan _duration = TimeSpan.FromMinutes(45);

  public event EventHandler<TakeARestEventArgs>? ShouldRest;

  public void SuggestARest()
  {
    if (_lastRestTime is not null &&
        DateTime.Now - _lastRestTime < Duration)
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
      ShouldRest?.Invoke(this, new TakeARestEventArgs(Duration));
    }

    _lastRestTime = DateTime.Now;
  }
}
