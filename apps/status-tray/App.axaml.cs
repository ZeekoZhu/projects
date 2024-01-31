using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Projects.AvaloniaUtils;
using Projects.StatusTray.Domain;
using ReactiveUI;
using Splat;

namespace Projects.StatusTray;

public partial class App : Application, IEnableLogger
{
  private MainWindow _mainWindow;
  public override void Initialize() => AvaloniaXamlLoader.Load(this);

  public AppViewModel ViewModel { get; set; } = new();

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      var icon = new TrayIcon
      {
        Icon = new WindowIcon(ViewModel.GreenIcon)
      };
      icon.Clicked += TrayIcon_OnClicked;
      var trayIcons = new TrayIcons { icon };
      TrayIcon.SetIcons(this, trayIcons);
      ViewModel.TrayIcon.Select(it => new WindowIcon(it))
        .ObserveOn(RxApp.MainThreadScheduler)
        .BindTo(icon, it => it.Icon);
      // initialize main window
      _mainWindow = new MainWindow();
      _mainWindow.Hide();
    }

    base.OnFrameworkInitializationCompleted();
  }

  private void TrayIcon_OnClicked(object? sender, EventArgs e)
  {
    if (_mainWindow.IsVisible)
    {
      _mainWindow.Hide();
    }
    else
    {
      _mainWindow.Show();
    }
  }
}

public class AppViewModel : ReactiveObject, IEnableLocator
{
  public readonly Bitmap RedIcon =
    new(AssetLoader.Open(
      new Uri("avares://Projects.StatusTray/Assets/red-icon-256x256.png")));

  public readonly Bitmap GreenIcon =
    new(AssetLoader.Open(
      new Uri("avares://Projects.StatusTray/Assets/green-icon-256x256.png")));

  public AppViewModel()
  {
    var statusProviders = new List<IStatusProvider>
    {
      this.GetService<GitLabPrPipelineStatusProvider>()
    };
    var tracker = new TrayStatusTracker(statusProviders);
    TrayIcon =
      tracker.StateUpdates
        .Select(
          s => s switch
          {
            StatusState.Green => GreenIcon,
            StatusState.Red => RedIcon,
            _ => throw new ArgumentOutOfRangeException(nameof(s), s, null)
          })
        .StartWith(GreenIcon)
        .LoggedCatch(this);
  }

  public IObservable<Bitmap> TrayIcon { get; set; }
}
