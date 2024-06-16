using System.Reactive;
using Projects.AvaloniaUtils;
using Projects.Project42.Extensions;
using ReactiveUI;
using Splat;

namespace Projects.Project42.Dashboard;

public static class DashboardCanvasConstants
{
  public static readonly Size CardSize = new(300, 200);
  public static readonly Size CanvasSize = new(1920, 1080);
}

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
      Position.SetState(prev =>
        (prev + p)
        .Constraint(new Point(0, 0),
          (DashboardCanvasConstants.CanvasSize -
           DashboardCanvasConstants.CardSize).ToPoint()));
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
