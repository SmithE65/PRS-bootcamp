import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Product } from '../models/product';

import { ProductService } from '../services/product.service';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { SystemService } from '../services/system.service';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.css']
})
export class BrowseComponent implements OnInit {

  products: Product[];

  addtocart(id: number): void
  {
    // add the thing to the cart
    this.router.navigate(['/cart']); // go to the cart
  }

  getProducts(): void
  {
    this.productService.list().then(resp => this.products = resp);
  }

  constructor(
    private productService: ProductService,
    private cartService: ShoppingCartService,
    private sysService: SystemService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getProducts();
  }

}
