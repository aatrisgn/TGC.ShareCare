import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseGroupListComponent } from './expense-group-list.component';

describe('ExpenseGroupListComponent', () => {
  let component: ExpenseGroupListComponent;
  let fixture: ComponentFixture<ExpenseGroupListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpenseGroupListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpenseGroupListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
