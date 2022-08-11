import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NomVoixComponent } from './nom-voix.component';

describe('NomVoixComponent', () => {
  let component: NomVoixComponent;
  let fixture: ComponentFixture<NomVoixComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NomVoixComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NomVoixComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
