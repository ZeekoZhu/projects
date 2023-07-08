namespace Zeeko.ImgurCli.Dto;

public record UploadImageDto(
  Stream ImageStream,
  string FileName,
  string? Title,
  string? Description,
  string? AlbumHash);
