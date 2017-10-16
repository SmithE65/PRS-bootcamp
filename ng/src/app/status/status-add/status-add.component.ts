import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { Status } from '../../models/status';

import { StatusService } from '../../services/status.service';

@Component({
  selector: 'app-status-add',
  templateUrl: './status-add.component.html',
  styleUrls: ['./status-add.component.css']
})
export class StatusAddComponent implements OnInit {

  status: Status = new Status(0,'');

  add(): void
  {
    this.statusService.add(this.status).then(resp => { console.log(resp); this.router.navigate(['/status']) });
  }

  constructor(
    private statusService: StatusService,
    private router: Router
  ) { }

  ngOnInit() {
  }

}
