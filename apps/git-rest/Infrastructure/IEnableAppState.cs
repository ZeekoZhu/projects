using System;
using System.Reactive;
using System.Reactive.Linq;
using GitRest.Service;
using ReactiveUI;

namespace GitRest.Infrastructure;

public interface IEnableAppState : IEnableLocator
{
}

public static class EnableAppStateExtensions
{
  public static AppState GetAppState(this IEnableAppState _) =>
    RxApp.SuspensionHost.GetAppState<AppState>();

  public static void SaveState(this IEnableAppState it)
  {
    it.GetService<SuspendHelper>().ManualSaveState();
  }

  public static IDisposable EnableAutoPersist<T>(
    this T it,
    Action<T, AppState> updateState) where T : IReactiveObject, IEnableAppState
  {
    var state = it.GetAppState();
    return it.AutoPersist(
      x =>
      {
        updateState(x, state);
        it.SaveState();
        return Observable.Return(Unit.Default);
      });
  }
}
