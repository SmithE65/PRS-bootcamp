import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaserequestListComponent } from './purchaserequest-list.component';

describe('PurchaserequestListComponent', () => {
  let component: PurchaserequestListComponent;
  let fixture: ComponentFixture<PurchaserequestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaserequestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaserequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
