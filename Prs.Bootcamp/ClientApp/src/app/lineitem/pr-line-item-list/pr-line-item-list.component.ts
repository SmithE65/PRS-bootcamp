import { Component, OnInit } from '@angular/core';

import { PurchaseRequestLineItem } from '../../models/lineitem';

import { PrLineItemService } from '../../services/pr-line-item.service';

@Component({
  selector: 'app-pr-line-item-list',
  templateUrl: './pr-line-item-list.component.html',
  styleUrls: ['./pr-line-item-list.component.css']
})
export class PrLineItemListComponent implements OnInit {

  lineitems: PurchaseRequestLineItem[] = [];

  getItems(): void
  {
    this.lineitemService.list().subscribe(resp => this.lineitems = resp);
  }

  constructor(private lineitemService: PrLineItemService) { }

  ngOnInit() {
    this.getItems();
  }

}
