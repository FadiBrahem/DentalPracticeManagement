using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.Converters
{
    public class AppointmentStatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AppointmentStatus status)
            {
                return status switch
                {
                    AppointmentStatus.Scheduled => new SolidColorBrush(Color.FromRgb(33, 150, 243)),  // Blue
                    AppointmentStatus.Confirmed => new SolidColorBrush(Color.FromRgb(76, 175, 80)),   // Green
                    AppointmentStatus.Completed => new SolidColorBrush(Color.FromRgb(96, 125, 139)),  // Blue Grey
                    AppointmentStatus.Cancelled => new SolidColorBrush(Color.FromRgb(244, 67, 54)),   // Red
                    AppointmentStatus.NoShow => new SolidColorBrush(Color.FromRgb(255, 152, 0)),      // Orange
                    _ => new SolidColorBrush(Colors.Gray)
                };
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 