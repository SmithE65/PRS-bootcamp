import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../models/user';
import { UserService } from '../services/user.service';


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

    checkData(users: User[]): void {
        if (users.length == 0)
        {
            console.log("Error: no data");
            this.message = "Invalid User Name / Password combination.";
        }
        else {
            console.log(users);
            this.user = users[0];
        }
    }
 
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
      //this.http
      //    .get<UserResponse>("http://localhost:51910/Users/Login?UserName=admin&Password=admin")
      //    .subscribe(data => {
      //        console.log("data: ", data);
      //        console.log("data.user: ",data.user);
      //        console.log("this.user: ",this.user);
      //    });
  }

}
