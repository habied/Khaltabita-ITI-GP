import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { BrowserModule } from '@angular/platform-browser';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuModule } from './menu/menu.module';
import { ChefModule } from './chef/chef.module';
import { BidModule } from './bid/bid.module';

import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';
import { ContentComponent } from './core/content/content.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { CheckoutComponent } from './checkout/checkout.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { PostsComponent } from './posts/posts.component';
//import { PasswordModule } from 'primeng/password';
import { ReactiveFormsModule } from "@angular/forms";
import { TokenInterceptor } from './Interceptor/TokenInterceptor';
import { PopupComponent } from './checkout/popup/popup.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { AboutUsComponent } from './core/about-us/about-us.component';
import { ContactUsComponent } from './core/contact-us/contact-us.component';
//import { ChefRegisterComponent } from './chef/chef-register/chef-register.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ContentComponent,
    LoginPageComponent,
    RegisterPageComponent,
    CheckoutComponent,
    PostsComponent,
    PopupComponent,
    UserOrdersComponent,
    AboutUsComponent,
    ContactUsComponent,
   // ChefRegisterComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    MenuModule,
    BidModule,
    BrowserAnimationsModule,
    MatDialogModule,
    HttpClientModule,
    ChefModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule
  ],
  
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
