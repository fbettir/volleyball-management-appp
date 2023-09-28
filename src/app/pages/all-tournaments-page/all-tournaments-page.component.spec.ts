import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllTournamentsPageComponent } from './all-tournaments-page.component';

describe('AllTournamentsPageComponent', () => {
  let component: AllTournamentsPageComponent;
  let fixture: ComponentFixture<AllTournamentsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllTournamentsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllTournamentsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
