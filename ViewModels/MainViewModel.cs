using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DentalPracticeManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        private NavigationItem _selectedNavigationItem;

        public ObservableCollection<NavigationItem> NavigationItems { get; }

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public NavigationItem SelectedNavigationItem
        {
            get => _selectedNavigationItem;
            set
            {
                _selectedNavigationItem = value;
                OnPropertyChanged();
                UpdateCurrentView();
            }
        }

        public MainViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationItem>
            {
                new NavigationItem { Title = "Dashboard", Icon = "🏠", ViewName = "DashboardView" },
                new NavigationItem { Title = "Patients", Icon = "👥", ViewName = "PatientsView" },
                new NavigationItem { Title = "Appointments", Icon = "📅", ViewName = "AppointmentsView" },
                new NavigationItem { Title = "Treatments", Icon = "🦷", ViewName = "TreatmentsView" },
                new NavigationItem { Title = "Settings", Icon = "⚙️", ViewName = "SettingsView" }
            };
        }

        private void UpdateCurrentView()
        {
            switch (SelectedNavigationItem?.ViewName)
            {
                case "DashboardView":
                    CurrentView = new DashboardViewModel();
                    break;
                case "PatientsView":
                    CurrentView = new PatientsViewModel();
                    break;
                case "AppointmentsView":
                    CurrentView = new AppointmentsViewModel();
                    break;
                case "TreatmentsView":
                    CurrentView = new TreatmentPlanViewModel();
                    break;
                // Add other views as needed
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 