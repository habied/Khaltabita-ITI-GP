import { Injectable } from '@angular/core';
import { orders } from '../_models/Order/orders';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChefOrdersService {
  baseurl:string="https://localhost:7157/api/Order/"
  getAll(id:string){
    return this.http.get<orders[]>(this.baseurl+id)
  }
  
  delete(id:string){ //could be id of the cart 
    return this.http.delete(this.baseurl+id);
  }
 
  constructor(public http:HttpClient) { }
}
