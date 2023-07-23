import { Component,OnChanges,OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Proposal } from 'src/app/_models/Post_Order_Item/Proposal';
import { PostAcceptedOrder } from 'src/app/_models/Post_Order_Item/post-accepted-order';
import { PostOrder } from 'src/app/_models/Post_Order_Item/post-order';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-bid-proposal-page-user',
  templateUrl: './bid-proposal-page-user.component.html',
  styleUrls: ['./bid-proposal-page-user.component.css']
})
export class BidProposalPageUserComponent {

  Order:PostOrder | undefined;
  PostId:Number;
  UserId:string | undefined;
  AcceptedOrder:PostAcceptedOrder | undefined;
  DeliveryDate:string|undefined;
  f=Intl.DateTimeFormat("en-us",{dateStyle:'medium',timeStyle:'short'})


  constructor(public PostServices:PostService, public ac:ActivatedRoute, public router:Router){
    this.PostId=this.ac.snapshot.params["id"];
    this.UserId=localStorage.getItem("id")!;
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
    this.DeliveryDate=this.f.format(response['postReadDto'].prepTime);
    console.log('Response from server:', response)


  })}

  AcceptProposal(Proposal:Proposal){
    this.AcceptedOrder=new PostAcceptedOrder(
                                              this.Order?.Description,
                                              Proposal.Price,
                                              this.Order?.QuantityUnit,
                                              this.Order?.Quantity,
                                              this.Order?.PrepTime!,
                                              Proposal.Description,
                                              this.Order?.PostID,
                                              Proposal.Id,
                                              Proposal.ChefId,
                                              this.UserId)
    console.log(this.AcceptedOrder);
    this.PostServices.AddAcceptedOrder(this.AcceptedOrder).subscribe(OrderId=>console.log(OrderId));
    this.router.navigateByUrl(`home`);
  }
}
