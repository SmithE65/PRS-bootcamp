// angular core
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

// rxjs
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

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

  request: PurchaseRequest;
  lineitems: PurchaseRequestLineItem[];
  status: Status[];

  accept(): void
  {
    if (status == undefined)
      return;

    let s = this.status.find(st => st.Description == "ACCEPTED");
    if (s == undefined)
    {
      console.log("No status found for ACCEPTED.");
      return;
    }

    this.request.Status = s;
    this.request.StatusId = s.Id;
    this.requestService.update(this.request).then(resp => { console.log(resp); this.router.navigate(['/review']) });
  }

  debug(): void
  {
    console.log(this.request);
    console.log(this.lineitems);
  }

  getRequest(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.requestService.getCart(params.get('id')))
      .subscribe(resp => { this.request = resp.request; this.lineitems = resp.lineitems });
  }

  getStatus(): void
  {
    this.statusService.list().then(resp => this.status = resp);
  }

  reject(): void
  {
    if (status == undefined)
      return;

    let s = this.status.find(st => st.Description == "REJECTED");
    if (s == undefined) {
      console.log("No status found for REJECTED.");
      return;
    }

    this.request.Status = s;
    this.request.StatusId = s.Id;
    this.requestService.update(this.request).then(resp => { console.log(resp); this.router.navigate(['/review']) });
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
