using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xam.Forms.Like.DisneyPlus.Converters
{
    public class CollectionViewMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is IEnumerable<string> list && value is string stringValue)
            {
                var index = list.IndexOf(stringValue);
                if(index == 0)
                    return new Thickness(16,0,0,0);
                
                if(stringValue == list.Last())
                    return new Thickness(0,0,16,0);
            }
            
            return new Thickness(0,0,0,0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}