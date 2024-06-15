using Avalonia.ReactiveUI;
using Projects.AvaloniaUtils;
using Projects.Project42.Markup;
using ReactiveUI;
using Splat;

namespace Projects.Project42;

public class ViewModelBase : ReactiveObject, IEnableLocator;

public abstract class MarkupViewBase<T> : ReactiveUserControl<T>, IEnableLogger, IMarkupView
  where T : class
{
  protected MarkupViewBase()
  {
    this.GetObservable(ViewModelProperty)
      .Where(vm => vm is not null)
      .Take(1)
      .Subscribe(_ =>
      {
        this.Log().Debug("ViewModel set");
        View();
      });
  }

  public abstract void View();
}
