export interface Quote {
  Term: number;
  SumInsured: number;
  Age: number;
  CoverageType: string;
  RiskFactor: number; // Must match backend
}