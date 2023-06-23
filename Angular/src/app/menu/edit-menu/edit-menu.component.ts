import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuService } from 'src/app/services/menu.service';
import { MenueItem } from '../../_models/menu/MenueItem';
@Component({
  selector: 'app-edit-menu',
  templateUrl: './edit-menu.component.html',
  styleUrls: ['./edit-menu.component.css'],
})
export class EditMenuComponent implements OnInit {
  editMenuItemFrm!: FormGroup;
  item!: MenueItem;
  imageUrl="";
  // menuItems: MenueItem[] = [];
  constructor(
    private fb: FormBuilder,
    private ac: ActivatedRoute,
    private router: Router,
   
    private menuService: MenuService
  ) {}

  ngOnInit(): void {
    this.ac.params.subscribe((data) => {
      this.menuService.getItem(data['itemid']).subscribe((res) => {
        this.item = res;
        this.editMenuItemFrm = this.fb.group({
          id: this.item.id,
          name: [
            this.item.name,
            [Validators.required, Validators.pattern('[A-Za-zء-ي_ ,]{3,}')],
          ],
          media: this.item.media,
          description: [
            this.item.description,
            [Validators.pattern('[A-Za-zء-ي _ ,]{3,200}')],
          ],
          unitPrice: [this.item.unitPrice, [Validators.required]],
          prepTime: [
            this.item.prepTime,
            [Validators.required, Validators.min(30), Validators.max(300)],
          ],
          availability: this.item.availability,
          category: this.item.category,
        });
      });
    });
  }

  saveProduct() {
    console.log(this.editMenuItemFrm.value)
      // alert(this.editMenuItemFrm.controls["name"].value)
      console.log(this.editMenuItemFrm.value);
      this.menuService
        .editItem(this.editMenuItemFrm.value)
        .subscribe((res: any) => {
          this.item = { ...res };
          this.editMenuItemFrm = this.fb.group({
            id: this.item.id,
            name: [
              this.item.name,
              [Validators.required, Validators.pattern('[A-Za-zء-ي_ ,]{3,}')],
            ],
            media: this.item.media,
            description: [
              this.item.description,
              [Validators.pattern('[A-Za-zء-ي _ ,]{3,200}')],
            ],
            unitPrice: [this.item.unitPrice, [Validators.required]],
            prepTime: [
              this.item.prepTime,
              [Validators.required, Validators.min(30), Validators.max(300)],
            ],
            availability: this.item.availability,
            category: this.item.category,
          });
       
         });
  
   


         this.ac.params.subscribe((data) => {
         this.menuService.getItem(data['itemid']).subscribe((item) => {
        });
      });
          
    }


  deleteProduct() {
    this.editMenuItemFrm.reset();
    // this.router.navigate(['/menuitems']);
  }

  Back() {
    this.editMenuItemFrm.reset();
    this.router.navigate(['/menuitems']);
  }
}
