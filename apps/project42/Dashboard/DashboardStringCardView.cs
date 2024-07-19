using Projects.AvaloniaUtils;
using ReactiveUI;

namespace Projects.Project42.Dashboard;

public class DashboardStringCardView :
  MarkupViewBase<DashboardStringCardViewModel>
{
  public DashboardStringCardView()
  {
    this.WhenActivated(d => { this.SetupCardBehaviors(Model).DisposeWith(d); });
  }

  public override void View()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");

    this
      .Focusable(true)
      .IsEnabled(true)
      .Width(DashboardCanvasConstants.CardSize.Width)
      .Height(DashboardCanvasConstants.CardSize.Height)
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
}
