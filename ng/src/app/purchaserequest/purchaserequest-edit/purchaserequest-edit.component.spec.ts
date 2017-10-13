import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestEditComponent } from './purchaserequest-edit.component';

describe('PurchaserequestEditComponent', () => {
  let component: PurchaserequestEditComponent;
  let fixture: ComponentFixture<PurchaserequestEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
