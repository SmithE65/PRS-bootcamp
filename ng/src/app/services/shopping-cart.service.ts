// core angular
import { Injectable } from '@angular/core';

// rxjs
import 'rxjs/add/operator/toPromise';

// models
import { Cart } from '../models/cart';
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
  total: number = 0;                // total external to currentRequest to keep template from breaking

  // adds a product to the cart (creates new LineItem)
  addProduct(product: Product): void
  {
    console.log("Adding product:", product);
    if (!this.currentRequest)  // we can't add a product to a cart that doesn't exist
      return;
    console.log("Checking request:", this.currentRequest);
    if (!this.checkProduct(product.Id)) // if the product doesn't already exist, add it
    {
      let item = new LineItem(0, this.currentRequest.Id, product.Id, 1);
      console.log(item);
      this.currentItems.push(item);
      this.update();
      console.log("Product added and updated.");
    }
  }

  // check and see if there is already a product in the cart
  checkProduct(id: number): boolean
  {
    console.log("Checking product: " + id);
    if (this.currentItems.find(i => i.ProductId == id))
      return true; // if we found a match, return true
    else
      return false;// else false
  }

  // gets purchase request for current user
  load(userid: number): void
  {
    if (!this.sysService.loggedIn)  // if nobody's logged in, load will fail
      return;

    // until we get a new api call......
    // get all requests by user
    this.requestService.getByUser(userid).then(resp => this.loadProc(resp));
  }

  loadProc(requests: PurchaseRequest[]): void
  {
    // check if we have any IP (in progress) status requests
    for (let request of requests) {
      if (request.Status.Description == "IP") {
        this.currentRequest = request;
        this.total = request.Total;
        break;
      }
    }

    // if we got a request
    if (this.currentRequest) {
      this.getItems();  // get the line items
      this.total = this.currentRequest.Total;
    }
    // else create one
    else {
      this.createRequest();
    }
  }

  unload(): void
  {
    this.currentItems = null;
    this.currentRequest = null;
  }

  // posts all items to the server and gets updated data from the server to stay in sync
  update(): void
  {
    let cart: Cart = new Cart(this.currentRequest, this.currentItems);    // build a cart
    this.requestService.updateCart(cart).then(resp => console.log(resp)); // ship it off to the interwebs
    console.log("update():", cart);
    // reload data to ensure local data matches server
    this.load(this.currentRequest.UserId);
    this.total = this.currentRequest.Total;
  }

  private createRequest(): void
  {
    let request: PurchaseRequest = new PurchaseRequest(
      0,                                // this gets filled in by the server
      this.sysService.currentUser.Id,   // the currently logged in user
      'Description',                    // description and justification are filled in by the user
      'Justification',
      new Date(Date.now() + 604800000), // seven days from now
      'PICKUP',                               // delivery method
      0,                                // current total
      1,                                // IP or CART status -- TO DO: pull id from db by Description string
      new Date());

    this.requestService.add(request).then(resp => console.log(resp, "New cart created."));
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
