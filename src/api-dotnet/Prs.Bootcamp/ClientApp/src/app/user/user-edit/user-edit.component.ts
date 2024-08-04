import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  user: User | undefined;

  delete(): void {
    if (this.user) {
      this.userService.delete(this.user.Id).subscribe(resp => { console.log(resp); this.router.navigate(['/users']) });
    }
  }

  update(): void {
    if (this.user) {
      this.userService.update(this.user).subscribe(resp => { console.log(resp); this.router.navigate(['/users']) });
    }
  }

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      var id = params.get('id');
      if (id) {
        this.userService.get(id).subscribe((user: User) => this.user = user);
      }
    });
  }
}
