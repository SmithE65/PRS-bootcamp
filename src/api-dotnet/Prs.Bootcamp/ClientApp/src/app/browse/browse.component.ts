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

  products: Product[] = [];

  addToCart(product: Product): void
  {
    console.log("Cart product:", product);
    // add the thing to the cart
    this.cartService.addProduct(product);
    this.router.navigate(['/cart']); // go to the cart
  }

  checkCart(id: number): boolean
  {
    return this.cartService.checkProduct(id);
  }

  getProducts(): void
  {
    this.productService.list().subscribe(resp => this.products = resp);
  }

  viewCart(): void
  {
    this.router.navigate(['/cart']);
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
