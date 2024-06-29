using System.Reactive;
using System.Threading.Tasks;
using AvaloniaEdit;
using CliWrap;
using DynamicData;
using ReactiveUI;
using Splat;
using FluentAvalonia.UI.Controls;
using static FluentAvalonia.UI.Controls.MarkupBuilder;

namespace Projects.Project42.Dashboard;

public class DashboardShellCommandCardView :
  MarkupViewBase<DashboardShellCommandCardViewModel>
{
  public DashboardShellCommandCardView()
  {
    this.WhenActivated(d => { this.SetupCardBehaviors(Model).DisposeWith(d); });
  }

  public override void View()
  {
    var runningButtonText = Model.ProcessState.Select(it => it switch
    {
      CommandRunningState.Idle => "Run",
      CommandRunningState.Running => "Running...",
      CommandRunningState.Success => "Success",
      CommandRunningState.Error => "Error",
      _ => "Unknown"
    });
    this
      .Focusable(true)
      .IsEnabled(true)
      .Width(DashboardCanvasConstants.CardSize.Width)
      .Height(DashboardCanvasConstants.CardSize.Height)
      .Left(Model.CardViewModel.Position.Select(it => it.X))
      .Top(Model.CardViewModel.Position.Select(it => it.Y))
      .Content(
        Border()
          .BorderBrush(Brushes.Black)
          .BorderThickness(1)
          .Padding(8, 8)
          .Background(Brushes.WhiteSmoke)
          .Child(
            DockPanel()
              .Children(
                // operator sidebar
                StackPanel()
                  .DockRight()
                  .Children(
                    Button()
                      .Content(runningButtonText)
                      .IsEnabled(Model.ExecuteCommand.CanExecute)
                      .Command(Model.ExecuteCommand),
                    Button()
                      .Width(32)
                      .Height(32)
                      .Content(
                        SymbolIcon()
                          .Width(16)
                          .Height(16)
                          .Symbol(Symbol.Settings)
                      )
                  ),

                // title
                StackPanel()
                  .DockTop()
                  .Children(
                    TextBlock()
                      .Text(Model.ShellCommand.Select())),

                // output
                Border()
                  .BorderBrush(Brushes.Black)
                  .BorderThickness(1)
                  .Child(
                    new TextEditor()
                      .Ref(out var outputPreview)
                      .DockBottom()
                  )
              )
          )
      );

    BindTextEditorContent(outputPreview);
  }

  private IDisposable BindTextEditorContent(TextEditor outputPreview)
  {
    outputPreview.IsReadOnly = true;
    outputPreview.ShowLineNumbers = true;
    outputPreview.FontFamily = FontFamily.Parse("Monospace");
    return Model.OutputLines
      .Connect()
      .ObserveOn(RxApp.MainThreadScheduler)
      .Subscribe(changes =>
      {
        foreach (var change in changes)
        {
          switch (change.Reason)
          {
            case ListChangeReason.Clear:
              outputPreview.Text = string.Empty;
              break;
            case ListChangeReason.Add:
              outputPreview.Document.Insert(outputPreview.Document.TextLength,
                change.Item.Current + Environment.NewLine);
              break;
            default:
              this.Log()
                .Warn("Unsupported change reason: {reason}", change.Reason);
              break;
          }
        }
      });
  }
}

public class DashboardShellCommandCardViewModel :
  ViewModelBase, IDashboardCardViewModel
{
  public CardViewModel CardViewModel { get; } = new();
  public Stateful<string> ShellCommand { get; } = new("volta --help");
  public Stateful<string> Shell { get; } = new("fish");

  public Stateful<CommandRunningState> ProcessState { get; } =
    new(CommandRunningState.Idle);

  public SourceList<string> OutputLines { get; } = new();

  public ReactiveCommand<Unit, Unit> ExecuteCommand { get; }

  public DashboardShellCommandCardViewModel()
  {
    var canExecute = Shell.ToObservable()
      .CombineLatest(ShellCommand.ToObservable(), ProcessState.ToObservable(),
        (shell, cmd, processState) =>
          processState == CommandRunningState.Idle &&
          !string.IsNullOrWhiteSpace(shell) &&
          !string.IsNullOrWhiteSpace(cmd));
    ExecuteCommand =
      ReactiveCommand.CreateFromTask(ExecuteCommandAsync, canExecute);
  }

  private async Task ExecuteCommandAsync()
  {
    OutputLines.Clear();

    var result = Cli.Wrap(Shell.Current)
      .WithArguments(["-c", ShellCommand.Current])
      .WithStandardOutputPipe(
        PipeTarget.ToDelegate(HandleLine))
      .WithStandardErrorPipe(
        PipeTarget.ToDelegate(HandleLine))
      .WithValidation(CommandResultValidation.None)
      .ExecuteAsync();
    var finished = await result;
    ProcessState.SetState(finished.ExitCode == 0
      ? CommandRunningState.Success
      : CommandRunningState.Error);
    return;

    void HandleLine(string line)
    {
      OutputLines.Add(line);
    }
  }
}

public enum CommandRunningState
{
  Idle,
  Running,
  Success,
  Error
}
