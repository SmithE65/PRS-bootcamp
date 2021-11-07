import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequestLineItem } from '../../models/lineitem';

import { PrLineItemService } from '../../services/pr-line-item.service';

@Component({
  selector: 'app-pr-line-item-edit',
  templateUrl: './pr-line-item-edit.component.html',
  styleUrls: ['./pr-line-item-edit.component.css']
})
export class PrLineItemEditComponent implements OnInit {

  lineitem: PurchaseRequestLineItem | undefined;

  getItem(): void {
    this.route.queryParams.subscribe(
      params => {
        var id = params['id'];
        if (id) {
          this.lineitemService.get(id)
            .subscribe(resp => this.lineitem = resp);
        }
      }
    );
  }

  update(): void {
    if (this.lineitem) {
      this.lineitemService.update(this.lineitem).subscribe(resp => console.log(resp));
    }
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
