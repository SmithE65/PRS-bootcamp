// angular
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// models
import { User } from '../models/user';

// services
import { UserService } from '../services/user.service';
import { ShoppingCartService } from '../services/shopping-cart.service';
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

  // values in log-in form
  username: string = "";
  password: string = "";
  message: string = "";

  // current user
  user: User | undefined;

  // login button pressed
  login(): void {
    this.message = "";  // clear message

    // send username and password to server and see if we get a valid user
    this.userService.login(this.username, this.password).subscribe(data => this.checkData(data));
  }

  // sign out
  logout(): void {
    this.systemService.currentUser = null;  // remove current user
    this.systemService.loggedIn = false;    // set logged-in flag to false
    this.systemService.delete();            // remove user from local storage
    this.cartService.unload();              // clean up shopping cart
    this.router.navigate(['/home']);        // go back to the home page
  }

  // check the results of our login call to the server
  checkData(users: User[]): void {
    if (users.length == 0)  // no users returned
    {
      console.log("Error: no data");
      this.message = "Invalid User Name / Password combination.";
      this.systemService.currentUser = null;
      this.systemService.loggedIn = false;
      this.systemService.delete();
    }
    else {  // we have at least one valid user; take the first (any more should be handled db side, username should be unique)
      //console.log(users);
      this.user = users[0]; // maybe use this
      this.systemService.currentUser = users[0];  // log in at the system level
      this.systemService.loggedIn = true;
      this.systemService.save();
      this.cartService.load();  // if we have a valid user, we should load the cart
      this.router.navigate(['/home']);  // success! go to home page
    }
  }

  constructor(
    private cartService: ShoppingCartService,
    private userService: UserService,
    public systemService: SystemService,
    private router: Router
  ) { }

  ngOnInit() {
    this.systemService.load();
  }

}
