import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingSearchBarComponent } from './training-search-bar.component';

describe('TrainingSearchBarComponent', () => {
  let component: TrainingSearchBarComponent;
  let fixture: ComponentFixture<TrainingSearchBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TrainingSearchBarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TrainingSearchBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
