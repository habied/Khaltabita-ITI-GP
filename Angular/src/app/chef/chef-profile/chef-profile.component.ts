import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Chef } from 'src/app/_models/chef/chef';
import { FeedBack } from 'src/app/_models/feedback/feedback';
import { AuthenService } from 'src/app/services/authen.service';
import { ChefService } from 'src/app/services/chef-service';

@Component({
  selector: 'app-chef-profile',
  templateUrl: './chef-profile.component.html',
  styleUrls: ['./chef-profile.component.css'],
})

export class ChefProfileComponent implements OnDestroy,OnInit{

  currentIndex = 0;
  ChfInfo:Chef|null=null;
  Cheffeedbks:FeedBack[]=[];
  chfId:string="";
  chefRatingValue: number=4;
  userReviewonChef: FeedBack=new FeedBack();
  isUser=false;
  sub:Subscription|null=null;
  textInput:string="";

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
  constructor(
    private chfSer:ChefService,
    private ac:ActivatedRoute,
    private authService: AuthenService
    ){}
    
  ngOnInit(){
    window.scrollTo(0, 0);
    this.authService.isUser$.subscribe((value)=>(this.isUser=value));
    this.intializeVariables();  
  }
  intializeVariables(){
    this.userReviewonChef.userid=localStorage.getItem('id')!;
    this.sub= this.ac.params.subscribe(data=>{
      this.chfSer.getChef(data['id']).subscribe(r=>{
         this.ChfInfo=r;
         this.chfId=this.ac.snapshot.params['id'];
         this.chefRatingValue=(this.ChfInfo?.chefRating)!*15;
         this.chfSer.getAllchefFeedbacks(this.chfId).subscribe(feeds=>{
           this.Cheffeedbks=feeds;
         });
         this.userReviewonChef.chefId=this.chfId;
      })
      },); 
  }
  saveReview()
  {   
      this.userReviewonChef.review=this.textInput;
      this.chfSer.addFeedback(this.userReviewonChef).subscribe((a: any)=>{
        console.log(a);
      location.reload();
      },(er: string)=>{

        console.log("Error"+er);
        this.textInput="You already gave a review today!!";  

      });  
  }
}
