using Avalonia.Controls;

namespace Projects.StatusTray;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
  }

  protected override void OnClosing(WindowClosingEventArgs e)
  {
    e.Cancel = true;
    Hide();
  }
}
