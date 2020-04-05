using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Converters
{
    public class SmallLogoTranslationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue * 10;
            }

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}