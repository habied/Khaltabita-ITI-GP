import { Component, Input, OnInit } from '@angular/core';
import { CheckoutService } from '../services/checkout.service';
import { Checkout } from '../_models/checkout/checkout';
import { MenuService } from '../services/menu.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemOrder } from '../_models/menu/item-order';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  AddressInfoForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private menuService: MenuService,
    private checkoutService: CheckoutService,
  ) {}
  
  ngOnInit(): void {
    this.order = [...this.menuService.orders];
    this.calculateSubtotal();
    this.chefId = this.order[0]?.menuItem.chefId;
    
    this.AddressInfoForm = this.fb.group({
      BuildingName: [
        '',
        [Validators.required, Validators.pattern('[A-Za-zء-ي_ ,]{3,}')],
      ],
      AptNo: ['', [Validators.required, Validators.pattern('[0-9]*')]],
      floor: ['', [Validators.pattern('[0-9]*')]], //optional
      Street: [
        '',
        [Validators.required, Validators.pattern('[A-Za-zء-ي_ ,]{3,}')],
      ],
      City: [ 
        '',
        [Validators.required, Validators.pattern('[A-Za-zء-ي_ ,]{3,}')],
      ],
      phonenumber: [
        '',
        [
          Validators.required,
          Validators.pattern('^[0-9]*$'),
          Validators.minLength(11),
          Validators.maxLength(11),
        ],
      ],
      MobileHome: [
        '',
        [
          Validators.pattern('^[0-9]*$'),
          Validators.minLength(7),
          Validators.maxLength(7),
        ],
      ],
    });
  }
  order: ItemOrder[] = [];
  deliveryFee: number = 20;
  quantity: number = 1;
  subtotal: number = 0;
  chefId: string = '';
  finalOrder: Checkout | null = null;
  nMeal:Checkout=new Checkout();
  cartMenuItem:any={};

  increaseItemQuantity(menuItemIndex: number) {
    ++this.order[menuItemIndex].qty;
    this.menuService.itemsNumber$.next(this.order[menuItemIndex].qty);
    this.calculateSubtotal();
  }
  decreaseItemQuantity(menuItemIndex: number) {
    if (this.order[menuItemIndex].qty - 1 > 0) {
      --this.order[menuItemIndex].qty;
      this.menuService.itemsNumber$.next(this.order[menuItemIndex].qty);
      this.calculateSubtotal();
    }
  }
  deleteItem(){
    // let index = this.order.findIndex(item => item.id ==id);
    // if (index!=-1) {
    //   this.order.splice(index,1);
    // }
  }
  calculateSubtotal() {
    this.subtotal = 0;
    this.order.forEach((item) => {
      this.subtotal += item.qty * item.menuItem.unitPrice;
    });
  }
  confirmOrder() {}
  openModal() {
    $('#myModal').modal('show');
  }

  AddOrder(){
    //Adding to cart table
    this.nMeal.userMobile=localStorage.getItem("id")!;
    this.nMeal.chefId=this.menuService.orders[0].menuItem.chefId;
    this.nMeal.location=this.AddressInfoForm.value.floor +' '+this.AddressInfoForm.value.AptNo+ ' '+
    this.AddressInfoForm.value.BuildingName+' '+ this.AddressInfoForm.value.Street+' '+
    this.AddressInfoForm.value.City;
    this.nMeal.totalPrice=this.deliveryFee+this.subtotal;

    //Adding to cart menu item table

    console.log(this.nMeal);
    this.checkoutService.addMeal(this.nMeal)
      .subscribe(arg => {
        console.log(arg);
        $('#myModal').modal('hide');
    for(let i=0;i<this.order.length;i++){
      this.cartMenuItem.menuItemId=this.order[i].menuItem.id;
      this.cartMenuItem.cartId=arg;
      this.cartMenuItem.quantity=this.order[i].qty;
      this.cartMenuItem.totalItemPrice=this.order[i].qty * this.order[i].menuItem.unitPrice;
      this.checkoutService.addMealToCart(this.cartMenuItem).then(arg => {
        console.log(arg);})      
    }        
      });  
    
  }
  closeModal(){
    $('#myModal').modal('hide');
  }
}