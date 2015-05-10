using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace ListaDeLeituraInicial.Converters
{
    public class StringToImageConverter : IValueConverter
    {
        private static Uri _baseUri = new Uri("ms-appx:///Data/");

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            var url = (string)value;

            Uri uri;
            if (url.ToUpper().Contains("HTTP://") || url.ToUpper().Contains("HTTPS://"))
            {
                uri = new Uri(url);
            }
            else
            {
                uri = new Uri(_baseUri, url);
            }

            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
