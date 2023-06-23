import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { MenueItem } from 'src/app/_models/menu/MenueItem';
import { ItemOrder } from 'src/app/_models/menu/item-order';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.css'],
})
export class MenuItemComponent implements OnInit {
  constructor(
    private menuService: MenuService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit() {
    myfun(false);
    this.route.params.subscribe((params) => {
      const chefId = params['chefid'];
      this.chefId = chefId;
      const itemId = params['itemid'];
      this.menuService.getItem(itemId).subscribe((item) => {
        this.menuItem = item;
        this.totalPrice = item.unitPrice;
        myfun(true);
      });
    });
  }
  menuItem: MenueItem | null = null;
  qty: number = 1;
  orders: ItemOrder[] = [];
  availableAmount: number = 10;
  totalPrice: any;
  chefId: any;
  addOne() {
    if (this.qty + 1 <= this.availableAmount && this.menuItem) {
      this.qty++;
      this.totalPrice = this.menuItem.unitPrice * this.qty;
    }
  }
  removeOne() {
    if (this.qty - 1 >= 1 && this.menuItem) {
      this.qty--;
      this.totalPrice = this.menuItem.unitPrice * this.qty;
    }
  }
  addToCart() {
    if (this.menuItem && this.qty) {
      let inCart = false;
      this.menuService.orders.forEach((order) => {
        if (order.menuItem.name == this.menuItem?.name) {
          order.qty += this.qty;
          inCart = true;
        }
      });
      if (
        this.menuService.orders.length > 0 &&
        this.menuService.orders[0].menuItem.chefId !== this.menuItem.chefId
      ) {
        this.menuService.orders = [];
        this.menuService.itemsNumber$.next(0);
      }
      if (!inCart) {
        this.menuService.orders = [
          ...this.menuService.orders,
          new ItemOrder(this.menuItem, this.qty),
        ];
        this.menuService.itemsNumber$.next(
          this.menuService.itemsNumber$.getValue() + this.qty
        );
        this.router.navigate([`/chefs/${this.chefId}`]);
      }
    }
  }
}
