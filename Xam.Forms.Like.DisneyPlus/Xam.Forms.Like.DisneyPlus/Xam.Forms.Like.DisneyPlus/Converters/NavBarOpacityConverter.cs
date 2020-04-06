using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Converters
{
    public class NavBarOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                if (doubleValue < 0.80) return 0;
                return doubleValue;
            }

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}