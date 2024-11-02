namespace DentalPracticeManagement.Models
{
    public class ActivityLog
    {
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public ActivityType Type { get; set; }
    }

    public enum ActivityType
    {
        NewPatient,
        Appointment,
        Treatment,
        Payment,
        Other
    }
} 