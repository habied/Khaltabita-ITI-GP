import { formatDate } from '@angular/common';
import { Component, OnInit,OnChanges, SimpleChanges } from '@angular/core';
import { MatDialogClose, MatDialogRef } from '@angular/material/dialog';
import { AddPostDto } from 'src/app/_models/Post_Order_Item/AddPostDto';

import { PostOrder } from 'src/app/_models/Post_Order_Item/post-order';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-dialog-example',
  templateUrl: './dialog-example.component.html',
  styleUrls: ['./dialog-example.component.css']
})
export class DialogExampleComponent implements OnInit {

  PostOrder:AddPostDto | undefined;
  DeliveryDate:string|undefined;
  constructor(public PostServices:PostService, public dialogRef:MatDialogRef<DialogExampleComponent>){
  }
  ngOnInit(): void {
      this.PostOrder=this.PostServices.GetPostOrder();
      const f=Intl.DateTimeFormat("en-us",{dateStyle:'medium',timeStyle:'short'})
      this.DeliveryDate=f.format(this.PostOrder?.PrepTime);
      console.log(f.format(this.PostOrder?.PrepTime))

  }

  ConfirmPost(){
    this.PostServices.AddPost();
    this.PostServices.PostForm.reset();
    this.CloseDialog();
  }
  OpenDialog(){
    this.PostServices.OpenOrderDialog();
  }

  CloseDialog(){
    // this.PostServices.PostForm.reset();
    this.dialogRef.close();
  }
}
