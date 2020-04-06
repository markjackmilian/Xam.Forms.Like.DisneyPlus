using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Converters
{
    public class BoolToNavBarHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? 90 : 60; 
            }

            return 60;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}