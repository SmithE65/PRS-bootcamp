// core angular
import { Component, OnInit } from '@angular/core';

// services
import { SystemService } from '../services/system.service';
import { ShoppingCartService } from '../services/shopping-cart.service';

// models
import { User } from '../models/user';

// menu item model
import { Menu } from './menu';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  name = "Menu Component";

  // inject services
  constructor(
    private cartService: ShoppingCartService,
    private systemService: SystemService
  ) { }

  ngOnInit() {
      this.systemService.load();
  }

}
