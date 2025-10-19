namespace InsuranceQuoteAPI.Models
{
    public class QuoteResponse
    {
        public Guid QuoteId { get; set; }
        public int Term { get; set; }
        public decimal SumInsured { get; set; }
        public int Age { get; set; }
        public string CoverageType { get; set; }

        
        public string RiskFactor { get; set; }

        public Dictionary<string, decimal> Premiums { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public static string ConvertRiskFactor(int risk)
        {
            return risk switch
            {
                1 => "Low",
                2 => "Medium",
                3 => "High",
                _ => "Unknown"
            };
        }
    }
}








