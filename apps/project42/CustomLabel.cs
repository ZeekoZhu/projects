using System.Reactive;
using Avalonia.ReactiveUI;
using Projects.AvaloniaUtils;
using Projects.Project42.Markup;
using ReactiveUI;
using Splat;

namespace Projects.Project42;

public class CustomLabel : ReactiveUserControl<CustomLabelViewModel>,
  IMarkupView, IEnableLocator,
  IEnableLogger
{
  public static readonly StyledProperty<string> TextProperty =
    AvaloniaProperty.Register<CustomLabel, string>(
      nameof(Text), string.Empty);

  public CustomLabel()
  {
    ViewModel = new CustomLabelViewModel();
    this.Log().Info("View created");
    this.WhenActivated(d =>
    {
      Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
      this.ObserveText()
        .Connect(ViewModel.State, (it, _) => new (Text: it))
        .DisposeWith(d);
    });
    View();
  }

  public string Text
  {
    get => GetValue(TextProperty);
    set => SetValue(TextProperty, value);
  }

  public void View()
  {
    Debug.Assert(ViewModel != null, nameof(ViewModel) + " != null");
    this.Content(
      StackPanel()
        .Children(
          TextBlock()
            .Text(ViewModel.UpperText, BindingMode.OneWay)
            .Foreground(Brushes.DodgerBlue),
          Button()
            .Content("Clear")
            .Command(ViewModel.Clear)
        )
    );
  }
}

public class ViewModelBase : ReactiveObject, IEnableLocator
{
}

public class CustomLabelViewModel : ViewModelBase
{
  public CustomLabelViewModel()
  {
    Clear = ReactiveCommand.Create(() =>
    {
      this.Log().Debug("clear clicked");
      State.SetState(_ => new StateType(string.Empty));
    });
    UpperText = State.Select(it => it.Text);
  }

  public Stateful<StateType> State { get; } = new(new StateType(string.Empty));

  public IObservable<string> UpperText { get; }

  public ReactiveCommand<Unit, Unit> Clear { get; }

  public record StateType(string Text);
}
