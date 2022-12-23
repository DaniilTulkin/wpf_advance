using System;
using System.Diagnostics;
using System.Globalization;

namespace wpf_advance
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ApplicationPage)value switch
            {
                ApplicationPage.Login => new LoginPage(),
                _ => null
            };
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
