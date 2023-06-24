import { Component } from '@angular/core';
import {orders} from '../_models/Order/orders';
import { Router } from '@angular/router';
@Component({
  selector: 'app-chef-orders',
  templateUrl: './chef-orders.component.html',
  styleUrls: ['./chef-orders.component.css']
})
export class ChefOrdersComponent {
  Order: orders= new orders ('','','','','','','','') ;
 number = 5 ;
 constructor(private route: Router){}
  Done(){

  }
}
