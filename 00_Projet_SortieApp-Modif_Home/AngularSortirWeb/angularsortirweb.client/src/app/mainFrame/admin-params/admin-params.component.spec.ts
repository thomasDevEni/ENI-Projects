import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminParamsComponent } from './admin-params.component';

describe('AdminParamsComponent', () => {
  let component: AdminParamsComponent;
  let fixture: ComponentFixture<AdminParamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminParamsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminParamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
