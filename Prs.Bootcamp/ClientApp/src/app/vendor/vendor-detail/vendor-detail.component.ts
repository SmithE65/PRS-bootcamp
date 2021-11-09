import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Vendor } from '../../models/vendor';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-vendor-detail',
  templateUrl: './vendor-detail.component.html',
  styleUrls: ['./vendor-detail.component.css']
})
export class VendorDetailComponent implements OnInit {

  vendor: Vendor | undefined;

  getVendor(): void {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.vendorService.get(id)
          .subscribe((vendor: Vendor) => this.vendor = vendor);
      }
    });
  }

  constructor(private vendorService: VendorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getVendor();
  }

}
