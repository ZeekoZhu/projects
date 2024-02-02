using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Projects.StatusTray.Converters;

/// <summary>
/// Test if the binding value is equal to the converter parameter
/// </summary>
public class IsEqualToBooleanConverter: IValueConverter
{
  public object? Convert(object? value, Type targetType, object? parameter,
    CultureInfo culture)
  {
    if (value == null || parameter == null)
    {
      return true;
    }

    return value.Equals(parameter);
  }

  public object? ConvertBack(object? value, Type targetType, object? parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
