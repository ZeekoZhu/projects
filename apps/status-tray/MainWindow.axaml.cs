using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using DynamicData;
using Projects.AvaloniaUtils;
using Projects.StatusTray.Domain;
using ReactiveUI;

namespace Projects.StatusTray;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>, IEnableLocator
{
  public MainWindow()
  {
    InitializeComponent();
    //*
    ViewModel = new DesignMainWindowViewModel();
    /*/
    DataContext = new MainWindowViewModel(this.GetService<TrayStatusTracker>());
    //*/
  }

  protected override void OnClosing(WindowClosingEventArgs e)
  {
    e.Cancel = true;
    Hide();
  }
}

public class MainWindowViewModel : ReactiveObject
{
  private readonly ReadOnlyObservableCollection<StatusInfo> _statusList;

  public MainWindowViewModel(StatusTracker tracker)
  {
    tracker.StatusListUpdates
      .Connect()
      .Bind(out _statusList).Subscribe();
  }

  public ReadOnlyObservableCollection<StatusInfo> StatusList => _statusList;
}

internal class DesignStatusProvider : IStatusProvider
{
  public IObservable<IList<StatusInfo>> StatusUpdates { get; } =
    Observable.Return(
      new List<StatusInfo>
      {
        new()
        {
          Id = "green-design-status-provider",
          Name = "Green Status Provider",
          State = StatusState.Green,
          DetailWebUrl = "https://wikipedia.com"
        },
        new()
        {
          Id = "red-design-status-provider",
          Name = "Red Design Status Provider",
          State = StatusState.Red,
          DetailWebUrl = "https://google.com"
        },
      });
}

public class DesignMainWindowViewModel()
  : MainWindowViewModel(new StatusTracker(new[]
    { new DesignStatusProvider() }));
