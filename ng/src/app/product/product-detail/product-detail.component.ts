import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { CurrencyPipe } from '@angular/common';

import 'rxjs/add/operator/toPromise';

import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product;

  getProduct()
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.productService.get(params.get('id')))
      .subscribe((product: Product) => this.product = product);
  }

  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getProduct();
  }

}
