import { Component, OnInit } from '@angular/core';

import { PurchaseRequest } from '../models/purchaserequest';
import { Status } from '../models/status';

import { PurchaseRequestService } from '../services/purchaserequest.service';
import { StatusService } from '../services/status.service';
import { SystemService } from '../services/system.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  reviews: PurchaseRequest[] = [];

  getReviews(): void
  {
    let id = 2;
    let status: Status[];

    this.statusService.getbydesc("REVIEW").subscribe(resp => status = resp);

    if (!!status! && status[0] != undefined) {
      id = status[0].Id;
    }

    this.requestService.getByStatus(id).subscribe(resp => this.reviews = resp);
  }

  constructor(
    private requestService: PurchaseRequestService,
    private statusService: StatusService,
    public sysService: SystemService
  ) { }

  ngOnInit() {
    this.getReviews();
  }

}
