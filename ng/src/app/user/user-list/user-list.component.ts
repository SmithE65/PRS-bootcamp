import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

    users: User[];

    getUsers(): void
    {
        this.userService.list().then(resp => this.users = resp);
    }

  constructor(private userService: UserService) { }

  ngOnInit() {
      this.getUsers();
  }

}
