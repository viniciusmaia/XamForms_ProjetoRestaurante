using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace VFood.Converters
{
    public class ByteToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var imagemEmBytes = (byte[])value;

                return ImageSource.FromStream(() => new MemoryStream(imagemEmBytes));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
