import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrLineItemListComponent } from './pr-line-item-list.component';

describe('PrLineItemListComponent', () => {
  let component: PrLineItemListComponent;
  let fixture: ComponentFixture<PrLineItemListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrLineItemListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrLineItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
