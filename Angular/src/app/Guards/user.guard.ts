import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenService } from '../services/authen.service';

@Injectable({
  providedIn: 'root'
})
export class UserGuard implements CanActivate {
constructor(private authService: AuthenService, private router: Router) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree 
  {
    if (this.authService.isUser$.value) {
      return true;
    }

    //navigate to login
    this.router.navigateByUrl('/login');
    return false;
  }
  
}
