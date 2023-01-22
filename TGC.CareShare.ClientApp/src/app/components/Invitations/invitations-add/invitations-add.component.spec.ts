import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitationsAddComponent } from './invitations-add.component';

describe('InvitationsAddComponent', () => {
  let component: InvitationsAddComponent;
  let fixture: ComponentFixture<InvitationsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvitationsAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvitationsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
