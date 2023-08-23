using Splat;

namespace GitRest.Infrastructure;

public interface IEnableLocator
{
}

public static class LocatorExtensions
{
  public static T GetService<T>(this IEnableLocator _)
  {
    return Locator.Current.GetService<T>()!;
  }
}
