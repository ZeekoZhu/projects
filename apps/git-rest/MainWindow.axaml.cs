using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using GitRest.Service;
using ReactiveUI;
using Splat;

namespace GitRest;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>,
  IEnableLogger, IEnableLocator
{
  private readonly TakeARestManager _takeARest;

  public MainWindow()
  {
    _takeARest = this.GetService<TakeARestManager>();
    InitializeComponent(attachDevTools: true);
    ViewModel = this.GetService<MainWindowViewModel>();
    this.WhenActivated(
      disposable =>
      {
        this.OneWayBind(
            ViewModel,
            viewModel => viewModel.WorkingTimeSpans,
            view => view.WorkingDurationSelect.ItemsSource)
          .DisposeWith(disposable);
        this.Bind(
            ViewModel,
            viewModel => viewModel.WorkingTimeSpanIndex,
            view => view.WorkingDurationSelect.SelectedIndex)
          .DisposeWith(disposable);

        // monitor git commands
        ViewModel.WhenAnyValue(vm => vm.IsMonitoringGit)
          .Select(isMonitoring => isMonitoring ? "Stop" : "Start")
          .BindTo(ToggleMonitoringBtn, view => view.Content)
          .DisposeWith(disposable);

        // save changes to settings
        ViewModel.WhenAnyValue(vm => vm.WorkingTimeSpanIndex)
          .Select(index => ViewModel.WorkingTimeSpans[index])
          .Subscribe(ts => _takeARest.Duration = ts)
          .DisposeWith(disposable);

        // timer label
        ViewModel.WhenAnyValue(vm => vm.IsMonitoringGit)
          .Select(
            it =>
            {
              switch (it)
              {
                case false:
                  return Observable.Return(TimeSpan.Zero);
                default:
                {
                  var elapsedSeconds = (DateTime.Now - _takeARest.LastRestTime)
                    .TotalSeconds;
                  return Observable.Interval(TimeSpan.FromSeconds(1))
                    .Select(n => TimeSpan.FromSeconds(elapsedSeconds + n + 1));
                }
              }
            })
          .Switch()
          .Select(it => it.ToString(@"hh\:mm\:ss"))
          .ObserveOn(RxApp.MainThreadScheduler)
          .BindTo(TimerTxt, view => view.Text)
          .DisposeWith(disposable);
      });
  }

  protected override void OnClosing(WindowClosingEventArgs e)
  {
    e.Cancel = true;
    base.OnClosing(e);
    Hide();
  }

  private App App => (App)Application.Current!;

  private void ToggleBtn_OnClick(object? sender, RoutedEventArgs e)
  {
    if (App.IsMonitoringGit)
    {
      App.StopMonitoringGit();
      ViewModel!.IsMonitoringGit = false;
    }
    else
    {
      _takeARest.Start();
      App.StartMonitoringGit();
      ViewModel!.IsMonitoringGit = true;
    }
  }

  private void AlertButton_OnClick(object? sender, RoutedEventArgs e)
  {
    App.OpenAlert();
  }

  private void MoveToScreen1_OnClick(object? sender, RoutedEventArgs e)
  {
    var screen = Screens.All[0];
    Position = screen.WorkingArea.Center;
  }

  private void MoveToScreen2_OnClick(object? sender, RoutedEventArgs e)
  {
    var screen = Screens.All[1];
    Position = screen.WorkingArea.Center;
  }
}
