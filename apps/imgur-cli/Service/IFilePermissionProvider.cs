namespace Zeeko.ImgurCli.Service;

public interface IFilePermissionProvider
{
  public void RestrictFilePermissions(string path);
}

public class FilePermissionProvider : IFilePermissionProvider, ITransientDependency
{
  public void RestrictFilePermissions(string path)
  {
    switch (Environment.OSVersion.Platform)
    {
      case PlatformID.Unix:
      case PlatformID.MacOSX:
#pragma warning disable CA1416
        File.SetUnixFileMode(path, UnixFileMode.UserRead | UnixFileMode.UserWrite);
#pragma warning restore CA1416
        break;
    }
  }
}
