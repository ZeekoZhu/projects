using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using GitRest.Service;
using ReactiveUI;
using Splat;

namespace GitRest.Component;

public partial class TimerView : ReactiveUserControl<TimerViewViewModel>,
  IEnableLocator, IEnableLogger
{
  private readonly TakeARestManager _takeARest;

  public TimerView()
  {
    _takeARest = this.GetService<TakeARestManager>();
    InitializeComponent();

    ViewModel = new TimerViewViewModel();
    this.WhenActivated(OnActivated);
  }

  private IEnumerable<IDisposable> OnActivated()
  {
    yield return this.OneWayBind(
      ViewModel,
      viewModel => viewModel.WorkingTimeSpans,
      view => view.WorkingDurationSelect.ItemsSource);
    yield return this.Bind(
      ViewModel,
      viewModel => viewModel.WorkingTimeSpanIndex,
      view => view.WorkingDurationSelect.SelectedIndex);

    // monitor timer
    yield return _takeARest.WhenAnyValue(it => it.IsRunning)
      .Select(running => running ? "Stop" : "Start")
      .BindTo(ToggleTimerBtn, view => view.Content);


    // timer label
    yield return _takeARest.WhenAnyValue(vm => vm.Elapsed)
      .Select(it => it.ToString(@"hh\:mm\:ss"))
      .ObserveOn(RxApp.MainThreadScheduler)
      .BindTo(TimerTxt, view => view.Text);

    // toggle btn
    yield return Observable.FromEventPattern<RoutedEventArgs>(
        x => ToggleTimerBtn.Click += x,
        x => ToggleTimerBtn.Click -= x
      )
      .Select(_ => Unit.Default)
      .Do(_ => ViewModel!.ToggleMonitoring())
      .Subscribe();
  }
}
