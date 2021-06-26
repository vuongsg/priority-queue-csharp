using System;
using System.Globalization;
using System.Windows.Data;

namespace MyPriorityQueue.View
{
	public class AddedNewToTextConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || value.GetType() != typeof(bool))
			{
				return string.Empty;
			}

			return (bool)value ? "NEW" : string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
