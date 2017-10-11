import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../models/user';
import { UserService } from '../services/user.service';
import { SystemService } from '../services/system.service';


//interface UserResponse {
//    user: User;
//}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    username: string = "";
    password: string = "";
    message: string = "";

    user: User;

    login(): void {
        this.message = "";

        this.userService.login(this.username, this.password).then(data => this.checkData(data));
        
    }

    logout(): void
    {
        this.systemService.currentUser = null;
        this.systemService.loggedIn = false;
        this.systemService.delete();
        this.router.navigate(['/login']);
    }

    checkData(users: User[]): void {
        if (users.length == 0)
        {
            console.log("Error: no data");
            this.message = "Invalid User Name / Password combination.";
            this.systemService.currentUser = null;
            this.systemService.loggedIn = false;
            this.systemService.delete();
        }
        else {  // we have at least one valid user; take the first
            console.log(users);
            this.user = users[0]; // maybe use this
            this.systemService.currentUser = users[0];  // log in at the system level
            this.systemService.loggedIn = true;
            this.systemService.save();
            this.router.navigate(['/home']);
        }
    }
 
  constructor(private userService: UserService, private systemService: SystemService, private router: Router) { }

  ngOnInit() {
      this.systemService.load();
  }

}
