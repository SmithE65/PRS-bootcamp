import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

    user: User;

    delete(): void
    {
        this.userService.delete(this.user.Id).then(resp => { console.log(resp); this.router.navigate(['/users']) });
    }

    update(): void
    {
        this.userService.update(this.user).then(resp => { console.log(resp); this.router.navigate(['/users']) });
    }

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
      this.route.paramMap.switchMap((params: ParamMap) => this.userService.get(params.get('id'))).subscribe((user: User) => this.user = user);
  }

}
