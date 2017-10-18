// core angular imports
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

// rxjs operators
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

// models
import { Cart } from '../models/cart';
import { PurchaseRequestLineItem } from '../models/lineitem';
import { PurchaseRequest } from '../models/purchaserequest';

const urlBase: string = "http://localhost:51910/PurchaseRequests/";

@Injectable()
export class PurchaseRequestService {

  // add a request to the db
  add(pr: PurchaseRequest): Promise<any>
  {
    let url = urlBase + "Add";
    return this.http.post(url, pr).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  // remove a request from the db
  delete(id: number): Promise<any>
  {
    let url = urlBase + "Remove/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  // get a request from the db
  get(id: string): Promise<PurchaseRequest>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequest).catch(this.handleError);
  }

  getByStatus(id: number): Promise<PurchaseRequest[]>
  {
    let url = urlBase + "GetByStatus/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequest[]).catch(this.handleError);
  }

  // get all requests by a given user
  getByUser(id: number): Promise<PurchaseRequest[]>
  {
    let url = urlBase + "GetByUser/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequest[]).catch(this.handleError);
  }

  // gets a whole cart (request & lineitems) from the server
  getCart(id: string): Promise<Cart>
  {
    let url = urlBase + "GetCart/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as Cart).catch(this.handleError);
  }

  // gets all lineitems attached to PurchaseRequestId
  getItems(id: number): Promise<PurchaseRequestLineItem[]>
  {
    let url = urlBase + "GetItems/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequestLineItem[]).catch(this.handleError);
  }

  // get all the requests from the db
  list(): Promise<PurchaseRequest[]>
  {
    let url = urlBase + "List";
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequest[]).catch(this.handleError);
  }

  // patch a request to the db
  update(pr: PurchaseRequest): Promise<any>
  {
    let url = urlBase + "Update";
    return this.http.post(url, pr).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  // posts a whole cart (request & lineitems) to the server
  updateCart(cart: Cart): Promise<any>
  {
    let url = urlBase + "UpdateCart";
    //console.log("UpdateCart:", cart);
    return this.http.post(url, cart).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  // handle any errors... or don't... w/e
  handleError(error): Promise<any>
  {
    console.error("YOU BROKE IT!", error);
    return Promise.reject(error.message || error);
  }

  constructor(private http: Http) { }

}
