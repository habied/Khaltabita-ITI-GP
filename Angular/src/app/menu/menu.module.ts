import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuDetailsComponent } from './menu-details/menu-details.component';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { MenuRoutingModule } from './menu-routing-module';
import { AddMenuComponent } from './add-menu/add-menu.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditMenuComponent } from './edit-menu/edit-menu.component';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    MenuDetailsComponent,
    MenuItemComponent,
    AddMenuComponent,
    EditMenuComponent,
  ],
  imports: [CommonModule, MenuRoutingModule, ReactiveFormsModule, FormsModule],
  exports: [MenuDetailsComponent, AddMenuComponent, EditMenuComponent],
})
export class MenuModule {}
