namespace Zeeko.ImgurCli.Service;

public interface ILazyServiceProvider : IServiceProvider
{
  public T? GetService<T>();

  public T GetRequiredService<T>();

  public T? GetService<T>(Func<IServiceProvider, T> factory);

  public T GetRequiredService<T>(Func<IServiceProvider, T> factory);
}
