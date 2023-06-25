import { Injectable, Input, OnChanges, SimpleChanges } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators
} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { PostOrder } from '../_models/Post_Order_Item/post-order';
import { DialogExampleComponent } from '../bid/order-confirmation-dialog/dialog-example.component';
import { ProposalDialogComponent } from '../bid/proposal-dialog/proposal-dialog.component';
import { Proposal } from '../_models/Post_Order_Item/Proposal';
import { PostAcceptedOrder } from '../_models/Post_Order_Item/post-accepted-order';
import { CustomizedValidators } from '../CustomizedValidators/Customized-validators';
import { ProposalPostDto } from '../_models/Post_Order_Item/ProposalPostDto';
import { AddPostDto } from '../_models/Post_Order_Item/AddPostDto';

@Injectable({
  providedIn: 'root',
})
export class PostService  {

  PostBaseUrl:string="https://localhost:7157/api/Post/";
  ProposalBaseUrl:string="https://localhost:7157/api/Proposal/";
  NewPostOrder: AddPostDto | undefined;
  AddedPostID:Number=-1;


  PostForm = new FormGroup({
    priceFrom: new FormControl("",[Validators.required,Validators.pattern('[0-9]*')]),
    priceTo: new FormControl("",[Validators.required,Validators.pattern('[0-9]*')]),
    OrderItem: new FormControl("",[Validators.required,Validators.pattern('[a-zA-Z\u0600-\u06FF\s]*')]),
    PrepTime: new FormControl("",[Validators.required,CustomizedValidators.futureDateValidator()]),
    // PrepTimeUnit: new FormControl("",[Validators.required]),
    Quantity: new FormControl("",[Validators.required,
      // Validators.pattern('[0-9]*')
    ]),
    QuantityUnit: new FormControl("",[Validators.required]),
    // ChooseFile: new FormControl('')
  });

  constructor(private dialog: MatDialog, private http:HttpClient, private router:Router) {
  }

  AddPostDetails(order: AddPostDto) {
    this.NewPostOrder=order;
    this.OpenOrderDialog();
  }

  GetPostOrder() {
    return this.NewPostOrder;
  }

  OpenOrderDialog() {
    this.dialog.open(DialogExampleComponent, { disableClose: true });
  }

  AddPost() {
    this.http.post<Number>(this.PostBaseUrl,this.NewPostOrder).subscribe(response => {
      console.log('Response from server:', response)
      this.AddedPostID=response;
      this.router.navigateByUrl(`specialorder/post/${response}`);});
  }

  OpenProposalDialog(MinPrice:number,MaxPrice:number,PostID:Number) {
    // ProposalDialogComponent.MinPrice=MinPrice;
    // ProposalDialogComponent.MinPrice=MaxPrice;
    ProposalDialogComponent.PostID=PostID;
    this.dialog.open(ProposalDialogComponent, { disableClose: true });
  }

  AddProposal(NewProposal:ProposalPostDto){
    this.http.post<number>(this.ProposalBaseUrl,NewProposal).subscribe(response => {
      // this.router.navigateByUrl(`specialorder/proposal/${ProposalDialogComponent.PostID}`);
      location.reload();
      console.log('Response from server:', response);});
  }

  GetPost(PostID:Number){
    return this.http.get<any>(`${this.PostBaseUrl}${PostID}`);
    };

    AddAcceptedOrder(AcceptedOrder:PostAcceptedOrder){
      return this.http.post<Number>(`${this.PostBaseUrl}AcceptedOrder`,AcceptedOrder);
    }

    GetAllPosts(){
      return this.http.get<any>(this.PostBaseUrl);
    }
    GetUserPosts(UserID:string){
      return this.http.get<any>(`${this.PostBaseUrl}UserPosts/${UserID}`);
    }
    DeleteProposal(ID:Number){
      return this.http.delete<any>(`${this.ProposalBaseUrl}${ID}`,);
    }
  }


