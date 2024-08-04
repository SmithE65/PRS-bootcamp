import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequest } from '../../models/purchaserequest';

import { PurchaseRequestService } from '../../services/purchaserequest.service';
import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-detail',
  templateUrl: './purchaserequest-detail.component.html',
  styleUrls: ['./purchaserequest-detail.component.css']
})
export class PurchaserequestDetailComponent implements OnInit {

  request: PurchaseRequest | undefined;

  delete(): void {
    if (this.request) {
      this.prService.delete(this.request.Id).subscribe(resp => { console.log(resp); this.router.navigate(['/requests']) });
    }
  }

  edit(): void {
    if (this.request) {
      this.router.navigate(['/requests/edit/' + this.request.Id]);
    }
  }

  getRequest(): void {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.prService.get(id).subscribe(resp => this.request = resp);
      }
    });
  }

  constructor(
    private prService: PurchaseRequestService,
    private sysService: SystemService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getRequest();
  }

}
