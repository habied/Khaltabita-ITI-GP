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
    private checkoutService: CheckoutService
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
  nMeal: Checkout = new Checkout();
  cartMenuItem: any = {};

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
      this.deleteItem(item);
    }
  }

  deleteItem(itemOrder: ItemOrder) {
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
  confirmOrder() {}
  openModal() {
    $('#myModal').modal('show');
  }

  AddOrder() {
    //Adding to cart table
    this.nMeal.userMobile = localStorage.getItem('id')!;
    this.nMeal.chefId = this.menuService.orders[0].menuItem.chefId;
    this.nMeal.location =
      this.AddressInfoForm.value.floor +
      ' ' +
      this.AddressInfoForm.value.AptNo +
      ' ' +
      this.AddressInfoForm.value.BuildingName +
      ' ' +
      this.AddressInfoForm.value.Street +
      ' ' +
      this.AddressInfoForm.value.City;
    this.nMeal.totalPrice = this.deliveryFee + this.subtotal;

    //Adding to cart menu item table
    this.checkoutService.addMeal(this.nMeal).subscribe(
      (arg) => {
        console.log(arg);
        $('#myModal').modal('hide');
        for (let i = 0; i < this.order.length; i++) {
          this.cartMenuItem.menuItemId = this.order[i].menuItem.id;
          this.cartMenuItem.cartId = arg;
          this.cartMenuItem.quantity = this.order[i].qty;
          this.cartMenuItem.totalItemPrice =
            this.order[i].qty * this.order[i].menuItem.unitPrice;
          this.checkoutService.addMealToCart(this.cartMenuItem).then((arg) => {
            console.log(arg);
          });
        }
      },
      (error: any) => {
        // Handle errors, if any
        console.error(error);
      },
      () => {
        console.log('Observable completed');
        this.order = [];
        this.subtotal = 0;
        this.menuService.itemsNumber$.next(0);
      }
    );
  }
  closeModal() {
    $('#myModal').modal('hide');
  }
}
