import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  user: User | undefined;

  delete(): void {
    if (this.user) {
      this.userService.delete(this.user.Id).subscribe(resp => { console.log(resp); this.router.navigate(['/users']) });
    }
  }

  edit(): void {
    if (this.user) {
      this.router.navigate(['/users/edit/' + this.user.Id]);
    }
  }

  getUser(): void {
    this.route.queryParams.subscribe(
      (params) => {
        var id = params['id'];
        if (id) {
          this.userService.get(id)
            .subscribe(resp => this.user = resp);
        }
      });
  }

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getUser();
  }

}
