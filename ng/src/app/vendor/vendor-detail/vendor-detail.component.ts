import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { Vendor } from '../../models/vendor';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-vendor-detail',
  templateUrl: './vendor-detail.component.html',
  styleUrls: ['./vendor-detail.component.css']
})
export class VendorDetailComponent implements OnInit {

  vendor: Vendor;

  getVendor(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.vendorService.get(params.get('id'))
    )
      .subscribe((vendor: Vendor) => this.vendor = vendor);
  }

  constructor(private vendorService: VendorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getVendor();
  }

}
