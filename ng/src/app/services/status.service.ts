import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { Status } from '../models/status';

const urlBase: string = "http://localhost:51910/Status/";

@Injectable()
export class StatusService {

  add(status: Status): Promise<any>
  {
    let url = urlBase + "Add";
    return this.http.post(url, status).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  delete(id: number): Promise<any>
  {
    let url = urlBase + "Remove/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  get(id: string): Promise<Status>
  {
    let url = urlBase + "Get/" + id;
    return this.http.get(url).toPromise().then(resp => resp.json() as Status).catch(this.handleError);
  }

  list(): Promise<Status[]>
  {
    let url = urlBase + "List";
    return this.http.get(url).toPromise().then(resp => resp.json() as Status[]).catch(this.handleError);
  }

  update(status: Status): Promise<any>
  {
    let url = urlBase + "Update";
    return this.http.post(url, status).toPromise().then(resp => resp.json() || {}).catch(this.handleError);
  }

  handleError(error): Promise<any>
  {
    console.error("YOU BROKE IT!", error);
    return Promise.reject(resp => error.message || error);
  }

  constructor(private http: Http) { }

}
