import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../../models/purchaserequest';
import { User } from '../../models/user';

import { PurchaseRequestService } from '../../services/purchaserequest.service';

@Component({
  selector: 'app-purchaserequest-list',
  templateUrl: './purchaserequest-list.component.html',
  styleUrls: ['./purchaserequest-list.component.css']
})
export class PurchaserequestListComponent implements OnInit {

  requests: PurchaseRequest[];

  getRequests(): void
  {
    this.prService.list().then(resp => this.requests = resp);
  }

  constructor(private prService: PurchaseRequestService) { }

  ngOnInit() {
    this.getRequests();
  }

}
