import { Injectable } from '@angular/core';

import { User } from '../models/user';

@Injectable()
export class SystemService {

    currentUser: User = null;
    loggedIn: boolean = false;

    save(): void
    {
        localStorage.setItem('currentUser', JSON.stringify(this.currentUser));
    }

    load(): void
    {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
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
        localStorage.removeItem('currentUser');
    }

  constructor() { }

}
