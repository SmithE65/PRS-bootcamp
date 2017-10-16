import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { LineItem } from '../../models/lineitem';

@Component({
  selector: 'app-pr-line-item-list',
  templateUrl: './pr-line-item-list.component.html',
  styleUrls: ['./pr-line-item-list.component.css']
})
export class PrLineItemListComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
