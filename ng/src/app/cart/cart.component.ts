// angular
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// rxjs
import 'rxjs/add/operator/toPromise';

// services
import { PrLineItemService } from '../services/pr-line-item.service';
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
    console.log(this.cartService.currentItems);
  }

  delete(id: number): void
  {
    this.lineitemService.delete(id).then(resp => { console.log(resp); this.cartService.load() });
  }

  submit(): void
  {
    this.cartService.submit();
    this.router.navigate(['/home']);
  }

  update(): void
  {
    this.cartService.update();
  }

  constructor(
    private cartService: ShoppingCartService,
    private lineitemService: PrLineItemService,
    private router: Router,
    private sysService: SystemService
  ) { }

  ngOnInit() {
    if (this.sysService.loggedIn)
    {
      this.cartService.load();
    }
  }

}
