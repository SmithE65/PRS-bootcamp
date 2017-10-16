import { Component, OnInit } from '@angular/core';

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

  getProducts(): void
  {
    this.productService.list().then(resp => this.products = resp);
  }

  constructor(
    private productService: ProductService,
    private cartService: ShoppingCartService,
    private sysService: SystemService
  ) { }

  ngOnInit() {
    this.getProducts();
  }

}
