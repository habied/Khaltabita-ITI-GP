import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { LoginDTO } from '../_models/Auth/LoginDTO';
import { TokenDTO } from '../_models/Auth/TokenDTO';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthenService {
  public isAuth$ = new BehaviorSubject<boolean>(false);
  public isChef$ = new BehaviorSubject<boolean>(false);
  public isUser$ = new BehaviorSubject<boolean>(false);
  
  constructor(private user: HttpClient) {}

  public login(credentials: LoginDTO): Observable<TokenDTO> {
    return this.user
      .post<TokenDTO>('https://localhost:7157/api/AuthUser/login', credentials)
      .pipe(
        tap((tokenDto) => {
          localStorage.setItem('token', tokenDto.token);
          localStorage.setItem('title', tokenDto.title);
          localStorage.setItem('id', tokenDto.id);
          this.isAuth$.next(true);
          if(tokenDto.title=='Chef'){this.isChef$.next(true)}
          if(tokenDto.title=='NormalUser'){this.isUser$.next(true)}
        }),
        tap({
          error: () => {
            alert('Wrong email or password');
          }
        })
      ); 
  }

  public logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('title');
    localStorage.removeItem('id');
    console.log("removed");
    this.isAuth$.next(false);
    this.isChef$.next(false);
  }
}
