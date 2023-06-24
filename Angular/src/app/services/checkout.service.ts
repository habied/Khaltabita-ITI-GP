import { Injectable } from '@angular/core';
import { Checkout } from '../_models/checkout/checkout';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseurl:string="https://localhost:7157/api/Carts/"

  addMeal(meal:Checkout){
    return this.http.post<number>(this.baseurl,meal);
  }
  async addMealToCart(object:any){
    await this.http.post<void>(`${this.baseurl}Menu`,object).toPromise();
  }
  
  constructor(public http: HttpClient) { }
}
