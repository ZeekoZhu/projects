using System;
using Avalonia.Controls;

namespace GitRest;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
  }

  protected override void OnClosing(WindowClosingEventArgs e)
  {
    e.Cancel = true;
    base.OnClosing(e);
    Hide();
  }
}
