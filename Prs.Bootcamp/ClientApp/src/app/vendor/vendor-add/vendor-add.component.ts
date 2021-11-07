import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Vendor } from '../../models/vendor';
import { VendorService } from '../../services/vendor.service';

@Component({
  selector: 'app-vendor-add',
  templateUrl: './vendor-add.component.html',
  styleUrls: ['./vendor-add.component.css']
})
export class VendorAddComponent implements OnInit {

  vendor: Vendor = new Vendor(0, '', '', '', '', '', '', '', '', false);

  add(): void {
    this.vendorService.add(this.vendor).subscribe(resp => { console.log(resp); this.router.navigate(['/vendors']) });
  }

  constructor(private vendorService: VendorService, private router: Router) { }

  ngOnInit() {
  }

}
