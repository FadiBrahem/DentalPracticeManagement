using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using DentalPracticeManagement.Models;

namespace DentalPracticeManagement.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private Settings _settings;

        public Settings Settings
        {
            get => _settings;
            set { _settings = value; OnPropertyChanged(); }
        }

        public ObservableCollection<TimeSpan> TimeSlots { get; }
        public ObservableCollection<int> DurationOptions { get; }
        public ObservableCollection<string> CurrencyOptions { get; }
        public ObservableCollection<string> DateFormatOptions { get; }
        public ObservableCollection<string> TimeFormatOptions { get; }
        public ObservableCollection<int> BackupFrequencyOptions { get; }

        public ICommand BrowseCommand { get; }
        public ICommand BackupCommand { get; }
        public ICommand RestoreCommand { get; }
        public ICommand SaveCommand { get; }

        public SettingsViewModel()
        {
            LoadSettings();
            InitializeCollections();

            BrowseCommand = new RelayCommand(BrowseBackupLocation);
            BackupCommand = new RelayCommand(BackupNow);
            RestoreCommand = new RelayCommand(RestoreBackup);
            SaveCommand = new RelayCommand(SaveSettings);
        }

        private void LoadSettings()
        {
            // Load sample settings (replace with actual settings loading)
            Settings = new Settings
            {
                PracticeName = "Sample Dental Practice",
                Address = "123 Main St",
                Phone = "123-456-7890",
                Email = "info@sampledental.com",
                DayStartTime = new TimeSpan(9, 0, 0),
                DayEndTime = new TimeSpan(17, 0, 0),
                DefaultAppointmentDuration = 30,
                Currency = "USD",
                DateFormat = "MM/dd/yyyy",
                TimeFormat = "HH:mm",
                EnableNotifications = true,
                EnableEmailReminders = true,
                EnableSMSReminders = false,
                BackupLocation = "C:\\Backups",
                AutoBackup = true,
                AutoBackupFrequencyDays = 1
            };
        }

        private void InitializeCollections()
        {
            // Initialize time slots (30-minute intervals)
            TimeSlots = new ObservableCollection<TimeSpan>();
            for (int hour = 0; hour < 24; hour++)
            {
                TimeSlots.Add(new TimeSpan(hour, 0, 0));
                TimeSlots.Add(new TimeSpan(hour, 30, 0));
            }

            // Initialize duration options
            DurationOptions = new ObservableCollection<int> { 15, 30, 45, 60, 90, 120 };

            // Initialize currency options
            CurrencyOptions = new ObservableCollection<string> { "USD", "EUR", "GBP", "AUD", "CAD" };

            // Initialize date format options
            DateFormatOptions = new ObservableCollection<string>
            {
                "MM/dd/yyyy",
                "dd/MM/yyyy",
                "yyyy-MM-dd"
            };

            // Initialize time format options
            TimeFormatOptions = new ObservableCollection<string>
            {
                "HH:mm",
                "hh:mm tt"
            };

            // Initialize backup frequency options
            BackupFrequencyOptions = new ObservableCollection<int> { 1, 2, 3, 7, 14, 30 };
        }

        private void BrowseBackupLocation()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.BackupLocation = dialog.SelectedPath;
                    OnPropertyChanged(nameof(Settings));
                }
            }
        }

        private void BackupNow()
        {
            // Implement backup logic
            MessageBox.Show("Backup completed successfully!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RestoreBackup()
        {
            // Implement restore logic
            var result = MessageBox.Show(
                "Are you sure you want to restore from backup? This will override current data.",
                "Restore Backup",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Implement restore logic
                MessageBox.Show("Restore completed successfully!", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveSettings()
        {
            // Implement settings save logic
            MessageBox.Show("Settings saved successfully!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 