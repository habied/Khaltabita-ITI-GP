import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChefIndexComponent } from './chef-index/chef-index.component';
import { ChefProfileComponent } from './chef-profile/chef-profile.component';
import { ChefOrdersComponent } from './chef-orders/chef-orders.component';


const routes: Routes = [
  { path: '', component: ChefIndexComponent },
  { path: ':id', component: ChefProfileComponent },
];

@NgModule({
  declarations: [
    
  ],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChefRoutingModule {}
