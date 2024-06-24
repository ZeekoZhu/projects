using Avalonia.ReactiveUI;
using Projects.AvaloniaUtils;
using Projects.Project42.Markup;
using ReactiveUI;
using Splat;

namespace Projects.Project42;

public class ViewModelBase : ReactiveObject, IEnableLocator;

public abstract class MarkupViewBase<T> : ReactiveUserControl<T>, IEnableLogger, IMarkupView, IEnableLocator
  where T : class
{
  protected T Model => ViewModel ?? throw new InvalidOperationException("ViewModel is null");
  protected MarkupViewBase()
  {
    var logger = this.GetService<ILogManager>().GetLogger(typeof(T));
    this.GetObservable(ViewModelProperty)
      .Where(vm => vm is not null)
      .Take(1)
      .Subscribe(_ =>
      {
        logger.Debug("ViewModel set");
        View();
      });
  }

  public abstract void View();
}
