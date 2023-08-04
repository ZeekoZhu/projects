using MD5Hash;

namespace GsiOverlayTool.Functions.DumpFileTree;

public class FileHasher
{
  public string GetFileHash(FileSystemInfo file)
  {
    // returns target full path if file is a symbolic link
    if (file.ResolveLinkTarget(false) is { } target)
    {
      return target.FullName.GetMD5();
    }

    if (file is DirectoryInfo)
    {
      return file.FullName.GetMD5();
    }

    if (file is FileInfo normalFile)
    {
      using var fileStream = normalFile.OpenRead();
      return fileStream.GetMD5();
    }

    throw new NotSupportedException(
      $"Unsupported file type to hash: '{file.GetType().FullName}'");
  }
}
