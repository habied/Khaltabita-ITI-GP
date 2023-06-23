import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SimplestDialogComponent } from './simplest-dialog/simplest-dialog.component';



@NgModule({
  declarations: [
    SimplestDialogComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    SimplestDialogComponent
  ]
})
export class DialogsModule { }
