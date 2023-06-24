import { Component, OnInit, OnDestroy } from '@angular/core';
import { PostService } from '../services/post.service';
import { PostOrder } from '../_models/Post_Order_Item/post-order';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit, OnDestroy{

  posts: PostOrder []|undefined;
  sub: Subscription | null = null;
  response:any;

  constructor(public PostServices: PostService,public router:Router) {
}

ngOnInit(): void {

  if(localStorage.getItem('title')=='NormalUser'){
  this.sub=this.PostServices.GetUserPosts(localStorage.getItem('id')!).subscribe(response =>{
    this.response=response;
    console.log(response);})}
else{
  this.sub=this.PostServices.GetAllPosts().subscribe(response =>{
    this.response=response;
    console.log(response);
  })

}
  }

  ViewPost(postid:Number){
    if(localStorage.getItem('title')=='NormalUser'){
    this.router.navigateByUrl(`specialorder/post/${postid}`);
    }
    else{
      this.router.navigateByUrl(`specialorder/proposal/${postid}`);
    }
  }

ngOnDestroy(): void {
  this.sub?.unsubscribe();
}
}
