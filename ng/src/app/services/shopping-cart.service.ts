import { Injectable } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../models/purchaserequest';
import { LineItem } from '../models/lineitem';
import { Product } from '../models/product';

import { PurchaseRequestService } from '../services/purchaserequest.service';
import { PrLineItemService } from '../services/pr-line-item.service';

@Injectable()
export class ShoppingCartService {

  currentRequest: PurchaseRequest;
  currentItems: LineItem[];

  ready: boolean = false; //

  // adds a product to the cart (creates new LineItem)
  addProduct(product: Product): void
  {
    
  }

  // check and see if there is already a product in the cart
  checkProduct(id: number): boolean
  {
    return false;
  }

  // gets purchase request for current user
  load(): boolean
  {
    // until we get a new api call......
    // get all requests
    let requests: PurchaseRequest[];
    this.requestService.list().then(resp => requests = resp);

    //
    return true;
  }

  update(): void
  {

  }

  private createRequest(): void
  {

  }

  private getItems(): void
  {

  }


  constructor(
    private requestService: PurchaseRequestService
  ) { }

}
