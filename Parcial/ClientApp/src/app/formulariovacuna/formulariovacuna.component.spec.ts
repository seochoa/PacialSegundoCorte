import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulariovacunaComponent } from './formulariovacuna.component';

describe('FormulariovacunaComponent', () => {
  let component: FormulariovacunaComponent;
  let fixture: ComponentFixture<FormulariovacunaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormulariovacunaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormulariovacunaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
