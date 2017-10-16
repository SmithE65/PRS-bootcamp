import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../../models/purchaserequest';

import { PurchaseRequestService } from '../../services/purchaserequest.service';
import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-detail',
  templateUrl: './purchaserequest-detail.component.html',
  styleUrls: ['./purchaserequest-detail.component.css']
})
export class PurchaserequestDetailComponent implements OnInit {

  request: PurchaseRequest;

  delete(): void
  {
    this.prService.delete(this.request.Id).then(resp => { console.log(resp); this.router.navigate(['/requests']) });
  }

  edit(): void
  {
    this.router.navigate(['/requests/edit/' + this.request.Id]);
  }

  getRequest(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.prService.get(params.get('id')))
      .subscribe(resp => this.request = resp);
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
