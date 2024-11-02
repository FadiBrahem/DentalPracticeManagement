using System.Windows.Input;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.ViewModels
{
    public class PatientDialogViewModel : INotifyPropertyChanged
    {
        private Patient _patient;
        private bool _isNewPatient;
        private Action<Patient> _saveCallback;

        public Patient Patient
        {
            get => _patient;
            set { _patient = value; OnPropertyChanged(); }
        }

        public string DialogTitle => _isNewPatient ? "Add New Patient" : "Edit Patient";

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public PatientDialogViewModel(Patient patient, bool isNewPatient, Action<Patient> saveCallback)
        {
            _isNewPatient = isNewPatient;
            _saveCallback = saveCallback;
            Patient = patient;

            SaveCommand = new RelayCommand(Save, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Patient.FirstName) &&
                   !string.IsNullOrWhiteSpace(Patient.LastName);
        }

        private void Save()
        {
            _saveCallback?.Invoke(Patient);
            CloseDialog();
        }

        private void Cancel()
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            if (System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this) is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 