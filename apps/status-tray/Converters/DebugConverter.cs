using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Projects.StatusTray.Controls;
using Splat;

namespace Projects.StatusTray.Converters;

public class DebugConverter : IValueConverter, IEnableLogger
{
  public object? Convert(object? value, Type targetType, object? parameter,
    CultureInfo culture)
  {
    if (targetType.FullName != null)
      this.Log().Debug("Converting {FromType} to {ToType}",
        (value is null ? "null" : value.GetType().FullName) ?? string.Empty,
        targetType.FullName);
    if (value is StatusInfoEntryViewModel status)
    {
      this.Log().Debug("Value is StatusInfoEntryViewModel {Status}", status.Info);
    }
    return value;
  }

  public object? ConvertBack(object? value, Type targetType, object? parameter,
    CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
