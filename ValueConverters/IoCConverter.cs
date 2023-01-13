using Core;
using Ninject;
using System;
using System.Globalization;

namespace wpf_advance
{
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)parameter switch
            {
                nameof(ApplicationViewModel) => IoC.Application,
                _ => null
            };
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
