namespace GsiOverlayTool.Functions.DumpFileTree;

public class FileTreeDump
{
  public static void Dump(DirectoryInfo rootDir, FileInfo outputFileHash)
  {
    var hasher = new FileHasher();
    var fileInfos = FileScanner.Scan(rootDir)
      .AsParallel()
      .Select(
        it => new FileHashInfo
        {
          RelativePath = Path.GetRelativePath(rootDir.FullName, it.FullName),
          Hash = hasher.GetFileHash(it)
        })
      .ToList();
    var outputContent = string.Join(
      "\n",
      fileInfos.Select(it => it.ToString()).Order());
    File.WriteAllText(outputFileHash.FullName, outputContent);
  }
}

public class FileHashInfo
{
  public required string RelativePath { get; init; }
  public required string Hash { get; init; }

  public override string ToString()
  {
    return string.Concat(RelativePath, ",", Hash);
  }
}
