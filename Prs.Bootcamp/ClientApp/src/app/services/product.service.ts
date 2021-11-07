import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { Product } from '../models/product';
import { Vendor } from '../models/vendor';

const urlBase: string = "http://localhost:51910/Products/";

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  add(product: Product)
  {
    let url = urlBase + "Add";
    return this.http.post(url, product);
  }

  delete(id: number)
  {
    let url = urlBase + "Remove/" + id;
    return this.http.delete(url);
  }

  get(id: string): Observable<Product>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get<Product>(url);
  }

  list(): Observable<Product[]>
  {
    let url = urlBase + "List";
    return this.http.get<Product[]>(url);
  }

  update(product: Product)
  {
    let url = urlBase + "Update";
    return this.http.post(url, product);
  }

  constructor(private http: HttpClient) { }
}
