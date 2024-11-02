using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.Converters
{
    public class ToothConditionToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ToothCondition condition)
            {
                return condition switch
                {
                    ToothCondition.Healthy => new SolidColorBrush(Colors.White),
                    ToothCondition.Decayed => new SolidColorBrush(Colors.Red),
                    ToothCondition.Filled => new SolidColorBrush(Colors.Silver),
                    ToothCondition.Missing => new SolidColorBrush(Colors.LightGray),
                    ToothCondition.Crown => new SolidColorBrush(Colors.Gold),
                    ToothCondition.Bridge => new SolidColorBrush(Colors.DarkGoldenrod),
                    ToothCondition.Implant => new SolidColorBrush(Colors.DarkGray),
                    ToothCondition.RootCanal => new SolidColorBrush(Colors.Blue),
                    _ => new SolidColorBrush(Colors.White)
                };
            }
            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 