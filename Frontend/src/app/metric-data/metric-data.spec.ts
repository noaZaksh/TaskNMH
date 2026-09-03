import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MetricData } from './metric-data';

describe('MetricData', () => {
  let component: MetricData;
  let fixture: ComponentFixture<MetricData>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MetricData]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MetricData);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
