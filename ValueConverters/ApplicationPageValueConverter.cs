using System;
using System.Globalization;
using wpf_advance.Core;

namespace wpf_advance
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ApplicationPage)value switch
            {
                ApplicationPage.Login => new LoginPage(),
                ApplicationPage.Register => new RegisterPage(),
                ApplicationPage.Chat => new ChatPage(),
                _ => null
            };
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
