namespace InvestmentsOrganizer.Converter;

using System.Globalization;
using System.Windows.Data;

[ValueConversion(typeof(bool), typeof(Type))]
public class IsCheckedToDepositViewTypeConverter: IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return null;
	}
}