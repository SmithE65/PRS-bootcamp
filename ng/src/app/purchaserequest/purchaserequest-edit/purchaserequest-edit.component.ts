import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { PurchaseRequest } from '../../models/purchaserequest';
import { Status } from '../../models/status';

import { PurchaseRequestService } from '../../services/purchaserequest.service';
import { StatusService } from '../../services/status.service';
import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-edit',
  templateUrl: './purchaserequest-edit.component.html',
  styleUrls: ['./purchaserequest-edit.component.css']
})
export class PurchaserequestEditComponent implements OnInit {

  request: PurchaseRequest;

  status: Status[];

  getRequest(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.prService.get(params.get('id')))
      .subscribe(resp => this.request = resp);
  }

  getStatus(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.statusService.list())
      .subscribe(resp => this.status = resp);
  }

  constructor(
    private prService: PurchaseRequestService,
    private statusService: StatusService,
    private systemService: SystemService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getRequest();
    this.getStatus();
  }

}
