import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { PurchaseRequest } from '../models/purchaserequest';
import { Status } from '../models/status';

import { PurchaseRequestService } from '../services/purchaserequest.service';
import { StatusService } from '../services/status.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {

  reviews: PurchaseRequest[];

  getReviews(): void
  {
    let id = 2;
    let status: Status[];

    this.statusService.getbydesc("REVIEW").then(resp => status = resp);

    if (status != undefined && status[0] != undefined)
      id = status[0].Id;

    this.requestService.getByStatus(id).then(resp => this.reviews = resp);
  }

  constructor(
    private requestService: PurchaseRequestService,
    private statusService: StatusService
  ) { }

  ngOnInit() {
    this.getReviews();
  }

}
