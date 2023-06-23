import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { MenueItem } from '../_models/menu/MenueItem';
import { ItemOrder } from '../_models/menu/item-order';
import { BehaviorSubject, Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class MenuService {
  constructor(public http: HttpClient) {}
  // addToCart$ = new BehaviorSubject<ItemOrder[] | null>(null);
  orders: ItemOrder[] = [];
  itemsNumber$ = new BehaviorSubject<number>(0);
  baseUrl: string = environment.apiUrl + '/MenuItem';
  getChefItems(chefId: string) {
    return this.http.get<MenueItem[]>(`${this.baseUrl}/ChefItems/${chefId}`);
  }
  getAll() {
    return this.http.get<MenueItem[]>(`${this.baseUrl}`);
  }
  getItem(itemId: number) {
    return this.http.get<MenueItem>(`${this.baseUrl}/${itemId}`);
  }
  addItem(item: MenueItem) {
    return this.http.post(`${this.baseUrl}`, item);
  }
  editItem(item: MenueItem) {
    return this.http.put(`${this.baseUrl}`, item);
  }
  deleteItem(itemId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}?id=${itemId}`);
  }
  getLikedChefMenuItemsByUser(userId: string, chefId: string) {
    return this.http.get<number[]>(
      `${this.baseUrl}/GetLikes/${userId}/${chefId}`
    );
  }
  addLikeToChefByUser(userId: string, menuItemId: number) {
    return this.http.get(`${this.baseUrl}/AddLike/${userId}/${menuItemId}`);
  }
  deleteItemLikeByUser(userId: string, menuItemId: number) {
    return this.http.delete(
      `${this.baseUrl}/DeleteLike/${userId}/${menuItemId}`
    );
  }
}
