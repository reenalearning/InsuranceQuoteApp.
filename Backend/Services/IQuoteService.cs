using InsuranceQuoteAPI.Models;

namespace InsuranceQuoteAPI.Services
{
    public interface IQuoteService
    {
        
        QuoteResponse CreateQuote(int term, decimal sumInsured, int age = 30, string coverageType = "Standard", int riskFactor = 1);

        
        QuoteResponse GetQuote(Guid id);
    }
}


