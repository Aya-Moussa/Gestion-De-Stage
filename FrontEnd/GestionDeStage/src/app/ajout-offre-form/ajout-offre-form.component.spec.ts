import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AjoutOffreFormComponent } from './ajout-offre-form.component';

describe('AjoutOffreFormComponent', () => {
  let component: AjoutOffreFormComponent;
  let fixture: ComponentFixture<AjoutOffreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AjoutOffreFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AjoutOffreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
