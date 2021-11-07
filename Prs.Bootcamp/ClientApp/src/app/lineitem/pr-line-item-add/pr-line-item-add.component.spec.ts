import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrLineItemAddComponent } from './pr-line-item-add.component';

describe('PrLineItemAddComponent', () => {
  let component: PrLineItemAddComponent;
  let fixture: ComponentFixture<PrLineItemAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrLineItemAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrLineItemAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
