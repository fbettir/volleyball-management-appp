import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPlayerDetailsComponent } from './add-player-details.component';

describe('AddPlayerDetailsComponent', () => {
  let component: AddPlayerDetailsComponent;
  let fixture: ComponentFixture<AddPlayerDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPlayerDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPlayerDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
