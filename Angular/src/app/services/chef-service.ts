import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Chef } from '../_models/chef/chef';
import { FeedBack } from '../_models/feedback/feedback';

@Injectable({
  providedIn: 'root'
})
export class ChefService {
  baseurl:string="https://localhost:7157/api/Chefs/"
  
  getAll(){
    return this.http.get<Chef[]>(this.baseurl)
  }
  getTop10Chefs(){
    return this.http.get<Chef[]>(`${this.baseurl}TopChefs`)
  }
  getChef(id:string)
  {
    return this.http.get<Chef>(this.baseurl+id)
  }
  updateChef(Chf:Chef){
    return this.http.put<Chef>(this.baseurl+Chf.chefId,Chf)
  }
  deleteChf(id:string){
    return this.http.delete(this.baseurl+id);
  }
  getAllchefFeedbacks(id:string){
    return this.http.get<FeedBack[]>(`${this.baseurl}feedback?id=${id}`);
  }
  addFeedback(feed:FeedBack){
    return this.http.post<FeedBack>(`${this.baseurl}feedback`,feed);
  }
  constructor(public http:HttpClient) { }
}