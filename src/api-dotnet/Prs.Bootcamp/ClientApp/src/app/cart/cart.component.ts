// angular
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
    this.lineitemService.delete(id).subscribe(resp => { console.log(resp); this.cartService.load() });
  }

  getCurrentRequestDateNeeded(): Date {
    if (this.cartService.currentRequest?.DateNeeded) {
      return this.cartService.currentRequest.DateNeeded;
    }
    return new Date(1970,1,1);
  }

  getCurrentRequestDescription(): string {
    if (this.cartService.currentRequest?.Description) {
      return this.cartService.currentRequest.Description;
    }
    return "";
  }

  getCurrentRequestId(): number {
    if (this.cartService.currentRequest?.Id) {
      return this.cartService.currentRequest.Id;
    }
    return -1;
  }

  getCurrentRequestTotal(): number {
    if (this.cartService.currentRequest?.Total) {
      return this.cartService.currentRequest.Total;
    }
    return -1;
  }

  getCurrentRequestUserName(): string {
    if (this.cartService.currentRequest?.User?.UserName) {
      return this.cartService.currentRequest.User.UserName;
    }
    return "";
  }

  getUserName(): string {
    if (this.sysService.currentUser?.UserName) {
      return this.sysService.currentUser.UserName;
    }
    return "";
  }

  isCartInitialized(): boolean {
    return !!this.cartService.currentRequest;
  }

  isUserSignedIn(): boolean {
    return !!this.sysService.currentUser;
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
    public cartService: ShoppingCartService,
    public lineitemService: PrLineItemService,
    private router: Router,
    public sysService: SystemService
  ) { }

  ngOnInit() {
    if (this.sysService.loggedIn)
    {
      this.cartService.load();
    }
  }

}
