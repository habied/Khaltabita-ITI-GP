import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadFileDto } from '../_models/Images/UploadFileDto';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  constructor
  (private client:HttpClient) {}
    
 public upload(file:File):Observable<UploadFileDto>
 {
  var form =new FormData();
  form.append('file',file);

  return this.client.post<UploadFileDto>
  ( 'https://localhost:7157/api/Files',form);

  }
}
