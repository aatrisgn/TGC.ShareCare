import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseGroupDetailsComponent } from './expense-group-details.component';

describe('ExpenseGroupDetailsComponent', () => {
  let component: ExpenseGroupDetailsComponent;
  let fixture: ComponentFixture<ExpenseGroupDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpenseGroupDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpenseGroupDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
