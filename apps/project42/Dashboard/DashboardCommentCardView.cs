using System.Reactive;
using Projects.AvaloniaUtils;
using ReactiveUI;
using Splat;

namespace Projects.Project42.Dashboard;

public class DashboardCommentCardView :
  MarkupViewBase<DashboardCommentCardViewModel>
{
  public DashboardCommentCardView()
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
                TextBox()
                  .OnPointerPressedHandler((_, _) =>
                    DashboardCanvasEvents.RaiseCardFocused(this, Model))
                  .Text(ViewModel.Comment.Binding(BindingMode.TwoWay))
              )
          )
      );
  }
}

public class DashboardCommentCardViewModel : ViewModelBase,
  IDashboardCardViewModel
{
  public DashboardCommentCardViewModel()
  {
    UpdateComment = ReactiveCommand.Create((string content) =>
    {
      this.Log().Debug("Update comment {Comment}", content);
      Comment.SetState(content);
    });
  }

  public ReactiveCommand<string, Unit> UpdateComment { get; }

  public Stateful<string> Comment { get; } = new("Leave some comments here");
  public CardViewModel CardViewModel { get; } = new();
}
