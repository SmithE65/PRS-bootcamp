import { Component, OnInit } from '@angular/core';

import { SystemService } from '../services/system.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public sysService: SystemService) { }

  ngOnInit() {
  }

}
