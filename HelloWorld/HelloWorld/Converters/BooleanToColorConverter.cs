using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using HelloWorld.Models;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace HelloWorld.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool) value;

            if (!isChecked)
            {
                return Color.White;
            }

            return Color.LightSkyBlue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
