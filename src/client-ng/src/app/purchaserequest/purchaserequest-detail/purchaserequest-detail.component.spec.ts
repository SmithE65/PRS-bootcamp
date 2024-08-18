import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestDetailComponent } from './purchaserequest-detail.component';

describe('PurchaserequestDetailComponent', () => {
  let component: PurchaserequestDetailComponent;
  let fixture: ComponentFixture<PurchaserequestDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
