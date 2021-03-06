import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'app-user-detail',
    templateUrl: './user-detail.component.html',
    styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  user: User;

  delete(): void
  {
    this.userService.delete(this.user.Id).then(resp => { console.log(resp); this.router.navigate(['/users']) });
  }

  edit(): void
  {
    this.router.navigate(['/users/edit/' + this.user.Id]);
  }

    getUser(): void
    {
      this.route.paramMap.switchMap(
        (params: ParamMap) => this.userService.get(params.get('id')))
        .subscribe((user: User) => this.user = user);
    }

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getUser();
  }

}
