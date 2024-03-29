// core imports
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// models
import { Product } from '../../models/product';
import { Vendor } from '../../models/vendor';

// services
import { ProductService } from '../../services/product.service';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  product: Product | undefined;
  vendors: Vendor[] = [];

  add(): void {
    if (this.product) {
      this.productService.add(this.product).subscribe(resp => { console.log(resp); this.router.navigate(['/products']) });
    }
  }

  initProduct(): void {
    this.product = new Product(0, 1, this.vendors[0], '', '', '', 0, '', '');
  }

  getVendors(): void {
    this.vendorService.list().subscribe(vendors => { this.vendors = vendors; this.initProduct() });
  }

  constructor(
    private productService: ProductService,
    private vendorService: VendorService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getVendors();
  }

}
