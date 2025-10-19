import { Quote } from '../Models/quote';

describe('Quote Model', () => {
  it('should allow creating a quote object with all properties', () => {
    const quote: Quote = {
      Term: 0,
      SumInsured: 0,
      Age: 0,
      CoverageType: '',
      RiskFactor: 0
    };

    // Check that all properties exist
    expect(quote.Term).toBeDefined();
    expect(quote.SumInsured).toBeDefined();
    expect(quote.Age).toBeDefined();
    expect(quote.CoverageType).toBeDefined();
    expect(quote.RiskFactor).toBeDefined();
  });
});
