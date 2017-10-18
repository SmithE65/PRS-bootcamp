// core angular
import { Injectable } from '@angular/core';

// rxjs
import 'rxjs/add/operator/toPromise';

// models
import { Cart } from '../models/cart';
import { PurchaseRequest } from '../models/purchaserequest';
import { PurchaseRequestLineItem } from '../models/lineitem';
import { Product } from '../models/product';
import { Status } from '../models/status';

// services
import { PurchaseRequestService } from '../services/purchaserequest.service';
import { PrLineItemService } from '../services/pr-line-item.service';
import { StatusService } from '../services/status.service';
import { SystemService } from '../services/system.service';

@Injectable()
export class ShoppingCartService {

  currentRequest: PurchaseRequest;  // our 'cart'
  currentItems: PurchaseRequestLineItem[];         // array of line items in our cart
  total: number = 0;                // total external to currentRequest to keep template from breaking

  status: Status[]; // get a list of all status everytime we load

  // adds a product to the cart (creates new LineItem)
  addProduct(product: Product): void
  {
    //console.log("Adding product:", product);
    if (!this.currentRequest)  // we can't add a product to a cart that doesn't exist
      return;
    //console.log("Checking request:", this.currentRequest);
    if (!this.checkProduct(product.Id)) // if the product doesn't already exist, add it
    {
      let item = new PurchaseRequestLineItem(0, this.currentRequest.Id, product.Id, 1);
      //console.log(item);
      this.lineItemService.add(item).then(resp => { console.log(resp); this.load() });
      //console.log("Product added and updated.");
    }
  }

  // EMPTY FUNCTION
  removeProduct(product: Product): void
  {

  }

  // check and see if there is already a product in the cart
  checkProduct(id: number): boolean
  {
    //console.log("checkProduct():", this.currentItems);
    if (this.currentItems == null)
      return false; // for some reason we don't have any items

    if (this.currentItems.find(i => i.ProductId == id))
      return true; // if we found a match, return true
    else
      return false;// else false
  }

  // returns the id for the status.description matching desc
  // EMPTY FUNCTION
  getStatusId(desc: string): number
  {
    return 0;
  }

  // gets purchase request for current user
  load(): void
  {
    if (!this.sysService.loggedIn)  // if nobody's logged in, load will fail
      return;

    this.unload();  // clear everything before we reload data

    // until we get a new api call......
    // get all requests by user
    this.requestService.getByUser(this.sysService.currentUser.Id).then(resp => this.loadProc(resp));
    this.statusService.list().then(resp => this.status = resp);
  }

  // processes data retreived during load()
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

  // marks current request as REVIEW and creates a new one
  submit(): void
  {
    // TO-DO: pull status from db by desc "REVIEW"
    this.currentRequest.Status = null;
    this.currentRequest.StatusId = 2;

    // set status to REVIEW unless total is less than $50, then autoaccept
    let setStatus = "REVIEW";
    if (this.currentRequest.Total < 50)
    {
      setStatus = "ACCEPTED";
    }

    if (this.status != undefined)
    {
      let s = this.status.find(st => st.Description == setStatus);
      if (s != undefined)
      {
        this.currentRequest.Status = s;
        this.currentRequest.StatusId = s.Id;
      }
    }
    this.update();
  }

  // sets stored data to null
  unload(): void
  {
    this.currentItems = null;
    this.currentRequest = null;
    this.total = 0;
  }

  // posts all items to the server and gets updated data from the server to stay in sync
  update(): void
  {
    let cart: Cart = new Cart(this.currentRequest, this.currentItems);    // build a cart
    this.requestService.updateCart(cart).then(resp => { console.log(resp); this.load() }); // ship it off to the interwebs & drag it right back
    //console.log("update():", cart);
    
    //this.total = this.currentRequest.Total;
  }

  // creates a new purchase request -- called when none match cart criteria
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

    // Find an ID in the db for "IP", if none exists stick to default of 1
    if (this.status != undefined)
    {
      let s = this.status.find(st => st.Description == "IP");
      if (s != undefined)
      {
        request.StatusId = s.Id;
        request.Status = s;
      }
    }

    this.requestService.add(request).then(resp => console.log(resp, "New cart created."));
  }

  // gets the lineitems for the current request
  private getItems(): void
  {
    if (!this.currentRequest)  // should not have been called, if no current request
      return;

    // get all related LineItems
    this.requestService.getItems(this.currentRequest.Id).then(resp => this.currentItems = resp);
  }


  constructor(
    private lineItemService: PrLineItemService,
    private requestService: PurchaseRequestService,
    private statusService: StatusService,
    private sysService: SystemService
  ) { }

}
