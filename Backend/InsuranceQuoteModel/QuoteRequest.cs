namespace InsuranceQuoteModel
{
    public class QuoteRequest
    {
        public int Term { get; set; }          
        public decimal SumInsured { get; set; }
        public int Age { get; set; } = 30;      
        public string CoverageType { get; set; } = "Standard";
        public string RiskFactor { get; set; }
    }
}
