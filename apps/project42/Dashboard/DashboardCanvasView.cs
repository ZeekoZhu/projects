using System.Reactive;
using DynamicData;
using DynamicData.Binding;
using Projects.Project42.Extensions;
using ReactiveUI;
using ScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility;

namespace Projects.Project42.Dashboard;

public class
  DashboardCanvasView : MarkupViewBase<DashboardCanvasViewModel>
{
  public static readonly RoutedEvent<CardClickEventArgs> CardClickEvent =
    RoutedEvent.Register<DashboardCanvasView, CardClickEventArgs>(
      "CardClick", RoutingStrategies.Bubble);

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
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
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
    return ViewModel.Cards.Connect()
      .Transform(GetCardView)
      .ApplyChangesTo(list);
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

  private void BringCardToTopOnClickCard()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    this.GetObservable(DashboardStringCardView.CardClickEvent)
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

  public class CardClickEventArgs(DashboardStringCardViewModel cardViewModel)
    : RoutedEventArgs
  {
    public DashboardStringCardViewModel CardViewModel { get; } = cardViewModel;
  }
}

public class DashboardCanvasViewModel : ViewModelBase
{
  public readonly SourceList<DashboardStringCardViewModel> Cards = new();

  public DashboardCanvasViewModel()
  {
    Cards.AddRange([
      new DashboardStringCardViewModel("Hello"),
      new DashboardStringCardViewModel("World")
    ]);

    BringToTop = ReactiveCommand.Create((DashboardStringCardViewModel card) =>
    {
      Cards.Edit(list =>
      {
        var index = list.IndexOf(card);
        list.Move(index, list.Count - 1);
      });
    });
  }

  public ReactiveCommand<DashboardStringCardViewModel, Unit> BringToTop { get; }
}
