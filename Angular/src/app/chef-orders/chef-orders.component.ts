import { Component , OnInit} from '@angular/core';
import {orders} from '../_models/Order/orders';
import { Router } from '@angular/router';
import { ChefOrdersService } from '../services/chef-orders.service';
@Component({
  selector: 'app-chef-orders',
  templateUrl: './chef-orders.component.html',
  styleUrls: ['./chef-orders.component.css']
})
export class ChefOrdersComponent implements OnInit {
  orders: any[] | undefined;

  constructor(private router: Router, private chefOrderService: ChefOrdersService) { }

  ngOnInit(): void {
    this.chefOrderService.getAll(localStorage.getItem('id')!).subscribe((response: any) => {
      this.orders = response;
      console.log(response);
    });
  }

  Done(): void {
    // Define the 'Done' function here
  }
}
