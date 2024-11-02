using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private int _todayAppointments;
        private int _totalPatients;
        private decimal _monthlyRevenue;
        private int _pendingTreatments;
        private ObservableCollection<Appointment> _todaySchedule;
        private ObservableCollection<ActivityLog> _recentActivities;

        public int TodayAppointments
        {
            get => _todayAppointments;
            set { _todayAppointments = value; OnPropertyChanged(); }
        }

        public int TotalPatients
        {
            get => _totalPatients;
            set { _totalPatients = value; OnPropertyChanged(); }
        }

        public decimal MonthlyRevenue
        {
            get => _monthlyRevenue;
            set { _monthlyRevenue = value; OnPropertyChanged(); }
        }

        public int PendingTreatments
        {
            get => _pendingTreatments;
            set { _pendingTreatments = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Appointment> TodaySchedule
        {
            get => _todaySchedule;
            set { _todaySchedule = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ActivityLog> RecentActivities
        {
            get => _recentActivities;
            set { _recentActivities = value; OnPropertyChanged(); }
        }

        public DashboardViewModel()
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Load sample data
            TodayAppointments = 8;
            TotalPatients = 1250;
            MonthlyRevenue = 25000;
            PendingTreatments = 15;

            // Sample today's schedule
            TodaySchedule = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    StartTime = DateTime.Today.AddHours(9),
                    Patient = new Patient { FirstName = "John", LastName = "Doe" },
                    Treatment = new Treatment { Name = "Dental Cleaning" },
                    Status = AppointmentStatus.Confirmed
                },
                new Appointment
                {
                    StartTime = DateTime.Today.AddHours(10.5),
                    Patient = new Patient { FirstName = "Jane", LastName = "Smith" },
                    Treatment = new Treatment { Name = "Root Canal" },
                    Status = AppointmentStatus.Scheduled
                },
                new Appointment
                {
                    StartTime = DateTime.Today.AddHours(13),
                    Patient = new Patient { FirstName = "Bob", LastName = "Johnson" },
                    Treatment = new Treatment { Name = "Filling" },
                    Status = AppointmentStatus.Completed
                }
            };

            // Sample recent activities
            RecentActivities = new ObservableCollection<ActivityLog>
            {
                new ActivityLog
                {
                    Description = "New patient registration: Sarah Wilson",
                    Timestamp = DateTime.Now.AddHours(-1),
                    Type = ActivityType.NewPatient
                },
                new ActivityLog
                {
                    Description = "Appointment completed: John Doe - Dental Cleaning",
                    Timestamp = DateTime.Now.AddHours(-2),
                    Type = ActivityType.Appointment
                },
                new ActivityLog
                {
                    Description = "Payment received: $150 - Jane Smith",
                    Timestamp = DateTime.Now.AddHours(-3),
                    Type = ActivityType.Payment
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 