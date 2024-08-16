using System.Linq;
using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;
using Projects.AvaloniaUtils.Styling;
using R3;
using static Projects.AvaloniaUtils.Styling.StyleBuilder;

namespace Projects.Markup7Gui;

public class CircleDrawerView : MarkupViewBase<CircleDrawerViewModel>
{
  public CircleDrawerView()
  {
    ViewModel = new CircleDrawerViewModel();
  }

  public override void View()
  {
    this.Styles(
        StyleOf<StackPanel>(out var buttons)
          .Margin(m => m.Y(8))
          .HorizontalCenter()
          .OrientationHorizontal(),
        StyleOf<Border>(out var canvas)
          .Width(400)
          .Height(400)
          .BorderBrush(Brushes.Firebrick)
          .BorderWidth(w => w.All(1))
      )
      .Content(
        StackPanel()
          .Children(
            StackPanel()
              .Classes(buttons)
              .Children(
                Button()
                  .Content("undo"),
                Button()
                  .Content("redo")
              ),
            Border()
              .Classes(canvas)
              .Child(
                Canvas()
              )
          )
      );
  }
}

public class CircleDrawerViewModel : ViewModelBase
{
  public readonly ReactiveProperty<int> Count = new(0);
}

public class Solution
{
  public string[][] Main(string[] words)
  {
    return words.ToLookup(word => string.Join("", word.Order()))
      .Select(g => g.ToArray())
      .ToArray();
  }
}
