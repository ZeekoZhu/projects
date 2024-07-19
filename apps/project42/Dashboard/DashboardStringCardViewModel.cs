using Projects.AvaloniaUtils;

namespace Projects.Project42.Dashboard;

public class DashboardStringCardViewModel(string text) : ViewModelBase, IDashboardCardViewModel
{
  public CardViewModel CardViewModel { get; } = new();

  public Stateful<State> Stateful { get; } = new(new State(text));

  public record State(string Text);
}
