import { TestBed, inject } from '@angular/core/testing';

import { PrLineItemService } from './pr-line-item.service';

describe('PrLineItemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PrLineItemService]
    });
  });

  it('should be created', inject([PrLineItemService], (service: PrLineItemService) => {
    expect(service).toBeTruthy();
  }));
});
