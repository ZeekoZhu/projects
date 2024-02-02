using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using Avalonia;
using Avalonia.ReactiveUI;
using Projects.StatusTray.Domain;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace Projects.StatusTray.Controls;

public partial class
  StatusInfoEntryView : ReactiveUserControl<StatusInfoEntryViewModel>,
  IEnableLogger
{
  private StatusInfo _info;

  public static readonly DirectProperty<StatusInfoEntryView, StatusInfo>
    InfoProperty =
      AvaloniaProperty.RegisterDirect<StatusInfoEntryView, StatusInfo>(
        "Info", o => o.Info, (o, v) => o.Info = v);

  public StatusInfo Info
  {
    get => _info;
    set => SetAndRaise(InfoProperty, ref _info, value);
  }

  public static StatusInfo DesignViewModel =>
    new()
    {
      Id = "green-design-status-provider",
      Name = "Red Design Status Provider",
      State = StatusState.Red,
      DetailWebUrl = "https://hello.com"
    };

  public StatusInfoEntryView()
  {
    InitializeComponent();
    this.WhenActivated(d =>
    {
      ViewModel = new StatusInfoEntryViewModel();
      this.WhenAnyValue(it => it.Info)
        .WhereNotNull()
        .BindTo(ViewModel, it => it.Info)
        .DisposeWith(d);
    });
  }
}

public class StatusInfoEntryViewModel : ReactiveObject, IEnableLogger
{
  [Reactive] public StatusInfo? Info { get; set; }
  public ReactiveCommand<Unit, Unit> OpenDetailCommand { get; }

  public StatusInfoEntryViewModel()
  {
    OpenDetailCommand = ReactiveCommand.Create(OpenDetail);
    OpenDetailCommand.ThrownExceptions.Subscribe(err => this.Log().Error(err));
  }

  private void OpenDetail()
  {
    if (Info == null)
    {
      this.Log().Warn("Info is null");
      return;
    }

    this.Log().Debug("OpenDetail: {Url}", Info.DetailWebUrl);
    if (!Uri.TryCreate(Info.DetailWebUrl, UriKind.Absolute, out var uri))
      return;
    // use open command to open the url
    var processStartInfo = new ProcessStartInfo(uri.AbsoluteUri)
      { UseShellExecute = true };
    Process.Start(processStartInfo);
  }
}
