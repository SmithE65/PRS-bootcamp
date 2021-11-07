import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { Status } from '../../models/status';

import { StatusService } from '../../services/status.service';

@Component({
  selector: 'app-status-edit',
  templateUrl: './status-edit.component.html',
  styleUrls: ['./status-edit.component.css']
})
export class StatusEditComponent implements OnInit {

  status: Status | undefined;

  update(): void {
    if (this.status) {
      this.statusService.update(this.status).subscribe(resp => { console.log(resp); this.router.navigate(['/status']) });
    }
  }

  delete(): void {
    if (this.status) {
      this.statusService.delete(this.status.Id).subscribe(resp => { console.log(resp); this.router.navigate(['/status']) });
    }
  }

  getService(): void {
    this.route.queryParams.subscribe(
      (params) => {
        var id = params['id'];
        if (id) {
          this.statusService.get(id)
            .subscribe(resp => this.status = resp);
        }
      });
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
