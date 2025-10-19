import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { QuoteService } from '../../services/quote.service';
import { QuoteResponse } from '../../Models/quote-response';
import { QuoteRequest } from '../../Models/quote-request'; // <-- use this

@Component({
  selector: 'app-quote-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './quote-form.component.html',
  styleUrls: ['./quote-form.component.css']
})
export class QuoteFormComponent {
  term!: number;
  sumInsured!: number;
  age!: number;
  coverageType: string = '';
  riskFactor: 'Low' | 'Medium' | 'High' = 'Low'; // type-safe

  quoteResult: QuoteResponse | null = null;
  loading: boolean = false;
  errorMessage: string = '';

  constructor(private quoteService: QuoteService) {}

  submitQuote(): void {
    if (!this.term || !this.sumInsured || !this.age || !this.coverageType || !this.riskFactor) {
      this.errorMessage = 'Please fill in all fields.';
      return;
    }

    this.loading = true;
    this.errorMessage = '';
    this.quoteResult = null;

    const data: QuoteRequest = {
      Term: this.term,
      SumInsured: this.sumInsured,
      Age: this.age,
      CoverageType: this.coverageType,
      RiskFactor: this.riskFactor
    };

    console.log('Sending data to backend:', data);

    this.quoteService.submitQuote(data).subscribe({
      next: (res: QuoteResponse) => {
        this.quoteResult = res;
        console.log('Quote result:', res);
        this.loading = false;
      },
      error: (err) => {
        this.errorMessage = 'Error fetching quote. Check backend.';
        console.error('Backend error:', err);
        this.loading = false;
      }
    });
  }

  // Returns premium keys for display
  quoteResultPremiumKeys(): string[] {
    return this.quoteResult?.Premiums ? Object.keys(this.quoteResult.Premiums) : [];
  }
}



