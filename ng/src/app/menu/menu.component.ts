import { Component, OnInit } from '@angular/core';

import { SystemService } from '../services/system.service';

import { User } from '../models/user';

import { Menu } from './menu';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  name = "Menu Component";

  constructor(private systemService: SystemService) { }

  ngOnInit() {
      this.systemService.load();
  }

}
