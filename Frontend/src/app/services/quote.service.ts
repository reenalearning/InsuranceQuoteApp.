import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuoteResponse } from '../Models/quote-response';
import { QuoteRequest } from '../Models/quote-request'; // <-- new import

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  private apiUrl = 'https://localhost:7005/api/quote';

  constructor(private http: HttpClient) {}

  // Use QuoteRequest for the payload
  submitQuote(formData: QuoteRequest): Observable<QuoteResponse> {
    return this.http.post<QuoteResponse>(`${this.apiUrl}/submit`, formData);
  }

  // Get a quote by its GUID
  getQuoteById(quoteId: string): Observable<QuoteResponse> {
    return this.http.get<QuoteResponse>(`${this.apiUrl}/${quoteId}`);
  }
}


