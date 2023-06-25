import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { MenuService } from 'src/app/services/menu.service';
import { ImageService } from 'src/app/services/image.service';
import { MenueItem } from '../../_models/menu/MenueItem';

@Component({
  selector: 'app-add-menu',
  templateUrl: './add-menu.component.html',
  styleUrls: ['./add-menu.component.css'],
})
export class AddMenuComponent implements OnInit {
  imageUrl = '';
  addMenuItemFrm: FormGroup;
  menuItems: MenueItem[] = [];

  item!: MenueItem;
  currentChefId: string = '';
  //item: MenueItem = new MenueItem();
  constructor(
    private fb: FormBuilder,
    public menuService: MenuService,
    private imgService: ImageService,
    private activateRoute: ActivatedRoute,
    private router: Router
  ) {
    this.addMenuItemFrm = this.fb.group({
      chefId: '',
      name: [
        '',
        [Validators.required, Validators.pattern('[A-Za-zء-ي_ , ، ]{3,}')],
      ],
      description: ['', [Validators.pattern('[A-Za-zء-ي _ , ، ]{3,200}')]],
      unitPrice: [
        '10',
        [Validators.required, Validators.min(10), Validators.max(5000)],
      ],
      prepTime: ['', [Validators.min(0), Validators.max(300)]],
      category: ['', [Validators.required]],
      availability: '',
      media: '',
    });
  }

  ngOnInit(): void {
    //chefId = localStorage.getItem('chefId');
    //this.currentChefId=Number(this.activateRoute.snapshot.paramMap.get('chefId'));
    this.activateRoute.params.subscribe((params) => {
      this.currentChefId = params['chefid'];
    });

    //  this.activateRoute.params
    //  .subscribe(
    //    (params:Params) => {
    //      this.currentChefId = +params['chefId'];
    //      console.log(this.currentChefId);

    //    }
    //  );
  }

  public uploadPhoto(e: Event) {
    const input = e.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) return;

    this.imgService.upload(file).subscribe((response) => {
      this.imageUrl = response.url;
      this.addMenuItemFrm.patchValue({ media: this.imageUrl });
      // console.log(response);
    });
  }

  addItem(e: Event) {
    e.preventDefault();

    console.log(this.addMenuItemFrm.value);
    this.item = {
      ...this.addMenuItemFrm.value,
      //  chefId: 1
      chefId: this.currentChefId,
    };
    this.menuService.addItem(this.item).subscribe((res) => {
      console.log('your item has been added Successfully');
      this.router.navigate(['/menu']);
    });
  }
  resetForm() {
    this.addMenuItemFrm.reset();
  }

  onBack(): void {
    this.addMenuItemFrm.reset();
    this.router.navigate(['/menu']);
  }

  get name() {
    return this.addMenuItemFrm.get('name');
  }

  get description() {
    return this.addMenuItemFrm.get('description');
  }

  get unitPrice() {
    return this.addMenuItemFrm.get('unitPrice');
  }

  get prepTime() {
    return this.addMenuItemFrm.get('prepTime');
  }
}
