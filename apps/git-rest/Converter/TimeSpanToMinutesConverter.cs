using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GitRest.Converter;

/// <summary>
/// Convert <see cref="TimeSpan"/> to minutes.
/// </summary>
public class TimeSpanToMinutesConverter : IValueConverter
{
  public object? Convert(
    object? value,
    Type targetType,
    object? parameter,
    CultureInfo culture)
  {
    if (value is TimeSpan timeSpan)
    {
      return timeSpan.TotalMinutes + " minutes";
    }

    return 0;
  }

  public object? ConvertBack(
    object? value,
    Type targetType,
    object? parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
