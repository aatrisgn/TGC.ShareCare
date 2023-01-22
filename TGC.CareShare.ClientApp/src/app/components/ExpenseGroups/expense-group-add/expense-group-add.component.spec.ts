import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseGroupAddComponent } from './expense-group-add.component';

describe('ExpenseGroupAddComponent', () => {
  let component: ExpenseGroupAddComponent;
  let fixture: ComponentFixture<ExpenseGroupAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpenseGroupAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpenseGroupAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
