// angular
import { Component, OnInit } from '@angular/core';

// rxjs
import 'rxjs/add/operator/toPromise';

// services
import { ShoppingCartService } from '../services/shopping-cart.service';
import { SystemService } from '../services/system.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  debug(msg: any): void
  {
    console.log(msg);
  }

  constructor(
    private cartService: ShoppingCartService,
    private sysService: SystemService
  ) { }

  ngOnInit() {
    if (this.sysService.loggedIn)
    {
      this.cartService.load(this.sysService.currentUser.Id);
    }
  }

}
