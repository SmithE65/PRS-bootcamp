import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { CurrencyPipe } from '@angular/common';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs';

import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];

  getProducts(): void
  {
    this.productService.list().then(resp => this.products = resp);
  }

  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getProducts();
  }

}
