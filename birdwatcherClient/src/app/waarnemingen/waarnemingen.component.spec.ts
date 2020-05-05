import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaarnemingenComponent } from './waarnemingen.component';

describe('WaarnemingenComponent', () => {
  let component: WaarnemingenComponent;
  let fixture: ComponentFixture<WaarnemingenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaarnemingenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaarnemingenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
