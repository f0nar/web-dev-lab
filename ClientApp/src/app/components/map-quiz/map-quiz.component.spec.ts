import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapQuizComponent } from './map-quiz.component';

describe('MapQuizComponent', () => {
  let component: MapQuizComponent;
  let fixture: ComponentFixture<MapQuizComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MapQuizComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MapQuizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
