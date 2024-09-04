import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegularCardComponent } from './regular-card.component';

describe('RegularCardComponent', () => {
  let component: RegularCardComponent;
  let fixture: ComponentFixture<RegularCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegularCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegularCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
