import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Vendor } from '../../models/vendor';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-vendor-edit',
  templateUrl: './vendor-edit.component.html',
  styleUrls: ['./vendor-edit.component.css']
})
export class VendorEditComponent implements OnInit {

  vendor: Vendor | undefined;

  delete(): void {
    if (this.vendor) {
    this.vendorService.delete(this.vendor.Id).subscribe(resp => { console.log(resp); this.router.navigate(['/vendors']) });
    }
  }

  update(): void {
    if (this.vendor) {
    this.vendorService.update(this.vendor).subscribe(resp => { console.log(resp); this.router.navigate(['/vendors']) });
    }
  }

  getVendor(): void {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.vendorService.get(id).subscribe(resp => this.vendor = resp);
      }
    });
  }

  constructor(private vendorService: VendorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getVendor();
  }

}
