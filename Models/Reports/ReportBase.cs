namespace DentalPracticeManagement.Models.Reports
{
    public abstract class ReportBase
    {
        public string Title { get; set; }
        public DateTime GeneratedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
} 