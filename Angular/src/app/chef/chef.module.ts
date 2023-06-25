import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChefIndexComponent } from './chef-index/chef-index.component';
import { ChefProfileComponent } from './chef-profile/chef-profile.component';
import { ChefRoutingModule } from './chef-routing.module';
import { FormsModule } from '@angular/forms';
import { MenuModule } from '../menu/menu.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RatingComponent } from './chef-profile/rating-component/rating-component.component';
import { TopChefsComponent } from './top-chefs/top-chefs.component';
import { ChefOrdersComponent } from './chef-orders/chef-orders.component';
//import { RegisterPageComponent } from '../register-page/register-page.component';
@NgModule({
  declarations: [ChefProfileComponent, ChefIndexComponent,RatingComponent,
     TopChefsComponent, ChefOrdersComponent],
  imports: [CommonModule, ChefRoutingModule, FormsModule,
     MenuModule,BrowserAnimationsModule],
  exports: [ChefIndexComponent,TopChefsComponent],
})
export class ChefModule {}
