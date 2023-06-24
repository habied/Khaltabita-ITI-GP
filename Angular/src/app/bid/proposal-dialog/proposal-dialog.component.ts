import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Proposal } from 'src/app/_models/Post_Order_Item/Proposal';
import { ProposalPostDto } from 'src/app/_models/Post_Order_Item/ProposalPostDto';
import {CustomizedValidators} from 'src/app/CustomizedValidators/Customized-validators';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-proposal-dialog',
  templateUrl: './proposal-dialog.component.html',
  styleUrls: ['./proposal-dialog.component.css'],
})

export class ProposalDialogComponent {

  NewProposal:ProposalPostDto | undefined;
  static PostID:Number | undefined;
  ChefId:string | undefined;
  static MinPrice:number=0;
  static MaxPrice:number=Infinity;
  ProposalForm: FormGroup = new FormGroup({TotalPrice: new FormControl("",[Validators.required,Validators.pattern('[0-9]*')]),
    // DeliveryTime: new FormControl("",[Validators.required,CustomizedValidators.futureDateValidator()]),
    AdditionalInfo: new FormControl(),
    // ChooseImg: new FormControl()
  });

  constructor(
    public PostService: PostService,
    public ProposalDialogRef: MatDialogRef<ProposalDialogComponent>,
    public ac:ActivatedRoute,
    public router:Router
  ) {
    this.ChefId=localStorage.getItem("id")!;
  }


  AddProposal() {
      console.log(ProposalDialogComponent.PostID);
      this.NewProposal=new ProposalPostDto(
        this.ProposalForm.value.TotalPrice,
        this.ProposalForm.value.AdditionalInfo,
        ProposalDialogComponent.PostID!,
        this.ChefId!)
      this.PostService.AddProposal(this.NewProposal);
      this.CloseDialog();
  }
  CloseDialog() {
    this.ProposalDialogRef.close();
  }
}
