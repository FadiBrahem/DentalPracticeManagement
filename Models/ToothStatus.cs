namespace DentalPracticeManagement.Models
{
    public class ToothStatus
    {
        public int ToothNumber { get; set; }
        public ToothCondition Condition { get; set; }
        public List<TreatmentNote> TreatmentHistory { get; set; } = new();
    }

    public enum ToothCondition
    {
        Healthy,
        Decayed,
        Filled,
        Missing,
        Crown,
        Bridge,
        Implant,
        RootCanal
    }

    public class TreatmentNote
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Treatment Treatment { get; set; }
    }
} 