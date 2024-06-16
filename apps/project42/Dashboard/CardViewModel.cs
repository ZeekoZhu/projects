using System.Reactive;
using Projects.AvaloniaUtils;
using ReactiveUI;
using Splat;

namespace Projects.Project42.Dashboard;

public class CardViewModel : IEnableLogger, IEnableLocator
{
  public enum MovementDirection
  {
    Up,
    Right,
    Down,
    Left
  }

  public CardViewModel()
  {
    MoveCard = ReactiveCommand.Create((Point p) =>
    {
      Position.SetState(prev => new Point(
        LimitPosition(prev.X + p.X, 1920 - 300),
        LimitPosition(prev.Y + p.Y, 1080 - 200)));
      return;

      double LimitPosition(double value, double max)
      {
        return Math.Max(Math.Min(value, max), 0);
      }
    });

    MoveCardDirection = ReactiveCommand.CreateFromObservable(
      (MovementDirection direction) =>
      {
        this.Log().Debug("Move card direction: {direction}", direction);
        const int step = 10;
        var (x, y) = direction switch
        {
          MovementDirection.Up => (0, -step),
          MovementDirection.Right => (step, 0),
          MovementDirection.Down => (0, step),
          MovementDirection.Left => (-step, 0),
          _ => (0, 0)
        };
        return MoveCard.Execute(new Point(x, y));
      });
  }

  public ReactiveCommand<Point, Unit> MoveCard { get; }

  public ReactiveCommand<MovementDirection, Unit> MoveCardDirection { get; }

  public Stateful<Point> Position { get; } = new(new Point(0, 0));
}
