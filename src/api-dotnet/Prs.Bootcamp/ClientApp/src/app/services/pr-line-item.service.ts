import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { PurchaseRequestLineItem } from '../models/lineitem';

const urlBase: string = "http://localhost:51910/PurchaseRequestLineItems/"

@Injectable({
  providedIn: 'root',
})
export class PrLineItemService {

  add(lineitem: PurchaseRequestLineItem)
  {
    let url = urlBase + "Add";
    return this.http.post(url, lineitem);
  }

  delete(id: number)
  {
    let url = urlBase + "Remove/" + id;
    return this.http.delete(url);
  }

  get(id: string): Observable<PurchaseRequestLineItem>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get<PurchaseRequestLineItem>(url);
  }

  list(): Observable<PurchaseRequestLineItem[]>
  {
    let url = urlBase + "List";
    return this.http.get<PurchaseRequestLineItem[]>(url);
  }

  update(lineitem: PurchaseRequestLineItem)
  {
    let url = urlBase + "Update";
    return this.http.post(url, lineitem);
  }

  constructor(private http: HttpClient) { }

}
