using ReactiveUI;

namespace Projects.Project42.Dashboard;

public class DashboardStringCardView :
  MarkupViewBase<DashboardStringCardViewModel>
{
  public static readonly RoutedEvent<DashboardCanvasView.CardClickEventArgs>
    CardClickEvent =
      RoutedEvent
        .Register<DashboardStringCardView,
          DashboardCanvasView.CardClickEventArgs>(
          "CardClick", RoutingStrategies.Bubble);

  public DashboardStringCardView()
  {
    this.WhenActivated(d =>
    {
      this.SetupCardBehaviors().DisposeWith(d);
      FocusCardOnClick().DisposeWith(d);
      EmitCardClickOnClick().DisposeWith(d);
    });
  }

  public override void View()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");

    this
      .Focusable(true)
      .IsEnabled(true)
      .Width(300)
      .Height(200)
      .Left(ViewModel.CardViewModel.Position.Select(it => it.X))
      .Top(ViewModel.CardViewModel.Position.Select(it => it.Y))
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

  private IDisposable EmitCardClickOnClick()
  {
    return this.ObserveOnPointerPressed(RoutingStrategies.Bubble)
      .Subscribe(_ =>
      {
        Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
        RaiseEvent(new DashboardCanvasView.CardClickEventArgs(ViewModel)
          { RoutedEvent = CardClickEvent, Source = this });
      });
  }

  private IDisposable FocusCardOnClick()
  {
    return this.ObserveOnPointerPressed()
      .Subscribe(_ => Focus());
  }
}
