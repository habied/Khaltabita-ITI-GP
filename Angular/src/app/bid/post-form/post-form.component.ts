import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup, FormControl, FormBuilder,Validators } from '@angular/forms';
import { AddPostDto } from 'src/app/_models/Post_Order_Item/AddPostDto';

import { PostOrder } from 'src/app/_models/Post_Order_Item/post-order';
import { PostService } from 'src/app/services/post.service';


@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css']
})

export class PostFormComponent implements OnInit{

  PostItem:AddPostDto|undefined;
  PostForm:FormGroup=new FormGroup({});

  constructor( public PostItemServices: PostService) {}

  ngOnInit(): void {
    this.PostForm=this.PostItemServices.PostForm;
  }


AddItem(): void{
    this.PostItem=new AddPostDto(
    this.PostForm.value.OrderItem,
    this.PostForm.value.priceFrom,
    this.PostForm.value.priceTo,
    new Date(this.PostForm.value.PrepTime),
    this.PostForm.value.Quantity,
    this.PostForm.value.QuantityUnit,
    localStorage.getItem('id')!,
      )
    
    this.PostItemServices.AddPostDetails(this.PostItem);
  }

  // getMinutesSinceDate(date: Date): number {
  //   const Ndate = new Date(date);
  //   const diffInMs = Ndate.getTime()-Date.now();
  //   const diffInMinutes = Math.floor(diffInMs / 1000 / 60);
  //   return diffInMinutes;
  // }
}





