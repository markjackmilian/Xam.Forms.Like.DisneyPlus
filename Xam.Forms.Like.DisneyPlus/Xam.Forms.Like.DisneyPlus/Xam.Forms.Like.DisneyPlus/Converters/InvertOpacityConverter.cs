using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Converters
{
    public class InvertOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                var coefficient = (double?) parameter ?? 0;
                return 1+coefficient - doubleValue;
            }

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}