using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Cadastro.Converters


public class StatusColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return
				(bool)value ?
				(Color)Aplocation.Current.Resources["CompletedColor"];
			(Color)Aplocation.Current.Resources["ActiveColor"];

		}
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)

		{
			return null;
		}
	}
}