import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { PostFormComponent } from './post-form/post-form.component';
import { DialogExampleComponent } from './order-confirmation-dialog/dialog-example.component';
import { BidProposalPageChefComponent } from './bid-proposal-chef-page/bid-proposal-page-chef.component';
import { BidProposalPageUserComponent } from './bid-proposal-user-page/bid-proposal-page-user.component';
import { ProposalDialogComponent } from './proposal-dialog/proposal-dialog.component';


@NgModule({
  declarations: [PostFormComponent, DialogExampleComponent,BidProposalPageChefComponent,BidProposalPageUserComponent, ProposalDialogComponent],
  imports: [
    CommonModule, FormsModule, RouterModule, ReactiveFormsModule
  ],
  entryComponents:[DialogExampleComponent],
  exports:[PostFormComponent,BidProposalPageChefComponent,BidProposalPageUserComponent]
})
export class BidModule { }
