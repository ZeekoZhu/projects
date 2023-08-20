using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Threading;
using Serilog;

namespace GitRest.Service;

public class AlertWindowManager
{
  private ILogger Log => Serilog.Log.ForContext<AlertWindowManager>();
  private readonly List<AlertWindow> _alerts = new();

  /// <summary>
  /// Show the alert window on all screens.
  /// </summary>
  public void ShowAlert()
  {
    var stub = new Window();
    var screens = stub.Screens.All;
    Log.Debug("Found {Count} screens", screens.Count);
    foreach (var screen in screens)
    {
      var alert = new AlertWindow();
      _alerts.Add(alert);
      Log.Debug("Open alert on {Position}", screen.WorkingArea.Center);
      alert.OpenDestination = screen.WorkingArea.Center;
      alert.Show();
    }

    Observable.Return(1)
      .Delay(TimeSpan.FromSeconds(15))
      .Subscribe(
        _ =>
        {
          // switch to the avalonia thread
          Dispatcher.UIThread.InvokeAsync(CloseAlert);
        });
  }

  public void CloseAlert()
  {
    foreach (var alert in _alerts)
    {
      alert.Close();
    }

    _alerts.Clear();
  }
}
