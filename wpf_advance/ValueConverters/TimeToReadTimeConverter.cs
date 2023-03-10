using System;
using System.Globalization;

namespace wpf_advance
{
    public class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            if (time == DateTimeOffset.MinValue) return string.Empty;

            if (time.Date == DateTimeOffset.UtcNow.Date)
                return $"Read {time.ToLocalTime():HH:mm}";

            return $"Read {time.ToLocalTime():G}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
