import { Component, OnInit } from '@angular/core';

import { Vendor } from '../../models/vendor';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.css']
})
export class VendorListComponent implements OnInit {

  vendors: Vendor[] = [];

  getVendors(): void
  {
    this.vendorService.list().subscribe(resp => this.vendors = resp);
  }

  constructor(private vendorService: VendorService) { }

  ngOnInit() {
    this.getVendors();
  }

}
