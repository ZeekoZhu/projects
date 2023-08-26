using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GitRest.Infrastructure;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;

namespace GitRest;

[DataContract]
public class MainWindowViewModel : ReactiveObject, IEnableAppState
{
  public MainWindowViewModel()
  {
  }

}
