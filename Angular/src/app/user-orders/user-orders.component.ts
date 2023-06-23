import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Chef } from 'src/app/_models/chef/chef';
import { Client } from 'src/app/_models/client/client';
import { MenueItem } from 'src/app/_models/menu/MenueItem';
import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit{
  constructor(
    private router: Router,
    public menuService: MenuService,
    private authService: AuthService,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    
  }
}
