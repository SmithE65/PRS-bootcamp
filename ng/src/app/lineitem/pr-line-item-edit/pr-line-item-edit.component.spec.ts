import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrLineItemEditComponent } from './pr-line-item-edit.component';

describe('PrLineItemEditComponent', () => {
  let component: PrLineItemEditComponent;
  let fixture: ComponentFixture<PrLineItemEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrLineItemEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrLineItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
