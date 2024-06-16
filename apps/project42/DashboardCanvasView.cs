using System.Linq;
using System.Reactive;
using ReactiveUI;
using Splat;
using ScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility;

namespace Projects.Project42;

public class
  DashboardCanvasView : MarkupViewBase<DashboardCanvasViewModel>
{
  private Canvas _canvas;

  public DashboardCanvasView()
  {
    ViewModel = new DashboardCanvasViewModel();
    Debug.Assert(_canvas != null, nameof(_canvas) + " != null");
    ViewModel.State.Current.Cards.CollectionChanged += (_, _) =>
    {
      UpdateCanvasCards();
    };
    UpdateCanvasCards();
  }

  private void UpdateCanvasCards()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    var cardControls = ViewModel.State.Current.Cards
      .Select(it => new DashboardStringCardViewModel(it))
      .Select(GetCardView);

    _canvas.Children.Clear();
    _canvas.Children.AddRange(cardControls);
  }

  private Control GetCardView(ViewModelBase vm)
  {
    return vm switch
    {
      DashboardStringCardViewModel m => new DashboardStringCardView
      {
        ViewModel = m
      },
      _ => throw new InvalidOperationException(
        $"Unknown ViewModel type: {vm.GetType().FullName}")
    };
  }

  public override void View()
  {

    this.Content(
      Panel()
        .Children(
          ScrollViewer()
            .HorizontalScrollBarVisibility(ScrollBarVisibility.Auto)
            .VerticalScrollBarVisibility(ScrollBarVisibility.Auto)
            .Content(
              Canvas(out _canvas)
                .Width(1920)
                .Height(1080)
                .Background(Brushes.Gainsboro)

            )
        )
    );
  }
}

public class DashboardCanvasViewModel : ViewModelBase
{
  public Stateful<StateType> State { get; } = new(
    new StateType(["Hello"]));


  public record StateType(ObservableCollection<string> Cards);
}

public class DashboardStringCardView :
  MarkupViewBase<DashboardStringCardViewModel>
{
  public override void View()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    MoveCardOnArrowKeyDown();
    MoveCardOnDrag();
    FocusCardOnClick();

    this
      .Focusable(true)
      .IsEnabled(true)
      .Width(300)
      .Height(200)
      .Left(ViewModel.Position.Select(it => it.X))
      .Top(ViewModel.Position.Select(it => it.Y))
      .Content(
        Border()
          .BorderBrush(Brushes.Black)
          .BorderThickness(1)
          .Padding(8, 8)
          .Background(Brushes.WhiteSmoke)
          .Child(
            StackPanel()
              .Children(
                TextBlock()
                  .Text(ViewModel.Stateful.Select(it => it.Text))
              )
          ));
  }

  private void FocusCardOnClick()
  {
    this.ObserveOnPointerPressed()
      .Subscribe(_ => Focus());
  }

  private void MoveCardOnArrowKeyDown()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    this.ObserveOnKeyDown(RoutingStrategies.Bubble)
      .Log(this, "Keydown", it => it.Key.ToString())
      .Where(ev => ev.Key is Key.Up or Key.Right or Key.Down or Key.Left)
      .Select(ev =>
      {
        return ev.Key switch
        {
          Key.Up => DashboardStringCardViewModel.MovementDirection.Up,
          Key.Down => DashboardStringCardViewModel.MovementDirection.Down,
          Key.Left => DashboardStringCardViewModel.MovementDirection.Left,
          Key.Right => DashboardStringCardViewModel.MovementDirection.Right,
          _ => throw new ArgumentOutOfRangeException()
        };
      })
      .InvokeCommand(ViewModel.MoveCardDirection);
  }

  private void MoveCardOnDrag()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    this.ObserveOnPointerPressed(RoutingStrategies.Bubble)
      .SelectMany(_ =>
        this.ObserveOnPointerMoved()
          .Select(it => it.GetPosition(this.GetVisualParent<Canvas>()))
          .TakeUntil(this.ObserveOnPointerReleased())
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
      .InvokeCommand(ViewModel, vm => vm.MoveCard);
  }
}

public class DashboardStringCardViewModel : ViewModelBase
{
  public enum MovementDirection
  {
    Up,
    Right,
    Down,
    Left
  }

  public DashboardStringCardViewModel(string text)
  {
    Stateful = new Stateful<State>(new State(text));
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

    MoveCardDirection = ReactiveCommand.Create((MovementDirection direction) =>
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
      MoveCard.Execute(new Point(x, y)).Subscribe();
    });
  }

  public ReactiveCommand<Point, Unit> MoveCard { get; }

  public ReactiveCommand<MovementDirection, Unit> MoveCardDirection { get; }

  public Stateful<Point> Position { get; } = new(new Point(0, 0));
  public Stateful<State> Stateful { get; }

  public record State(string Text);
}
