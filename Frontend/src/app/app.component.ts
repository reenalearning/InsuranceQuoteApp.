import { Component } from '@angular/core';
import { QuoteFormComponent } from './quotes/quote-form/quote-form.component';

@Component({
  selector: 'app-root',
  standalone: true,                  
  imports: [QuoteFormComponent],     
  template: `
    <h1>Insurance Quote App</h1>
    <app-quote-form></app-quote-form>
  `
})
export class AppComponent {}


