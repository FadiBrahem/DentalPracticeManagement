namespace DentalPracticeManagement.Models.Reports
{
    public class PatientReport : ReportBase
    {
        public int TotalPatients { get; set; }
        public int NewPatients { get; set; }
        public int ActivePatients { get; set; }
        public int InactivePatients { get; set; }
        public Dictionary<string, int> PatientsByAge { get; set; } = new();
        public Dictionary<string, int> PatientsByLocation { get; set; } = new();
        public List<CommonTreatment> MostCommonTreatments { get; set; } = new();
    }

    public class CommonTreatment
    {
        public string TreatmentName { get; set; }
        public int Count { get; set; }
        public decimal Percentage { get; set; }
    }
} 