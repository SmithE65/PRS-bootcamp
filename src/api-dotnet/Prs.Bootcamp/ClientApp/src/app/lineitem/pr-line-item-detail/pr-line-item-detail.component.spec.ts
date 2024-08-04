import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrLineItemDetailComponent } from './pr-line-item-detail.component';

describe('PrLineItemDetailComponent', () => {
  let component: PrLineItemDetailComponent;
  let fixture: ComponentFixture<PrLineItemDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrLineItemDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrLineItemDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
