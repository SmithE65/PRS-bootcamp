import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product | undefined;

  getProduct()
  {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.productService.get(id)
          .subscribe(product => this.product = product);
      }
    });
  }

  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getProduct();
  }

}
