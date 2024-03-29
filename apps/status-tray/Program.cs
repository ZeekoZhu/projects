﻿using Avalonia;
using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Projects.AvaloniaUtils;
using Serilog;

namespace Projects.StatusTray;

static class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static void Main(string[] args)
  {
    Log.Logger = SerilogHelper.CreateApplicationLogger("Projects")
      .CreateLogger();
    X11Helper.SetGlobalScalingFactor();
    _ = new Bootstrap();
    BuildAvaloniaApp()
      .StartWithClassicDesktopLifetime(args, ShutdownMode.OnExplicitShutdown);
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>()
      .UsePlatformDetect()
      .With(new X11PlatformOptions { EnableIme = true })
      .WithInterFont()
      .AddLog()
      .UseReactiveUI();
}
