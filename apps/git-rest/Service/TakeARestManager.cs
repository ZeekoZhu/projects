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
      LastRestTime = DateTime.Now;
    }
  }

  public DateTime LastRestTime { get; private set; } = DateTime.Now;

  private TimeSpan _duration = TimeSpan.FromMinutes(45);

  public event EventHandler<TakeARestEventArgs>? ShouldRest;

  public void SuggestARest()
  {
    // ignore if last rest time is too close
    if (DateTime.Now - LastRestTime < Duration)
    {
      return;
    }

    var duration = DateTime.Now - LastRestTime;
    LastRestTime = DateTime.Now;
    ShouldRest?.Invoke(this, new TakeARestEventArgs(duration));
  }

  public void Start()
  {
    LastRestTime = DateTime.Now;
  }
}
