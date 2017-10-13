import { TestBed, inject } from '@angular/core/testing';

import { PurchaserequestService } from './purchaserequest.service';

describe('PurchaserequestService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PurchaserequestService]
    });
  });

  it('should be created', inject([PurchaserequestService], (service: PurchaserequestService) => {
    expect(service).toBeTruthy();
  }));
});
