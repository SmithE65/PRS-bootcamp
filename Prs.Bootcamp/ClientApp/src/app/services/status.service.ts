// angular core
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

// models
import { Status } from '../models/status';

// API base
const urlBase: string = "http://localhost:51910/Status/";

@Injectable({
  providedIn: 'root',
})
export class StatusService {

  add(status: Status)
  {
    let url = urlBase + "Add";
    return this.http.post(url, status)
  }

  delete(id: number)
  {
    let url = urlBase + "Remove/" + id;
    return this.http.delete(url)
  }

  get(id: string): Observable<Status>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get<Status>(url);
  }

  getbydesc(desc: string): Observable<Status[]>
  {
    let url = urlBase + "GetByDesc?desc=" + desc;
    return this.http.get<Status[]>(url);
  }

  list(): Observable<Status[]>
  {
    let url = urlBase + "List";
    return this.http.get<Status[]>(url);
  }

  update(status: Status)
  {
    let url = urlBase + "Update";
    return this.http.post(url, status)
  }

  constructor(private http: HttpClient) { }
}
