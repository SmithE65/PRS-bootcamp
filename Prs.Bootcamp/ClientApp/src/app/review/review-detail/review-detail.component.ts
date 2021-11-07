// angular core
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

// models
import { Cart } from '../../models/cart';
import { PurchaseRequest } from '../../models/purchaserequest';
import { PurchaseRequestLineItem } from '../../models/lineitem';
import { Status } from '../../models/status';

// services
import { PurchaseRequestService } from '../../services/purchaserequest.service';
import { PrLineItemService } from '../../services/pr-line-item.service';
import { StatusService } from '../../services/status.service';

@Component({
  selector: 'app-review-detail',
  templateUrl: './review-detail.component.html',
  styleUrls: ['./review-detail.component.css']
})
export class ReviewDetailComponent implements OnInit {

  request: PurchaseRequest | undefined;
  lineitems: PurchaseRequestLineItem[] = [];
  status: Status[] = [];

  accept(): void {
    if (!this.status || !this.request)
      return;

    let s = this.status.find(st => st.Description == "ACCEPTED");
    if (s == undefined) {
      console.log("No status found for ACCEPTED.");
      return;
    }

    this.request.Status = s;
    this.request.StatusId = s.Id;
    this.requestService.update(this.request).subscribe(resp => { console.log(resp); this.router.navigate(['/review']) });
  }

  debug(): void {
    console.log(this.request);
    console.log(this.lineitems);
  }

  getRequest(): void {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.requestService.getCart(id).subscribe(resp => { this.request = resp.request; this.lineitems = resp.lineitems; });
      }
    });
  }

  getStatus(): void {
    this.statusService.list().subscribe(resp => this.status = resp);
  }

  reject(): void {
    if (!this.status || !this.request)
      return;

    let s = this.status.find(st => st.Description == "REJECTED");
    if (s == undefined) {
      console.log("No status found for REJECTED.");
      return;
    }

    this.request.Status = s;
    this.request.StatusId = s.Id;
    this.requestService.update(this.request).subscribe(resp => { console.log(resp); this.router.navigate(['/review']) });
  }

  constructor(
    private requestService: PurchaseRequestService,
    private statusService: StatusService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getRequest();
    this.getStatus();
  }

}
