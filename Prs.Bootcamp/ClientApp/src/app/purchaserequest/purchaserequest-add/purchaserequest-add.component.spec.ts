import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestAddComponent } from './purchaserequest-add.component';

describe('PurchaserequestAddComponent', () => {
  let component: PurchaserequestAddComponent;
  let fixture: ComponentFixture<PurchaserequestAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
