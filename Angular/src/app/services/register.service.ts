import { RegisterDTO } from '../_models/Auth/RegisterDTO';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterChefDto } from '../_models/Auth/RegisterChefDto';
@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  //constructor(private http: HttpClient) { }

  registerUser(user: RegisterDTO) {
    return this.http.post('https://localhost:7157/User/register', user);
  }

  registerChef(chef: RegisterChefDto) {
    return this.http.post('https://localhost:7157/chef/register', chef);
  } 

  getTheLinkOfRegisterChefImage(file :FormData)
  {
    return this.http.post('https://localhost:7157/api/Files', file);
  }
  constructor(public http:HttpClient) { }
}

