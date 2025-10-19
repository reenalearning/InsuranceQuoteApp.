using InsuranceQuoteAPI.Models;
using InsuranceQuoteAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuoteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

       
        [HttpPost("submit")]
        public IActionResult SubmitQuote([FromBody] QuoteRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request.");

            
            int riskFactorInt = request.RiskFactor?.ToLower() switch
            {
                "low" => 1,
                "medium" => 2,
                "high" => 3,
                _ => 1
            };

            
            var quote = _quoteService.CreateQuote(
                request.Term,
                request.SumInsured,
                request.Age,
                request.CoverageType,
                riskFactorInt
            );

            
            return Ok(quote);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetQuote(Guid id)
        {
            var quote = _quoteService.GetQuote(id);
            if (quote == null)
                return NotFound("Quote not found.");

            return Ok(quote);
        }
    }
}


