using System.ComponentModel.DataAnnotations;

namespace Zeeko.ImgurCli;

/// <summary>
/// Validate the file exists
/// </summary>
public class FileExistsAttribute : ValidationAttribute
{
  public FileExistsAttribute() : base(
    "The value for {0} must be a valid file path.")
  {
  }

  protected override ValidationResult? IsValid(
    object? value,
    ValidationContext validationContext)
  {
    switch (value)
    {
      case null:
      // if value is string
      // check if file exists
      case string filePath when File.Exists(filePath):
        return ValidationResult.Success;
      default:
        return new ValidationResult(
          FormatErrorMessage(validationContext.DisplayName));
    }
  }
}
