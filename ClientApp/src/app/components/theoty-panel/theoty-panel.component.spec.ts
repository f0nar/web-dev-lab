import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheotyPanelComponent } from './theoty-panel.component';

describe('TheotyPanelComponent', () => {
  let component: TheotyPanelComponent;
  let fixture: ComponentFixture<TheotyPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheotyPanelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheotyPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
