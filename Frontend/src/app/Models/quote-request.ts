export interface QuoteRequest {
  Term: number;
  SumInsured: number;
  Age: number;
  CoverageType: string;
  RiskFactor: 'Low' | 'Medium' | 'High';
}
