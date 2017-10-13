import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../models/purchaserequest';

const urlBase: string = "http://localhost:51910/PurchaseRequests/";

@Injectable()
export class PurchaseRequestService {

  add(pr: PurchaseRequest): Promise<any>
  {
    let url = urlBase + "Add";
    return this.http.post(url, pr).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  delete(id: string): Promise<any>
  {
    let url = urlBase + "Remove/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  get(id: string): Promise<PurchaseRequest>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequest).catch(this.handleError);
  }

  list(): Promise<PurchaseRequest[]>
  {
    let url = urlBase + "List";
    return this.http.get(url).toPromise().then(resp => resp.json() as PurchaseRequest[]).catch(this.handleError);
  }

  update(pr: PurchaseRequest): Promise<any>
  {
    let url = urlBase + "Update";
    return this.http.post(url, pr).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  handleError(error): Promise<any>
  {
    console.error("YOU BROKE IT!", error);
    return Promise.reject(error.message || error);
  }

  constructor(private http: Http) { }

}
