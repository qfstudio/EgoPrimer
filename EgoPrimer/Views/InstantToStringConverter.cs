﻿using System.Globalization;
using Avalonia.Data.Converters;
using NodaTime;
using NodaTime.Text;

namespace EgoPrimer.Views;

public class InstantToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Instant instant)
        {
            var systemZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
            var zonedDateTime = instant.InZone(systemZone);
            var pattern = ZonedDateTimePattern.CreateWithInvariantCulture("yyyy-MM-dd HH:mm:ss zzz", DateTimeZoneProviders.Tzdb);
            return pattern.Format(zonedDateTime);
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
