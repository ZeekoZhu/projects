using Avalonia.ReactiveUI;
using ReactiveUI;

namespace Projects.Project42.Dashboard;

public interface IDashboardCardViewModel
{
  public CardViewModel CardViewModel { get; }
}

public static class CardViewExtensions
{
  public static IDisposable SetupCardBehaviors<T>(
    this ReactiveUserControl<T> control)
    where T : class, IDashboardCardViewModel
  {
    Debug.Assert(control.ViewModel != null, "control.ViewModel != null");
    var card = control.ViewModel.CardViewModel;
    var d = new CompositeDisposable();

    // move card on drag
    control
      .ObserveOnPointerPressed(RoutingStrategies.Bubble)
      .SelectMany(_ =>
        control.ObserveOnPointerMoved()
          .Select(it => it.GetPosition(control.GetVisualParent<Canvas>()))
          .TakeUntil(control.ObserveOnPointerReleased())
          .Buffer(2, 1)
          .Where(points => points.Count > 1)
          .Select(points => (points[0], points[1]))
          .Select(delta =>
          {
            var (p1, p2) = delta;

            var deltaX = p2.X - p1.X;
            var deltaY = p2.Y - p1.Y;
            return new Point(deltaX, deltaY);
          })
      )
      .InvokeCommand(card.MoveCard)
      .DisposeWith(d);

    // move card on arrow key press
    control.ObserveOnKeyDown(RoutingStrategies.Bubble)
      .Where(ev => ev.Key is Key.Up or Key.Right or Key.Down or Key.Left)
      .Select(ev =>
      {
        return ev.Key switch
        {
          Key.Up => CardViewModel.MovementDirection.Up,
          Key.Down => CardViewModel.MovementDirection.Down,
          Key.Left => CardViewModel.MovementDirection.Left,
          Key.Right => CardViewModel.MovementDirection.Right,
          _ => throw new ArgumentOutOfRangeException()
        };
      })
      .InvokeCommand(card.MoveCardDirection)
      .DisposeWith(d);

    return d;
  }
}
