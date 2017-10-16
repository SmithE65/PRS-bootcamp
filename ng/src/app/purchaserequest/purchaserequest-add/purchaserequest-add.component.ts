import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../../models/purchaserequest';
import { Status } from '../../models/status';

import { PurchaseRequestService } from '../../services/purchaserequest.service';
import { StatusService } from '../../services/status.service';
import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-add',
  templateUrl: './purchaserequest-add.component.html',
  styleUrls: ['./purchaserequest-add.component.css']
})
export class PurchaserequestAddComponent implements OnInit {

  request: PurchaseRequest = new PurchaseRequest(0, 0, '', '', new Date(Date.now() + 604800000), '', 0, 1, new Date());

  status: Status[];

  getStatus(): void
  {
    this.statusService.list().then(resp => this.status = resp);
  }

  constructor(
    private prService: PurchaseRequestService,
    private statusService: StatusService,
    private sysService: SystemService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getStatus();
    this.request.User = this.sysService.currentUser;
    this.request.UserId = this.sysService.currentUser.Id;
  }

}
