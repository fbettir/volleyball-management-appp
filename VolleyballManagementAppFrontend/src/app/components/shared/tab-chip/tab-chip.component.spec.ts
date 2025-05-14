import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TabChipComponent } from './tab-chip.component';

describe('TabChipComponent', () => {
  let component: TabChipComponent;
  let fixture: ComponentFixture<TabChipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TabChipComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TabChipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
