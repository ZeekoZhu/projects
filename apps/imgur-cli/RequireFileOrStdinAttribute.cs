using System.ComponentModel.DataAnnotations;
using Zeeko.ImgurCli.Commands;

namespace Zeeko.ImgurCli;

public class RequireFileOrStdinAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(
    object? value,
    ValidationContext validationContext)
  {
    return value switch
    {
      UploadCommand { IsFromStdin: false, FilePath: null } => new
        ValidationResult("Must specify image file when not reading from stdin"),
      UploadCommand { IsFromStdin: true, FilePath: not null } => new
        ValidationResult("Cannot specify image file when reading from stdin"),
      _ => ValidationResult.Success
    };
  }
}
