import { Component, OnInit } from '@angular/core';

import { Menu } from './menu';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

    name = "Menu Component"
    menus: Menu[] = [
        new Menu('Home', '/home', 'Back to homepage.'),
        new Menu('Login', '/login', 'Login; duh')
    ];

  constructor() { }

  ngOnInit() {
  }

}
