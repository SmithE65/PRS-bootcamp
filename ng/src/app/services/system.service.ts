import { Injectable } from '@angular/core';

import { User } from '../models/user';

@Injectable()
export class SystemService {

    currentUser: User = null;
    loggedIn: boolean = false;

    save(): void
    {
        sessionStorage.setItem('currentUser', JSON.stringify(this.currentUser));
    }

    load(): void
    {
        this.currentUser = JSON.parse(sessionStorage.getItem('currentUser'));
        if (this.currentUser)
        {
            this.loggedIn = true;
        }
        else
        {
            this.loggedIn = false;
        }
    }

    delete(): void
    {
        sessionStorage.removeItem('currentUser');
    }

  constructor() { }

}
