// core angular
import { Injectable } from '@angular/core';

// rxjs
import 'rxjs/add/operator/toPromise';

// models
import { PurchaseRequest } from '../models/purchaserequest';
import { LineItem } from '../models/lineitem';
import { Product } from '../models/product';
import { Status } from '../models/status';

// services
import { PurchaseRequestService } from '../services/purchaserequest.service';
import { PrLineItemService } from '../services/pr-line-item.service';
import { SystemService } from '../services/system.service';

@Injectable()
export class ShoppingCartService {

  currentRequest: PurchaseRequest;  // our 'cart'
  currentItems: LineItem[];         // array of line items in our cart

  ready: boolean = false; // do we have a cart to work with?

  // adds a product to the cart (creates new LineItem)
  addProduct(product: Product): void
  {
    if (!this.ready)  // we can't add a product to a cart that doesn't exist
      return;
  }

  // check and see if there is already a product in the cart
  checkProduct(id: number): boolean
  {
    return false;
  }

  // gets purchase request for current user
  load(userid: number): boolean
  {
    if (!this.sysService.loggedIn)  // if nobody's logged in, load will fail
      return false;

    // until we get a new api call......
    // get all requests
    let requests: PurchaseRequest[];
    this.requestService.getByUser(userid).then(resp => requests = resp);

    // check if we have any IP (in progress) status requests
    for (let request of requests)
    {
      if (request.Status.Description == "IP")
      {
        this.currentRequest = request;
        break;
      }
    }

    // if we got a request
    if (this.currentRequest)
    {
      this.getItems();  // get the line items
      return true;      // report success
    }
    // else create one
    else
    {
      this.createRequest();
    }
    return false;
  }

  update(): void
  {

  }

  private createRequest(): void
  {
    let request: PurchaseRequest = new PurchaseRequest(
      0,                                // this gets filled in by the server
      this.sysService.currentUser.Id,   // the currently logged in user
      '',                               // description and justification are filled in by the user
      '',
      new Date(Date.now() + 604800000), // seven days from now
      '',                               // delivery method
      0,                                // current total
      1,                                // IP or CART status -- TO DO: pull id from db by Description string
      new Date());
  }

  private getItems(): void
  {
    if (!this.currentRequest)  // should not have been called, if no current request
      return;

    // get all related LineItems
    this.requestService.getItems(this.currentRequest.Id).then(resp => this.currentItems = resp);
  }


  constructor(
    private requestService: PurchaseRequestService,
    private sysService: SystemService
  ) { }

}
