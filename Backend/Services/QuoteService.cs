using InsuranceQuoteAPI.Models;

namespace InsuranceQuoteAPI.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly Dictionary<Guid, QuoteResponse> _quotes = new();

        public QuoteResponse CreateQuote(int term, decimal sumInsured, int age = 30, string coverageType = "Standard", int riskFactor = 1)
        {
            var id = Guid.NewGuid();

            
            string riskLabel = riskFactor switch
            {
                1 => "Low",
                2 => "Medium",
                3 => "High",
                _ => "Unknown"
            };

            var premiums = new Dictionary<string, decimal>
            {
                {"COMP1", GeneratePremium("COMP1", term, sumInsured, age, coverageType, riskFactor)},
                {"COMP2", GeneratePremium("COMP2", term, sumInsured, age, coverageType, riskFactor)},
                {"COMP3", GeneratePremium("COMP3", term, sumInsured, age, coverageType, riskFactor)},
                {"COMP4", GeneratePremium("COMP4", term, sumInsured, age, coverageType, riskFactor)}
            };

            var quote = new QuoteResponse
            {
                QuoteId = id,
                Term = term,
                SumInsured = sumInsured,
                Age = age,
                CoverageType = coverageType,
                RiskFactor = riskLabel,  
                Premiums = premiums,
                CreatedAt = DateTime.UtcNow
            };

            _quotes[id] = quote;
            return quote; 
        }

        public QuoteResponse GetQuote(Guid id)
        {
            
            var expiredKeys = _quotes
                .Where(q => (DateTime.UtcNow - q.Value.CreatedAt).TotalHours > 24)
                .Select(q => q.Key)
                .ToList();

            foreach (var key in expiredKeys)
                _quotes.Remove(key);

            return _quotes.TryGetValue(id, out var quote) ? quote : null;
        }

        private decimal GeneratePremium(string companyCode, int term, decimal sumInsured, int age, string coverageType, int riskFactor)
        {
            decimal baseRate = sumInsured * term * 0.05m;

            
            decimal ageFactor = age < 25 ? 1.2m : age > 60 ? 1.3m : 1.0m;

            
            decimal coverageFactor = coverageType == "Premium" ? 1.5m : 1.0m;

            
            decimal riskAdjustment = 1 + (riskFactor * 0.05m);

            
            return companyCode switch
            {
                "COMP1" => Math.Round(baseRate * ageFactor * riskAdjustment, 2),
                "COMP2" => Math.Round(baseRate * coverageFactor * riskAdjustment, 2),
                "COMP3" => Math.Round(baseRate * (ageFactor + 0.1m) * riskAdjustment, 2),
                "COMP4" => Math.Round(baseRate * (coverageFactor + 0.05m) * riskAdjustment, 2),
                _ => Math.Round(baseRate * riskAdjustment, 2),
            };
        }
    }
}

