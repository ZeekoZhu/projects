using System.Reactive;
using DynamicData;
using DynamicData.Binding;
using Projects.Project42.Extensions;
using ReactiveUI;
using Splat;
using ScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility;

namespace Projects.Project42.Dashboard;

public class
  DashboardCanvasView : MarkupViewBase<DashboardCanvasViewModel>
{
  private Canvas _canvas;

  public DashboardCanvasView()
  {
    ViewModel = new DashboardCanvasViewModel();
    Debug.Assert(_canvas != null, nameof(_canvas) + " != null");
    this.WhenActivated(d =>
    {
      UpdateCanvasCards()
        .DisposeWith(d);
    });
  }

  private IDisposable UpdateCanvasCards()
  {
    var list = _canvas.Children;
    list.ObserveCollectionChanges()
      .Subscribe(
        _ =>
        {
          for (var i = 0; i < list.Count; i++)
          {
            var ctrl = list[i];
            ctrl.ZIndex(i);
          }
        }
      );
    return Model.Cards.Connect()
      .Transform(GetCardView)
      .ApplyChangesTo(list);
  }

  private static Control GetCardView(IDashboardCardViewModel vm)
  {
    return vm switch
    {
      DashboardStringCardViewModel m => new DashboardStringCardView
      {
        ViewModel = m
      },
      DashboardCommentCardViewModel m => new DashboardCommentCardView
      {
        ViewModel = m
      },
      DashboardShellCommandCardViewModel m => new DashboardShellCommandCardView
      {
        ViewModel = m
      },
      _ => throw new InvalidOperationException(
        $"Unknown ViewModel type: {vm.GetType().FullName}")
    };
  }

  private void BringCardToTopOnClickCard()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    this.GetObservable(DashboardCanvasEvents.CardFocusedEvent)
      .Select(ev => ev.CardViewModel)
      .InvokeCommand(ViewModel.BringToTop);
  }

  public override void View()
  {
    BringCardToTopOnClickCard();
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
  public readonly SourceList<IDashboardCardViewModel> Cards = new();

  public DashboardCanvasViewModel()
  {
    Cards.AddRange([
      new DashboardCommentCardViewModel(),
      new DashboardStringCardViewModel("Hello"),
      new DashboardShellCommandCardViewModel()
    ]);

    BringToTop = ReactiveCommand.Create((IDashboardCardViewModel card) =>
    {
      this.Log().Debug("BringToTop {CardType}", card.GetType());
      Cards.Edit(list =>
      {
        var index = list.IndexOf(card);
        if (index == list.Count - 1)
        {
          this.Log().Debug("BringToTop {CardType}: no need", card.GetType());
          return;
        }

        list.Move(index, list.Count - 1);
      });
    });
  }

  public ReactiveCommand<IDashboardCardViewModel, Unit> BringToTop { get; }
}

public static class DashboardCanvasEvents
{
// Register the attached event
  public static readonly RoutedEvent<CardFocusedEventArgs> CardFocusedEvent =
    RoutedEvent.Register<CardFocusedEventArgs>(
      "CardFocused",
      RoutingStrategies.Bubble,
      typeof(DashboardCanvasEvents));

  public class CardFocusedEventArgs(IDashboardCardViewModel cardViewModel)
    : RoutedEventArgs
  {
    public IDashboardCardViewModel CardViewModel { get; } = cardViewModel;

  }

    public static void RaiseCardFocused(Interactive control, IDashboardCardViewModel vm)
    {
      control.RaiseEvent(new CardFocusedEventArgs(vm)
      {
        Source = control,
        RoutedEvent = CardFocusedEvent
      });
    }

}
