import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MenueItem } from 'src/app/_models/menu/MenueItem';
import { AuthenService } from 'src/app/services/authen.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-menu-details',
  templateUrl: './menu-details.component.html',
  styleUrls: ['./menu-details.component.css'],
})
export class MenuDetailsComponent implements OnInit {
  constructor(
    private router: Router,
    public menuService: MenuService,
    private route: ActivatedRoute,
    private authService: AuthenService
  ) {
    this.inputValue = '';
  }
  ngOnInit(): void {
    myfun(false);
    //checking if there's logged in user
    if (localStorage.getItem('id')) {
      this.userId = localStorage.getItem('id');
    }
    //checking for chef role
    this.authService.isChef$.subscribe((value) => {
      if (value) {
        this.userRole = 'Chef';
      }
    });
    //check if chef profile or all menu items
    this.route.params.subscribe((params) => {
      this.routeChefId = params['id'];
      if (this.routeChefId) {
        this.menuService
          .getChefItems(this.routeChefId)
          .subscribe((menuItems) => {
            this.menuItems = menuItems;
            this.menuItems.forEach((item) =>
              this.viewedMenuItems.push({ ...item })
            );
            myfun(true);
          });
        //load liked chef items by user
        if (this.userRole != 'Chef' && this.userId) {
          this.menuService
            .getLikedChefMenuItemsByUser(this.userId, this.routeChefId)
            .subscribe((likedItemsIds) => {
              this.likedItemsIds = likedItemsIds;
            });
        }
      } else {
        this.menuService.getAll().subscribe((menuItems) => {
          this.menuItems = menuItems;
          this.menuItems.forEach((item) =>
            this.viewedMenuItems.push({ ...item })
          );
          this.viewedMenuItems = menuItems;
          myfun(true);
        });
      }
    });
  }
  menuItems: MenueItem[] = [];
  viewedMenuItems: MenueItem[] = [];
  routeChefId: string | null = null;
  userId: string | null = null;
  likeButtonColor: string = 'var(--dark)';
  likedItemsIds: number[] = [];
  inputValue = '';
  categories = [
    { text: 'breakfast', icon: 'fa-coffee', description: 'Popular' },
    { text: 'dinner', icon: 'fa-hamburger', description: 'Special' },
    { text: 'lunch', icon: 'fa-utensils', description: 'Lovely' },
  ];
  userRole: string = '';
  deletedItem: MenueItem | null = null;
  isSameChef() {
    return this.userId == this.routeChefId;
  }
  openModal(event: Event, item: MenueItem) {
    event.stopPropagation();
    this.deletedItem = item;
    $('#myModal').modal('show');
  }
  deleteItem() {
    if (this.deletedItem) {
      this.menuService.deleteItem(this.deletedItem.id).subscribe(() => {
        $('#myModal').modal('hide');
        this.menuItems = this.menuItems.filter(
          (item) => item.id !== this.deletedItem?.id
        );
      });
    }
  }
  goToItem(routeChefId: string, itemId: number) {
    this.router.navigate([`/menu/${routeChefId}/${itemId}`]);
  }
  addLike(event: Event, itemId: number) {
    event.stopPropagation();
    let isLiked = this.likedItemsIds.some((id) => id == itemId);
    if (this.userId && isLiked) {
      this.menuService
        .deleteItemLikeByUser(this.userId, itemId)
        .subscribe(() => {
          const itemIdIndex = this.likedItemsIds.findIndex(
            (id) => id == itemId
          );
          this.likedItemsIds.splice(itemIdIndex, 1);
          this.menuItems.find((item) => item.id == itemId)!.likes -= 1;
          this.viewedMenuItems.find((item) => item.id == itemId)!.likes -= 1;
        });
    }
    if (this.userId && !isLiked) {
      this.menuService
        .addLikeToChefByUser(this.userId, itemId)
        .subscribe(() => {
          this.likedItemsIds.push(itemId);
          this.menuItems.find((item) => item.id == itemId)!.likes += 1;
          this.viewedMenuItems.find((item) => item.id == itemId)!.likes += 1;
        });
    }
  }
  isLiked(menuItemId: number) {
    return this.likedItemsIds.some((id) => id == menuItemId);
  }
  filterItems(value: string) {
    console.log(value);
    //this.inputValue = event.target.value;
    if (value != '') {
      this.viewedMenuItems = this.menuItems.filter((item) => {
        return item.name.includes(value);
      });
    } else {
      this.menuItems.forEach((item) => this.viewedMenuItems.push({ ...item }));
    }
  }
}
