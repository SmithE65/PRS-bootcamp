import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { PurchaseRequest } from '../../models/purchaserequest';
import { Status } from '../../models/status';

import { PurchaseRequestService } from '../../services/purchaserequest.service';
import { StatusService } from '../../services/status.service';
import { SystemService } from '../../services/system.service';

@Component({
  selector: 'app-purchaserequest-edit',
  templateUrl: './purchaserequest-edit.component.html',
  styleUrls: ['./purchaserequest-edit.component.css']
})
export class PurchaserequestEditComponent implements OnInit {

  request: PurchaseRequest | undefined;

  status: Status[] = [];

  getRequest(): void {
    this.route.queryParams.subscribe(params => {
      var id = params['id'];
      if (id) {
        this.prService.get(id).subscribe(resp => this.request = resp);
      }
    });
  }

  getStatus(): void {
    this.statusService.list().subscribe(resp => this.status = resp);
  }

  delete(): void {
    if (this.request) {
      this.prService.delete(this.request.Id).subscribe(resp => { console.log(resp); this.router.navigate(['/requests']) });
    }
  }

  update(): void {
    if (this.request) {
      this.prService.update(this.request).subscribe(resp => { console.log(resp); this.router.navigate(['/requests']) });
    }
  }

  constructor(
    private prService: PurchaseRequestService,
    private statusService: StatusService,
    private systemService: SystemService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getRequest();
    this.getStatus();
  }

}
