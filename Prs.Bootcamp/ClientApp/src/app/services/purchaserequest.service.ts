// core angular imports
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

// models
import { Cart } from '../models/cart';
import { PurchaseRequestLineItem } from '../models/lineitem';
import { PurchaseRequest } from '../models/purchaserequest';

const urlBase: string = "http://localhost:51910/PurchaseRequests/";

@Injectable({
  providedIn: 'root',
})
export class PurchaseRequestService {

  // add a request to the db
  add(pr: PurchaseRequest)
  {
    let url = urlBase + "Add";
    return this.http.post(url, pr);
  }

  // remove a request from the db
  delete(id: number)
  {
    let url = urlBase + "Remove/" + id;
    return this.http.delete(url);
  }

  // get a request from the db
  get(id: string): Observable<PurchaseRequest>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get<PurchaseRequest>(url);
  }

  getByStatus(id: number): Observable<PurchaseRequest[]>
  {
    let url = urlBase + "GetByStatus/" + id;
    return this.http.get<PurchaseRequest[]>(url);
  }

  // get all requests by a given user
  getByUser(id: number): Observable<PurchaseRequest[]>
  {
    let url = urlBase + "GetByUser/" + id;
    return this.http.get<PurchaseRequest[]>(url);
  }

  // gets a whole cart (request & lineitems) from the server
  getCart(id: string): Observable<Cart>
  {
    let url = urlBase + "GetCart/" + id;
    return this.http.get<Cart>(url);
  }

  // gets all lineitems attached to PurchaseRequestId
  getItems(id: number): Observable<PurchaseRequestLineItem[]>
  {
    let url = urlBase + "GetItems/" + id;
    return this.http.get<PurchaseRequestLineItem[]>(url);
  }

  // get all the requests from the db
  list(): Observable<PurchaseRequest[]>
  {
    let url = urlBase + "List";
    return this.http.get<PurchaseRequest[]>(url);
  }

  // patch a request to the db
  update(pr: PurchaseRequest)
  {
    let url = urlBase + "Update";
    return this.http.post(url, pr);
  }

  // posts a whole cart (request & lineitems) to the server
  updateCart(cart: Cart)
  {
    let url = urlBase + "UpdateCart";
    //console.log("UpdateCart:", cart);
    return this.http.post(url, cart);
  }

  constructor(private http: HttpClient) { }
}
