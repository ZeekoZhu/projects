using System.Collections.Concurrent;

namespace Zeeko.ImgurCli.Service;

public class LazyServiceProvider : ILazyServiceProvider
{
  private readonly IServiceProvider _serviceProvider;
  private readonly ConcurrentDictionary<Type, Lazy<object?>> _cachedServices = new();

  public LazyServiceProvider(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public object? GetService(Type serviceType)
  {
    return _cachedServices.GetOrAdd(serviceType, type => new Lazy<object?>(_serviceProvider.GetService(type))).Value;
  }

  public T? GetService<T>()
  {
    return (T?)GetService(typeof(T));
  }

  public T GetRequiredService<T>()
  {
    var result = GetService<T>();
    if (result is null)
    {
      throw new InvalidOperationException($"Service of type {typeof(T)} is not registered");
    }

    return result;
  }

  public T? GetService<T>(Func<IServiceProvider, T> factory)
  {
    return (T?)_cachedServices.GetOrAdd(typeof(T), _ => new Lazy<object?>(() => factory(_serviceProvider))).Value;
  }

  public T GetRequiredService<T>(Func<IServiceProvider, T> factory)
  {
    return GetService(factory) switch
    {
      null => throw new InvalidOperationException($"Service of type {typeof(T)} is not registered"),
      var result => result
    };
  }
}
