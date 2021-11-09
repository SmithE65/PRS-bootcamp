import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Vendor } from '../models/vendor';

const urlBase: string = "http://localhost:51910/Vendors/";

@Injectable({
  providedIn: 'root',
})
export class VendorService {

  add(vendor: Vendor)
  {
    let url = urlBase + "Add";
    return this.http.post(url, vendor);
  }

  delete(id: number)
  {
    let url = urlBase + "Remove/" + id;
    return this.http.delete(url);
  }

  get(id: number): Observable<Vendor>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get<Vendor>(url);
  }

  list(): Observable<Vendor[]>
  {
    let url = urlBase + "List";
    return this.http.get<Vendor[]>(url);
  }

  update(vendor: Vendor)
  {
    let url = urlBase + "Update";
    return this.http.post(url, vendor);
  }

  constructor(private http: HttpClient) { }
}
