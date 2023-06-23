import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SameChefGuard implements CanActivate {
  constructor(private router: Router) {}
  routeChefId: string = '';
  loggedInChefId: string | null = '';
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    this.routeChefId = route.params['chefid'];
    this.loggedInChefId = localStorage.getItem('id');
    if (this.routeChefId == this.loggedInChefId) return true;
    this.router.navigateByUrl('/home');
    return false;
  }
}
