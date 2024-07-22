using Projects.AvaloniaUtils.Markup;
using Projects.AvaloniaUtils.Signal;
using Timer = System.Timers.Timer;

namespace Projects.Markup7Gui;

public class TimerView : MarkupViewBase<TimerViewModel>
{
  public TimerView()
  {
    ViewModel = new TimerViewModel();
  }

  public override void View()
  {
    this
      .Styles(
        Style(x => x.OfType<Grid>().Child().Is<Control>())
          .Setter(VerticalAlignmentProperty, VerticalAlignment.Center),
        Style(x => x.OfType<ProgressBar>()).Setter(WidthProperty, 200d),
        Style(x => x.OfType<Slider>()).Setter(WidthProperty, 200d)
      )
      .Content(
        Grid()
          .RowDefinitions("auto,auto,auto,auto")
          .ColumnDefinitions("auto,auto")
          .Children(
            // labels
            TextBlock()
              .Text("Elapsed time: "),
            TextBlock()
              .Row(1)
              .ColumnSpan(2)
              .Text(Model.ElapsedTime.Select(it => it.ToString("g"))),
            TextBlock()
              .Grid(0, 2)
              .Text("Duration: "),

            // input
            ProgressBar()
              .Grid(1)
              .Value(Model.Progress),
            Slider()
              .Grid(1, 2)
              .Minimum(0)
              .Maximum(60)
              .Value(Model.Duration.Select(it => it.TotalSeconds))
              .OnValueChangedHandler((_, args) =>
                Model.Duration.Set(TimeSpan.FromSeconds(args.NewValue))),

            // reset
            Button()
              .Grid(0, 3)
              .Content("Reset")
              .OnClickHandler((_, _) => Model.ResetTimer())
          )
      );
  }
}

public class TimerViewModel : ViewModelBase
{
  private static TimeSpan TimerResolution => TimeSpan.FromMilliseconds(100);
  private readonly Timer _timer = new();
  public readonly State<TimeSpan> ElapsedTime = new(TimeSpan.Zero);

  public readonly State<TimeSpan> Duration = new(TimeSpan.FromSeconds(10));

  public IObservable<double> Progress;

  public TimerViewModel()
  {
    _timer.Interval = TimerResolution.TotalMilliseconds;
    _timer.Elapsed += (_, _) => ElapsedTime.Value += TimerResolution;
    _timer.Start();

    (from duration in Duration
        from elapsed in ElapsedTime
        select elapsed >= duration)
      .Subscribe(isDue =>
      {
        if (isDue)
        {
          _timer.Stop();
        }
        else
        {
          _timer.Start();
        }
      });

    Progress = from duration in Duration
      from elapsed in ElapsedTime
      select elapsed.TotalMilliseconds / duration.TotalMilliseconds * 100d;
  }

  public void ResetTimer()
  {
    ElapsedTime.Value = TimeSpan.Zero;
  }
}
