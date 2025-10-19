import { ComponentFixture, TestBed } from '@angular/core/testing';
import { QuoteFormComponent } from './quote-form.component'; // ✅ correct path and name

describe('QuoteFormComponent', () => {
  let component: QuoteFormComponent;
  let fixture: ComponentFixture<QuoteFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [QuoteFormComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(QuoteFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
