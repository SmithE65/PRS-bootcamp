import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { Product } from '../models/product';
import { Vendor } from '../models/vendor';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl + "api/Products/";
  }

  private urlBase: string;

  add(product: Product)
  {
    let url = this.urlBase + "Add";
    return this.http.post(url, product);
  }

  delete(id: number)
  {
    let url = this.urlBase + "Remove/" + id;
    return this.http.delete(url);
  }

  get(id: string): Observable<Product>
  {
    let url = this.urlBase + "Get/" + id;
    return this.http.get<Product>(url);
  }

  list(): Observable<Product[]>
  {
    let url = this.urlBase + "List";
    return this.http.get<Product[]>(url);
  }

  update(product: Product)
  {
    let url = this.urlBase + "Update";
    return this.http.post(url, product);
  }
}
