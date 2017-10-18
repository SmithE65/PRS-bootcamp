import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { PurchaseRequestLineItem } from '../../models/lineitem';

import { PrLineItemService } from '../../services/pr-line-item.service';

@Component({
  selector: 'app-pr-line-item-edit',
  templateUrl: './pr-line-item-edit.component.html',
  styleUrls: ['./pr-line-item-edit.component.css']
})
export class PrLineItemEditComponent implements OnInit {

  lineitem: PurchaseRequestLineItem;

  getItem(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.lineitemService.get(params.get('id')))
      .subscribe(resp => this.lineitem = resp);
  }

  update(): void
  {
    this.lineitemService.update(this.lineitem).then(resp => console.log(resp));
  }

  constructor(
    private lineitemService: PrLineItemService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getItem();
  }

}
