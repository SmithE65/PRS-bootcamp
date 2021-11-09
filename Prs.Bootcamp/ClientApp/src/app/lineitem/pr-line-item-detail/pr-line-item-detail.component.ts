import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequestLineItem } from '../../models/lineitem';

import { PrLineItemService } from '../../services/pr-line-item.service';

@Component({
  selector: 'app-pr-line-item-detail',
  templateUrl: './pr-line-item-detail.component.html',
  styleUrls: ['./pr-line-item-detail.component.css']
})
export class PrLineItemDetailComponent implements OnInit {

  lineitem: PurchaseRequestLineItem | undefined;

  delete(): void {
    if (this.lineitem) {
      this.lineitemService.delete(this.lineitem.Id);
    }
  }

  edit(): void {
    if (this.lineitem) {
      this.router.navigate(['/lineitems/edit/' + this.lineitem.Id]);
    }
  }

  getItems(): void {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.lineitemService.get(id)
          .subscribe(resp => this.lineitem = resp);
      }
    });
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
