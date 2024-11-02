using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DentalPracticeManagement.Models
{
    public class Patient : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _phoneNumber;
        private string _email;
        private string _address;
        private string _medicalHistory;
        private string _allergies;

        public int Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); }
        }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set { _dateOfBirth = value; OnPropertyChanged(); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        public string MedicalHistory
        {
            get => _medicalHistory;
            set { _medicalHistory = value; OnPropertyChanged(); }
        }

        public string Allergies
        {
            get => _allergies;
            set { _allergies = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 