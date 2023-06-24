import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenService } from 'src/app/services/authen.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  isLoggedIn = false;
  isChef = false;

  isClient = false;
  chefId: any;
  constructor(
    private menuService: MenuService,

    private authService: AuthenService,
    private route: Router
  ) {}
  ngOnInit(): void {
    this.menuService.itemsNumber$.subscribe((itemsNumber) => {
      this.itemsNumber = itemsNumber;
    });
    this.checkIfUserLoggedIn();
    this.checkIfChefLoggedIn();
    this.checkIfClientLoggedIn();
    this.chefId = localStorage.getItem('id');
    this.authService.isAuth$.subscribe((value) => {
      this.isLoggedIn = value;
      this.menuService.itemsNumber$.next(0);
      this.menuService.orders = [];
    });
    this.authService.isChef$.subscribe((value) => (this.isChef = value));
    this.authService.isUser$.subscribe((value) => (this.isClient = value));
  }
  itemsNumber: number = 0;
  logout() {
    this.authService.logout();
    this.route.navigateByUrl('/home');
  }
  checkIfUserLoggedIn() {
    if (localStorage.getItem('token')) {
      this.authService.isAuth$.next(true);
    }
  }
  checkIfChefLoggedIn() {
    if (localStorage.getItem('title') == 'Chef') {
      this.authService.isChef$.next(true);
      this.chefId = localStorage.getItem('id');
    }
  }
  checkIfClientLoggedIn() {
    if (localStorage.getItem('title') == 'NormalUser') {
      this.authService.isUser$.next(true);
    }
  }
}
