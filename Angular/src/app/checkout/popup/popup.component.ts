import { Component } from '@angular/core';
import { Checkout } from 'src/app/_models/checkout/checkout';
import { CheckoutService } from 'src/app/services/checkout.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent{
  nMeal:Checkout=new Checkout();
  constructor(private checkoutService: CheckoutService, private router:Router){

  }
  
  AddOrder(){
    this.checkoutService.addMeal(this.nMeal)
      .subscribe(arg => {
        console.log(arg);
        this.router.navigate(['/user-orders']);
      });
    
  }
}
