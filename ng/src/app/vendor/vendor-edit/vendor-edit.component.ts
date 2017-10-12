import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { Vendor } from '../../models/vendor';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-vendor-edit',
  templateUrl: './vendor-edit.component.html',
  styleUrls: ['./vendor-edit.component.css']
})
export class VendorEditComponent implements OnInit {

  vendor: Vendor;

  delete(): void
  {
    this.vendorService.delete(this.vendor.Id).then(resp => { console.log(resp); this.router.navigate(['/vendors']) });
  }

  update(): void
  {
    this.vendorService.update(this.vendor).then(resp => { console.log(resp); this.router.navigate(['/vendors']) });
  }

  getVendor(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.vendorService.get(params.get('id'))
    ).subscribe(resp => this.vendor = resp);
  }

  constructor(private vendorService: VendorService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getVendor();
  }

}
