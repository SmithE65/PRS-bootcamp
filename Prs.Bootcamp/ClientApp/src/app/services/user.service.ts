import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { User } from '../models/user';

const urlBase: string = "http://localhost:51910/";

@Injectable({
  providedIn: 'root',
})
export class UserService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<User[]> {
    let url = urlBase + "Users/Login?username=" + username + "&password=" + password;

    return this.http.get<User[]>(url);
  }

  add(user: User) {
    let url = urlBase + "Users/Add";
    return this.http.post(url, user);
  }

  delete(id: number) {
    let url = urlBase + "Users/Remove/" + id;
    return this.http.delete(url);
  }

  get(id: number): Observable<User> {
    let url = urlBase + "Users/Get/" + id;

    return this.http.get<User>(url);
  }

  list(): Observable<User[]> {
    let url = urlBase + "Users/List";

    return this.http.get<User[]>(url);
  }

  update(user: User) {
    let url = urlBase + "Users/Update";
    return this.http.post(url, user);
  }
}
