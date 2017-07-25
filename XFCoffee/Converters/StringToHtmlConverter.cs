using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFCoffee.Converters
{
	public class StringToHtmlConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var fooUrl = value as string;
			var htmlSource = new HtmlWebViewSource();
			htmlSource.Html = fooUrl;

			return htmlSource;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

}
