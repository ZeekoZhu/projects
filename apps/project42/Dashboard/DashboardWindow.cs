using static Projects.Project42.Dashboard.MarkupBuilder;

namespace Projects.Project42.Dashboard;

public class DashboardWindow : MarkupWindowBase<DashboardWindowViewModel>
{
  public DashboardWindow()
  {
    ViewModel = new DashboardWindowViewModel();
  }

  public override void View()
  {
    this.Height(600)
      .Width(800)
      .WindowStartupLocation(WindowStartupLocation.CenterScreen)
      .Title("Project 42")
      .Content(
        Panel()
          .Children(
            DashboardCanvasView()
          )
      );
  }
}

public class DashboardWindowViewModel : ViewModelBase
{
}
