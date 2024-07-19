using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;

namespace Projects.Markup7Gui;

public class CounterView : MarkupViewBase<CounterViewModel>
{
  public CounterView()
  {
    ViewModel = new CounterViewModel();
  }

  public override void View()
  {
    this.Content(
      StackPanel()
        .VerticalAlignmentTop()
        .Height(32)
        .OrientationHorizontal()
        .Children(
          TextBlock()
            .VerticalAlignmentCenter()
            .Margin(new Thickness(0, 0, 10, 0))
            .Text(Model.Count.Select(it => it.ToString())),
          Button()
            .VerticalAlignmentCenter()
            .Content("Count")
            .OnClickHandler((_, _) => Model.Count.Value++)
        )
    );
  }
}

public class CounterViewModel : ViewModelBase
{
  public readonly State<int> Count = new(0);

}

