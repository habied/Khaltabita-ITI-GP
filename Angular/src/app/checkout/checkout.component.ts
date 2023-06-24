import { Component, Input, OnInit } from '@angular/core';
import { CheckoutService } from '../services/checkout.service';
import { Checkout } from '../_models/checkout/checkout';
import { MenuService } from '../services/menu.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemOrder } from '../_models/menu/item-order';
import { MatDialog } from '@angular/material/dialog';
import { PopupComponent } from './popup/popup.component';
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

    private popup: MatDialog
  ) {
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
  ngOnInit(): void {
    this.order = [...this.menuService.orders];
    this.calculateSubtotal();
    this.chefId = this.order[0]?.menuItem.chefId;
  }
  order: ItemOrder[] = [];
  deliveryFee: number = 20;
  quantity: number = 1;
  subtotal: number = 0;
  chefId: string = '';
  finalOrder: Checkout | null = null;
  increaseItemQuantity(menuItemIndex: number) {
    ++this.order[menuItemIndex].qty;
    this.menuService.itemsNumber$.next(this.menuService.itemsNumber$.value + 1);
    this.calculateSubtotal();
  }
  decreaseItemQuantity(menuItemIndex: number, item: ItemOrder) {
    if (this.order[menuItemIndex].qty - 1 > 0) {
      --this.order[menuItemIndex].qty;
      this.menuService.itemsNumber$.next(
        this.menuService.itemsNumber$.value - 1
      );
      this.calculateSubtotal();
    } else {
      this.removeFromCart(item);
    }
  }
  // removeFromCart(id){
  //   let index = this.order.findIndex(item => item.id ==id);
  //   if (index!=-1) {
  //     this.order.splice(index,1);
  //   }
  // }
  removeFromCart(itemOrder: ItemOrder) {
    // Find the index of the itemOrder in the orders array
    const index = this.menuService.orders.indexOf(itemOrder);

    // If the index is not -1 (i.e. itemOrder is in the orders array), remove the itemOrder from the orders array using splice()
    if (index !== -1) {
      this.menuService.orders.splice(index, 1);

      // Update the itemsNumber$ observable by subtracting the quantity of the removed itemOrder from the current value
      this.menuService.itemsNumber$.next(
        this.menuService.itemsNumber$.getValue() - itemOrder.qty
      );

      // Update the ordersList property to reflect the updated contents of the orders array
      this.order = this.menuService.orders.filter(
        (order) => order.menuItem.name !== itemOrder.menuItem.name
      );
    }
  }
  calculateSubtotal() {
    this.subtotal = 0;
    this.order.forEach((item) => {
      this.subtotal += item.qty * item.menuItem.unitPrice;
    });
  }
  //confirmOrder() {}

  openPopup() {
    this.popup.open(PopupComponent, {
      width: '400px',
    });
  }
}
