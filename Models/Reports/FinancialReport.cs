namespace DentalPracticeManagement.Models.Reports
{
    public class FinancialReport : ReportBase
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetIncome => TotalRevenue - TotalExpenses;
        public List<TreatmentRevenue> RevenueByTreatment { get; set; } = new();
        public Dictionary<DateTime, decimal> DailyRevenue { get; set; } = new();
        public List<PaymentMethod> PaymentMethods { get; set; } = new();
    }

    public class TreatmentRevenue
    {
        public string TreatmentName { get; set; }
        public int Count { get; set; }
        public decimal Revenue { get; set; }
    }

    public class PaymentMethod
    {
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
    }
} 