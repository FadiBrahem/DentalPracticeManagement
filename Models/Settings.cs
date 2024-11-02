namespace DentalPracticeManagement.Models
{
    public class Settings
    {
        public string PracticeName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public TimeSpan DayStartTime { get; set; }
        public TimeSpan DayEndTime { get; set; }
        public int DefaultAppointmentDuration { get; set; }
        public string Currency { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
        public bool EnableNotifications { get; set; }
        public bool EnableEmailReminders { get; set; }
        public bool EnableSMSReminders { get; set; }
        public string BackupLocation { get; set; }
        public bool AutoBackup { get; set; }
        public int AutoBackupFrequencyDays { get; set; }
    }
} 