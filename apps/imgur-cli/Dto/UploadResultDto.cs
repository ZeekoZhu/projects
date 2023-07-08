namespace Zeeko.ImgurCli.Dto;

public record UploadResultDto
{
  public required string Link { get; init; }
  public required string DeleteHash { get; init; }
}
