import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamSearchBarComponent } from './team-search-bar.component';

describe('TeamSearchBarComponent', () => {
  let component: TeamSearchBarComponent;
  let fixture: ComponentFixture<TeamSearchBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeamSearchBarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TeamSearchBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
