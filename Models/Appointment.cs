using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DentalPracticeManagement.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private string _notes;
        private AppointmentStatus _status;
        private Patient _patient;
        private Treatment _treatment;

        public int Id { get; set; }

        public DateTime StartTime
        {
            get => _startTime;
            set { _startTime = value; OnPropertyChanged(); }
        }

        public DateTime EndTime
        {
            get => _endTime;
            set { _endTime = value; OnPropertyChanged(); }
        }

        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(); }
        }

        public AppointmentStatus Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public Patient Patient
        {
            get => _patient;
            set { _patient = value; OnPropertyChanged(); }
        }

        public Treatment Treatment
        {
            get => _treatment;
            set { _treatment = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum AppointmentStatus
    {
        Scheduled,
        Confirmed,
        Completed,
        Cancelled,
        NoShow
    }
} 