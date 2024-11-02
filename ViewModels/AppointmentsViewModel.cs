using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.ViewModels
{
    public class TimeSlot
    {
        public DateTime Time { get; set; }
        public Appointment Appointment { get; set; }
    }

    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        private DateTime _selectedDate;
        private ObservableCollection<TimeSlot> _timeSlots;
        private AppointmentStatus? _selectedStatusFilter;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                LoadAppointments();
            }
        }

        public ObservableCollection<TimeSlot> TimeSlots
        {
            get => _timeSlots;
            set { _timeSlots = value; OnPropertyChanged(); }
        }

        public AppointmentStatus? SelectedStatusFilter
        {
            get => _selectedStatusFilter;
            set
            {
                _selectedStatusFilter = value;
                OnPropertyChanged();
                LoadAppointments();
            }
        }

        public ICommand NewAppointmentCommand { get; }
        public ICommand PreviousDayCommand { get; }
        public ICommand NextDayCommand { get; }

        public AppointmentsViewModel()
        {
            SelectedDate = DateTime.Today;
            NewAppointmentCommand = new RelayCommand(CreateNewAppointment);
            PreviousDayCommand = new RelayCommand(() => SelectedDate = SelectedDate.AddDays(-1));
            NextDayCommand = new RelayCommand(() => SelectedDate = SelectedDate.AddDays(1));

            InitializeTimeSlots();
            LoadSampleData();
        }

        private void InitializeTimeSlots()
        {
            TimeSlots = new ObservableCollection<TimeSlot>();
            var startTime = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 9, 0, 0);
            
            for (int i = 0; i < 16; i++) // 9 AM to 5 PM
            {
                TimeSlots.Add(new TimeSlot
                {
                    Time = startTime.AddMinutes(i * 30)
                });
            }
        }

        private void LoadSampleData()
        {
            // Add sample appointments
            var sampleAppointment = new Appointment
            {
                StartTime = DateTime.Today.AddHours(10),
                EndTime = DateTime.Today.AddHours(11),
                Patient = new Patient { FirstName = "John", LastName = "Doe" },
                Treatment = new Treatment { Name = "Dental Cleaning" },
                Status = AppointmentStatus.Confirmed
            };

            // Find the matching time slot and add the appointment
            var slot = TimeSlots.FirstOrDefault(ts => ts.Time == sampleAppointment.StartTime);
            if (slot != null)
            {
                slot.Appointment = sampleAppointment;
            }
        }

        private void LoadAppointments()
        {
            // This will be implemented later with actual data loading
            InitializeTimeSlots();
            LoadSampleData();
        }

        private void CreateNewAppointment()
        {
            // Implementation will be added later
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 