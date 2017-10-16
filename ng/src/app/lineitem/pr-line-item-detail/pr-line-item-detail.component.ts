import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { LineItem } from '../../models/lineitem';

import { PrLineItemService } from '../../services/pr-line-item.service';

@Component({
  selector: 'app-pr-line-item-detail',
  templateUrl: './pr-line-item-detail.component.html',
  styleUrls: ['./pr-line-item-detail.component.css']
})
export class PrLineItemDetailComponent implements OnInit {

  lineitem: LineItem;

  delete(): void
  {
    this.lineitemService.delete(this.lineitem.Id);
  }

  edit(): void
  {
    this.router.navigate(['/lineitems/edit/' + this.lineitem.Id]);
  }

  getItems(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.lineitemService.get(params.get('id')))
      .subscribe(resp => this.lineitem = resp);
  }

  constructor(
    private lineitemService: PrLineItemService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getItems();
  }

}
