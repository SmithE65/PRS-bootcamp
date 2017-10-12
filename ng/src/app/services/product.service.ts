import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Product } from '../models/product';
import { Vendor } from '../models/vendor';

const urlBase: string = "http://localhost:51910/Products/";

@Injectable()
export class ProductService {

  add(product: Product): Promise<any>
  {
    let url = urlBase + "Add";
    return this.http.post(url, product).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  delete(id: number): Promise<any>
  {
    let url = urlBase + "Remove/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  get(id: string): Promise<Product>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as Product).catch(this.handleError);
  }

  list(): Promise<Product[]>
  {
    let url = urlBase + "List";
    return this.http.get(url).toPromise().then(resp => resp.json() as Product[]).catch(this.handleError);
  }

  update(product: Product): Promise<any>
  {
    let url = urlBase + "Update";
    return this.http.post(url, product).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  handleError(error): Promise<any>
  {
    console.error("Product error", error);
    return Promise.reject(error.message || error);
  }

  constructor(private http: Http) { }

}
