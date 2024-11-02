using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using DentalPracticeManagement.Models;
using DentalPracticeManagement.Views;

namespace DentalPracticeManagement.ViewModels
{
    public class PatientsViewModel : INotifyPropertyChanged
    {
        private Patient _selectedPatient;
        private ObservableCollection<Patient> _patients;

        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set { _patients = value; OnPropertyChanged(); }
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set { _selectedPatient = value; OnPropertyChanged(); }
        }

        public ICommand AddNewPatientCommand { get; }
        public ICommand EditPatientCommand { get; }
        public ICommand DeletePatientCommand { get; }

        public PatientsViewModel()
        {
            // Initialize commands
            AddNewPatientCommand = new RelayCommand(AddNewPatient);
            EditPatientCommand = new RelayCommand(EditPatient, () => SelectedPatient != null);
            DeletePatientCommand = new RelayCommand(DeletePatient, () => SelectedPatient != null);

            // Load sample data (replace with actual data loading later)
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            Patients = new ObservableCollection<Patient>
            {
                new Patient
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    PhoneNumber = "123-456-7890",
                    Email = "john.doe@email.com",
                    Address = "123 Main St",
                    MedicalHistory = "No significant medical history",
                    Allergies = "None"
                },
                // Add more sample patients as needed
            };
        }

        private void AddNewPatient()
        {
            var newPatient = new Patient();
            var dialog = new PatientDialog
            {
                DataContext = new PatientDialogViewModel(newPatient, true, patient =>
                {
                    Patients.Add(patient);
                })
            };
            dialog.ShowDialog();
        }

        private void EditPatient()
        {
            if (SelectedPatient == null) return;

            var patientCopy = new Patient
            {
                Id = SelectedPatient.Id,
                FirstName = SelectedPatient.FirstName,
                LastName = SelectedPatient.LastName,
                DateOfBirth = SelectedPatient.DateOfBirth,
                PhoneNumber = SelectedPatient.PhoneNumber,
                Email = SelectedPatient.Email,
                Address = SelectedPatient.Address,
                MedicalHistory = SelectedPatient.MedicalHistory,
                Allergies = SelectedPatient.Allergies
            };

            var dialog = new PatientDialog
            {
                DataContext = new PatientDialogViewModel(patientCopy, false, patient =>
                {
                    var index = Patients.IndexOf(SelectedPatient);
                    Patients[index] = patient;
                })
            };
            dialog.ShowDialog();
        }

        private void DeletePatient()
        {
            if (SelectedPatient == null) return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete {SelectedPatient.FullName}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Patients.Remove(SelectedPatient);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 