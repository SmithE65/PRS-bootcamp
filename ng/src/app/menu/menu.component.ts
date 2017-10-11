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

    name = "Menu Component"
    menusLeft: Menu[] = [
        new Menu('Home', '/home', 'Back to homepage.'),
        new Menu('About', '/about', 'About this page.')
    ];

    menusRight: Menu[] = [
    ];

  constructor(private systemService: SystemService) { }

  ngOnInit() {
      this.systemService.load();
  }

}
