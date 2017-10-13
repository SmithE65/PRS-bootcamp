import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { Product } from '../../models/product';
import { Vendor } from '../../models/vendor';

import { ProductService } from '../../services/product.service';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product;
  vendors: Vendor[];

  getProduct(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.productService.get(params.get('id')))
      .subscribe((product: Product) => { this.product = product; console.log(product) });
  }

  getVendors(): void
  {
    this.vendorService.list().then((vendors: Vendor[]) => this.vendors = vendors);
  }

  delete(): void
  {
    this.productService.delete(this.product.Id).then(resp => { console.log(resp); this.router.navigate(['/products']) });
  }

  update(): void
  {
    console.log(this.product);
    this.productService.update(this.product).then(resp => { console.log(resp); this.router.navigate(['/products']) });
  }

  constructor(
    private productService: ProductService,
    private vendorService: VendorService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getProduct();
    this.getVendors();
  }

}
