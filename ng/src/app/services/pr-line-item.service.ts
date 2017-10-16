import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { LineItem } from '../models/lineitem';

const urlBase: string = "http://localhost:4200/PurchaseRequestLineItems/"

@Injectable()
export class PrLineItemService {

  add(lineitem: LineItem): Promise<any>
  {
    let url = urlBase + "Add";
    return this.http.post(url, lineitem).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  delete(id: number): Promise<any>
  {
    let url = urlBase + "Remove/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  get(id: string): Promise<LineItem>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as LineItem).catch(this.handleError);
  }

  list(): Promise<LineItem[]>
  {
    let url = urlBase + "List";
    return this.http.get(url).toPromise().then(resp => resp.json() as LineItem[]).catch(this.handleError);
  }

  update(lineitem: LineItem): Promise<any>
  {
    let url = urlBase + "Update";
    return this.http.post(url, lineitem).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  handleError(error): Promise<any>
  {
    console.error(error);
    return Promise.reject(error.message || error);
  }

  constructor(private http: Http) { }

}
