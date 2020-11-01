using System;
using System.Globalization;

using Xamarin.Forms;

namespace MSGraph.Mobile.Converters.Bindings
{
	public class NumberExistsBindingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string number = value as string;
			return string.IsNullOrEmpty(number) ? "Not Exists!" : number.Replace("-", "").Replace(" ", "");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}