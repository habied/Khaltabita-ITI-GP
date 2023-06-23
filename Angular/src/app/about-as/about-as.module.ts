import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AboutAsRoutingModule } from './about-as-routing.module';
import { AboutAsComponentComponent } from './about-as-component/about-as-component.component';
import { ContactusComponent } from './contactus/contactus.component';


@NgModule({
  declarations: [
    AboutAsComponentComponent,
    ContactusComponent
  ],
  imports: [
    CommonModule,
    AboutAsRoutingModule
  ]
})
export class AboutAsModule { }
