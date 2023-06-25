import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { MenuDetailsComponent } from './menu-details/menu-details.component';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { EditMenuComponent } from './edit-menu/edit-menu.component';
import { AddMenuComponent } from './add-menu/add-menu.component';
import { ChefGuard } from '../Guards/chef.guard';
import { SameChefGuard } from '../Guards/same-chef.guard';
import { UserGuard } from '../Guards/user.guard';
const routes: Routes = [
  { path: '', component: MenuDetailsComponent },
  { path: ':chefid', component: MenuDetailsComponent },
  {
    path: 'edititem/:itemid/:chefid',
    component: EditMenuComponent,
    canActivate: [ChefGuard, SameChefGuard],
  },
  {
    path: 'additem/:chefid',
    component: AddMenuComponent,
    canActivate: [ChefGuard, SameChefGuard],
  },
  {
    path: ':chefid/:itemid',
    component: MenuItemComponent,
    canActivate: [UserGuard],
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MenuRoutingModule {}
