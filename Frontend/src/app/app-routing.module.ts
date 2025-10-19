import { Routes, RouterModule } from '@angular/router';
import { QuoteFormComponent } from './quotes/quote-form/quote-form.component';

const routes: Routes = [
  { path: '', component: QuoteFormComponent },
  { path: '**', redirectTo: '' }
];

export const AppRoutingModule = RouterModule.forRoot(routes);




