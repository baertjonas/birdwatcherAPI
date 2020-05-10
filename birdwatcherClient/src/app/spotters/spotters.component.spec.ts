import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpottersComponent } from './spotters.component';

describe('SpottersComponent', () => {
  let component: SpottersComponent;
  let fixture: ComponentFixture<SpottersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpottersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpottersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
