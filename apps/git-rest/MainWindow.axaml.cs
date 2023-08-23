using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using GitRest.Infrastructure;
using GitRest.Service;
using ReactiveUI;
using Splat;

namespace GitRest;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>,
  IEnableLogger, IEnableLocator
{

  public MainWindow()
  {
#if DEBUG
    InitializeComponent(attachDevTools: true);
#else
    InitializeComponent();
#endif

    ViewModel = this.GetService<MainWindowViewModel>();
  }

  protected override void OnClosing(WindowClosingEventArgs e)
  {
    e.Cancel = true;
    base.OnClosing(e);
    Hide();
  }

  private App App => (App)Application.Current!;

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
