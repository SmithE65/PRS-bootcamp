import { Injectable } from '@angular/core';

import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class SystemService {

  currentUser: User | null = null;
  loggedIn: boolean = false;

  getLoggedInUserName(): string {
    if (this.currentUser === null) {
      return "";
    }

    return this.currentUser.UserName;
  }

  isAdmin(): boolean {
    if (this.currentUser) {
      return this.currentUser.IsAdmin;
    }

    return false;
  }

  isReviewer(): boolean {
    if (this.currentUser) {
      return this.currentUser.IsReviewer;
    }

    return false;
  }

  save(): void {
    sessionStorage.setItem('currentUser', JSON.stringify(this.currentUser));
  }

  load(): void {
    var item = sessionStorage.getItem('currentUser');
    if (item) {
      this.currentUser = JSON.parse(item);
      if (this.currentUser) {
        this.loggedIn = true;
        return;
      }
    }

    this.loggedIn = false;
  }

  delete(): void {
    sessionStorage.removeItem('currentUser');
  }

  constructor() { }

}
