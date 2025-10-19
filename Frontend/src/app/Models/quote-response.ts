export interface QuoteResponse {
  quoteId: string;
  Term?: number;
  SumInsured?: number;
  Age?: number;
  CoverageType?: string;
  RiskFactor?: string;  // <-- changed to string
  Premiums?: Record<string, number>;
}
