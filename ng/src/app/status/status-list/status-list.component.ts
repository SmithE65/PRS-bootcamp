import { Component, OnInit } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { Status } from '../../models/status';

import { StatusService } from '../../services/status.service';

@Component({
  selector: 'app-status-list',
  templateUrl: './status-list.component.html',
  styleUrls: ['./status-list.component.css']
})
export class StatusListComponent implements OnInit {

  status: Status[];

  getStatus(): void
  {
    this.statusService.list().then(resp => this.status = resp);
  }

  constructor(private statusService: StatusService) { }

  ngOnInit() {
    this.getStatus();
  }

}
