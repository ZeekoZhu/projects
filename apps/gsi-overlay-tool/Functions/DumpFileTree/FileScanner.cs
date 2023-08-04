namespace GsiOverlayTool.Functions.DumpFileTree;

public class FileScanner
{
  /// <summary>
  /// List all files in the given directory recursively, ignoring symbolic links, hard links, etc.
  /// </summary>
  /// <param name="rootDir"></param>
  /// <returns></returns>
  public static IEnumerable<FileSystemInfo> Scan(DirectoryInfo rootDir)
  {
    var queue = new Queue<DirectoryInfo>();
    queue.Enqueue(rootDir);
    while (queue.Count > 0)
    {
      var dir = queue.Dequeue();
      foreach (var file in dir.EnumerateFileSystemInfos(
                 "*",
                 new EnumerationOptions { AttributesToSkip = 0 }))
      {
        if (file.LinkTarget is not null)
        {
          yield return file;
          continue;
        }

        switch (file)
        {
          case DirectoryInfo subDir:
            queue.Enqueue(subDir);
            break;
          case FileInfo:
            yield return file;
            break;
        }
      }
    }
  }
}
