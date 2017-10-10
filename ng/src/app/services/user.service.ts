import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs';

import { User } from '../models/user';

const urlBase: string = "http://localhost:51910/";

@Injectable()
export class UserService {

  constructor(private http: Http) { }

  login(username: string, password: string): Promise<User[]>
  {
      let url = urlBase + "Login?username=" + username + "$password=" + password;

      return this.http.get(url).toPromise().then(resp => resp.json() as User[]).catch(this.handleError);
  }

  //add(user: User): Promise<User>
  //{

  //}

  //delete(id: number): Promise<any>
  //{

  //}

  get(id): Promise<User>
  {
      let url = urlBase + "Users/Get/" + id;

      return this.http.get(url).toPromise().then(resp => resp.json() as User).catch(this.handleError);
  }

  list(): Promise<User[]>
  {
      let url = urlBase + "Users/List";

      return this.http.get(url).toPromise().then(resp => resp.json() as User[]).catch(this.handleError);
  }

  //update(user: User): Promise<any>
  //{

  //}

  private handleError(error: any): Promise<any>
  {
      console.error('YOU BROKE IT!', error);
      return Promise.reject(error.message || error);
  }
}
