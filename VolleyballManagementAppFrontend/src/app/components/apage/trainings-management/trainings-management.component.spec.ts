import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingsManagementComponent } from './trainings-management.component';

describe('TrainingsManagementComponent', () => {
  let component: TrainingsManagementComponent;
  let fixture: ComponentFixture<TrainingsManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainingsManagementComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TrainingsManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
