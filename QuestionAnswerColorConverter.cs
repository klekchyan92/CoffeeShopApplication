using System.Globalization;

namespace CoffeeShopApplication;

public class QuestionAnswerColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isQuestion)
        {
            return isQuestion ? Color.FromArgb("#846046") : Color.FromArgb("#ECECEC");
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
