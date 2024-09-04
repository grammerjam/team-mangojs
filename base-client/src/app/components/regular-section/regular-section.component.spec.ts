import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegularSectionComponent } from './regular-section.component';

describe('RegularSectionComponent', () => {
  let component: RegularSectionComponent;
  let fixture: ComponentFixture<RegularSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegularSectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegularSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
