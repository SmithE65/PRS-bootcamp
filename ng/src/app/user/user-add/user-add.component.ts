import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {

    user: User = new User(0, '', '', '', '', '', '', false, false);

    add(): void
    {
        this.userService.add(this.user).then(resp => { console.log(resp); this.router.navigate(['/users']) });
    }

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

}
