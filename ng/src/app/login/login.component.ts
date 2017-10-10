import { Component, OnInit } from '@angular/core';

import { User } from '../models/user';
import { Http } from "@angular/http";


interface UserResponse {
    user: User;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    username: string = "";
    password: string = "";

    user: User;

    login(): void {
        let params = "username=" + this.username + "&password=" + this.password;

        this.http.get("http://localhost:51910/Users/Login?" + params).subscribe(data => this.checkData(data));
    }

    checkData(data: any): void {
        if (data.text().length == 0)
            console.log("Error: no data");
        else {
            console.log(data.json());
            this.user = data.json();
        }
    }
 
  constructor(private http: Http) { }

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
