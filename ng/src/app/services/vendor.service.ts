import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs';

import { Vendor } from '../models/vendor';

const urlBase: string = "http://localhost:51910/Vendors/";

@Injectable()
export class VendorService {

  add(vendor: Vendor): Promise<any>
  {
    let url = urlBase + "Add";
    return this.http.post(url, vendor).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  delete(id): Promise<any>
  {
    let url = urlBase + "Remove/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  get(id): Promise<Vendor>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as Vendor).catch(this.handleError);
  }

  list(): Promise<Vendor[]>
  {
    let url = urlBase + "List";
    return this.http.get(url).toPromise().then(resp => resp.json() as Vendor[]).catch(this.handleError);
  }

  update(vendor: Vendor): Promise<any>
  {
    let url = urlBase + "Update";
    return this.http.post(url, vendor).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  handleError(error: any): Promise<any> {
    console.error("Vendor error", error);
    return Promise.reject(error.message || error);
  }

  constructor(private http: Http) { }

}
