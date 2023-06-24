import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Proposal } from 'src/app/_models/Post_Order_Item/Proposal';
import { PostOrder } from 'src/app/_models/Post_Order_Item/post-order';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-bid-proposal-page-chef',
  templateUrl: './bid-proposal-page-chef.component.html',
  styleUrls: ['./bid-proposal-page-chef.component.css'],
})
export class BidProposalPageChefComponent {

  Proposals:Proposal[]=[];
  Order:PostOrder | undefined;
  PostId:Number;
  LoggedChefID:string|undefined;

  constructor(public PostServices:PostService,public ac:ActivatedRoute){
    this.LoggedChefID=localStorage.getItem('id')!;
    this.PostId=this.ac.snapshot.params["id"];
    this.PostServices.GetPost(this.PostId).subscribe(response => {

      this.Order=new PostOrder(this.PostId,
                                response['postReadDto'].description,
                                response['postReadDto'].fromPrice,
                                response['postReadDto'].toPrice,
                                response['postReadDto'].prepTime,
                                response['postReadDto'].quantity,
                                response['postReadDto'].quantityUnit,
                                response['postReadDto'].userId,
                                response['postReadDto'].username,
                                response['postReadDto'].userAddress,
                                response['postReadDto'].date,
                                []
                                    );
      for (let i=0;i<response['proposalsDto'].length;i++){

        this.Order.Proposals.push(new Proposal (
          response['proposalsDto'][i].id,
          response['proposalsDto'][i].price,
          response['proposalsDto'][i].description,
          this.PostId,
          response['proposalsDto'][i].chefId,
          response['proposalsDto'][i].datePosted,
          response['proposalsDto'][i].chefName,
          response['proposalsDto'][i].chefRating,
          response['proposalsDto'][i].chefPhoto,
        ))
      }
      console.log('Response from server:', response)

    })
  }

  AddProposal(MinPrice:number,MaxPrice:number) {
    
    this.PostServices.OpenProposalDialog(MinPrice,MaxPrice,this.PostId);
  }
  DeleteProposal(ID:Number){
    this.PostServices.DeleteProposal(ID).subscribe(Response=>{
      location.reload();
      console.log(Response);
    })
  }
}
