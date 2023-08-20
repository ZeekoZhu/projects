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
  public MainWindow()
  {
    var takeARest = this.GetService<TakeARestManager>();
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

        ViewModel.WhenAnyValue(vm => vm.WorkingTimeSpanIndex)
          .Select(index => ViewModel.WorkingTimeSpans[index])
          .Subscribe(ts => takeARest.Duration = ts)
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
    var btn = (Button)sender!;
    if (App.IsMonitoringGit)
    {
      App.StopMonitoringGit();
      btn.Content = "Start";
    }
    else
    {
      App.StartMonitoringGit();
      btn.Content = "Stop";
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
