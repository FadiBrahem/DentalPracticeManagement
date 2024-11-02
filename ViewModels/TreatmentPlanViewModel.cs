using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.ViewModels
{
    public class TreatmentPlanViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ToothStatus> _upperTeeth;
        private ObservableCollection<ToothStatus> _lowerTeeth;
        private ObservableCollection<Treatment> _availableTreatments;
        private ObservableCollection<PlannedTreatment> _plannedTreatments;
        private Treatment _selectedTreatment;
        private ToothStatus _selectedTooth;
        private decimal _totalCost;

        public ObservableCollection<ToothStatus> UpperTeeth
        {
            get => _upperTeeth;
            set { _upperTeeth = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ToothStatus> LowerTeeth
        {
            get => _lowerTeeth;
            set { _lowerTeeth = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Treatment> AvailableTreatments
        {
            get => _availableTreatments;
            set { _availableTreatments = value; OnPropertyChanged(); }
        }

        public ObservableCollection<PlannedTreatment> PlannedTreatments
        {
            get => _plannedTreatments;
            set { _plannedTreatments = value; OnPropertyChanged(); }
        }

        public Treatment SelectedTreatment
        {
            get => _selectedTreatment;
            set { _selectedTreatment = value; OnPropertyChanged(); }
        }

        public ToothStatus SelectedTooth
        {
            get => _selectedTooth;
            set { _selectedTooth = value; OnPropertyChanged(); }
        }

        public decimal TotalCost
        {
            get => _totalCost;
            set { _totalCost = value; OnPropertyChanged(); }
        }

        public ICommand SelectToothCommand { get; }
        public ICommand AddTreatmentCommand { get; }
        public ICommand RemoveTreatmentCommand { get; }
        public ICommand CreateAppointmentCommand { get; }

        public TreatmentPlanViewModel()
        {
            InitializeTeeth();
            LoadSampleTreatments();
            
            PlannedTreatments = new ObservableCollection<PlannedTreatment>();
            
            SelectToothCommand = new RelayCommand<ToothStatus>(SelectTooth);
            AddTreatmentCommand = new RelayCommand(AddTreatment, CanAddTreatment);
            RemoveTreatmentCommand = new RelayCommand<PlannedTreatment>(RemoveTreatment);
            CreateAppointmentCommand = new RelayCommand(CreateAppointment, () => PlannedTreatments.Any());
        }

        private void InitializeTeeth()
        {
            UpperTeeth = new ObservableCollection<ToothStatus>();
            LowerTeeth = new ObservableCollection<ToothStatus>();

            // Initialize upper teeth (1-16)
            for (int i = 1; i <= 16; i++)
            {
                UpperTeeth.Add(new ToothStatus { ToothNumber = i, Condition = ToothCondition.Healthy });
            }

            // Initialize lower teeth (17-32)
            for (int i = 17; i <= 32; i++)
            {
                LowerTeeth.Add(new ToothStatus { ToothNumber = i, Condition = ToothCondition.Healthy });
            }
        }

        private void LoadSampleTreatments()
        {
            AvailableTreatments = new ObservableCollection<Treatment>
            {
                new Treatment { Name = "Filling", Description = "Dental filling procedure", Cost = 150.00m, Duration = TimeSpan.FromMinutes(30) },
                new Treatment { Name = "Root Canal", Description = "Root canal treatment", Cost = 800.00m, Duration = TimeSpan.FromHours(1.5) },
                new Treatment { Name = "Crown", Description = "Dental crown procedure", Cost = 1200.00m, Duration = TimeSpan.FromHours(1) },
                new Treatment { Name = "Cleaning", Description = "Professional teeth cleaning", Cost = 100.00m, Duration = TimeSpan.FromMinutes(45) }
            };
        }

        private void SelectTooth(ToothStatus tooth)
        {
            SelectedTooth = tooth;
        }

        private bool CanAddTreatment()
        {
            return SelectedTooth != null && SelectedTreatment != null;
        }

        private void AddTreatment()
        {
            if (SelectedTooth != null && SelectedTreatment != null)
            {
                var plannedTreatment = new PlannedTreatment
                {
                    Tooth = SelectedTooth,
                    Treatment = SelectedTreatment
                };

                PlannedTreatments.Add(plannedTreatment);
                UpdateTotalCost();
            }
        }

        private void RemoveTreatment(PlannedTreatment treatment)
        {
            if (treatment != null)
            {
                PlannedTreatments.Remove(treatment);
                UpdateTotalCost();
            }
        }

        private void UpdateTotalCost()
        {
            TotalCost = PlannedTreatments.Sum(pt => pt.Treatment.Cost);
        }

        private void CreateAppointment()
        {
            // This will be implemented later to create appointments from the treatment plan
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PlannedTreatment
    {
        public ToothStatus Tooth { get; set; }
        public Treatment Treatment { get; set; }
    }
} 