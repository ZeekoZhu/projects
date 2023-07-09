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
      UploadCommand { IsFromStdin: false, FileName: null } => new
        ValidationResult("Must specify file name when not reading from stdin"),
      UploadCommand { IsFromStdin: true, FileName: not null } => new
        ValidationResult("Cannot specify file name when reading from stdin"),
      _ => ValidationResult.Success
    };
  }
}
