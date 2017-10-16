import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/switchMap';

import { Status } from '../../models/status';

import { StatusService } from '../../services/status.service';

@Component({
  selector: 'app-status-edit',
  templateUrl: './status-edit.component.html',
  styleUrls: ['./status-edit.component.css']
})
export class StatusEditComponent implements OnInit {

  status: Status;

  update(): void
  {
    this.statusService.update(this.status).then(resp => { console.log(resp); this.router.navigate(['/status']) });
  }

  delete(): void
  {
    this.statusService.delete(this.status.Id).then(resp => { console.log(resp); this.router.navigate(['/status']) });
  }

  getService(): void
  {
    this.route.paramMap.switchMap(
      (params: ParamMap) => this.statusService.get(params.get('id')))
      .subscribe(resp => this.status = resp);
  }

  constructor(
    private statusService: StatusService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getService();
  }

}
