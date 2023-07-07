using System.ComponentModel.DataAnnotations;

namespace Zeeko.ImgurCli;

/// <summary>
/// Validate the file exists
/// </summary>
public class FileExistsAttribute : ValidationAttribute
{
  public FileExistsAttribute() : base("The value for {0} must be a valid file path.")
  {
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    // if value is string
    if (value is string filePath)
    {
      // check if file exists
      if (File.Exists(filePath))
      {
        return ValidationResult.Success;
      }
    }

    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
  }
}
