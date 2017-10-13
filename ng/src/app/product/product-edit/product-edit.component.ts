// core imports
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

// prommises
import 'rxjs/add/operator/toPromise';

// models
import { Product } from '../../models/product';
import { Vendor } from '../../models/vendor';

// services
import { ProductService } from '../../services/product.service';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product;   // stores product to be edited
  vendors: Vendor[];  // list of vendors for drop-down

  // downloads product to be edited by id pulled from route url
  getProduct(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.productService.get(params.get('id')))
      .subscribe((product: Product) => { this.product = product; console.log(product) });
  }

  // pulls array of vendors from back end
  getVendors(): void
  {
    this.vendorService.list().then((vendors: Vendor[]) => this.vendors = vendors);
  }

  // requests a delete of current product by its Id
  delete(): void
  {
    this.productService.delete(this.product.Id).then(resp => { console.log(resp); this.router.navigate(['/products']) });
  }

  // posts updated product to back end
  update(): void
  {
    console.log(this.product);
    this.productService.update(this.product).then(resp => { console.log(resp); this.router.navigate(['/products']) });
  }

  // register services
  constructor(
    private productService: ProductService,
    private vendorService: VendorService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  // do init
  ngOnInit() {
    this.getProduct();
    this.getVendors();
  }

}
