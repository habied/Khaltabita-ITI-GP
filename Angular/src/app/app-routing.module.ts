import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from './core/content/content.component';
import { BidProposalPageUserComponent } from './bid/bid-proposal-user-page/bid-proposal-page-user.component';
import { BidProposalPageChefComponent } from './bid/bid-proposal-chef-page/bid-proposal-page-chef.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { PostFormComponent } from './bid/post-form/post-form.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { ChefIndexComponent } from './chef/chef-index/chef-index.component';
import { ChefProfileComponent } from './chef/chef-profile/chef-profile.component';
import { PostsComponent } from './posts/posts.component';
import { ChefOrdersComponent } from './chef/chef-orders/chef-orders.component';
import { ChefGuard } from './Guards/chef.guard';
import { UserGuard } from './Guards/user.guard';
import { AboutUsComponent } from './core/about-us/about-us.component';
import { ContactUsComponent } from './core/contact-us/contact-us.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: ContentComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'cart', component: CheckoutComponent },  //, canActivate: [UserGuard]
  { path: 'specialorder', component: PostFormComponent,canActivate: [UserGuard] },
  { path: 'login/register', component: RegisterPageComponent },
  { path: 'login/Be_a_chef', component: RegisterPageComponent },
  { path: 'AboutUS', component: AboutUsComponent },
  { path: 'ContactUs', component: ContactUsComponent },
  { path: 'chefs', component: ChefIndexComponent, pathMatch: 'full' },
  { path: 'chefs/myorders', component: ChefOrdersComponent },  //, canActivate: [ChefGuard]
  { path: 'chefs/:id', component: ChefProfileComponent, pathMatch: 'full' },
  // {
  //   path: 'chefs',
  //   loadChildren: () => import('./chef/chef.module').then((m) => m.ChefModule),
  // },
  {
    path: 'menu',
    loadChildren: () => import('./menu/menu.module').then((m) => m.MenuModule),
  },

  { path: 'specialorder/post/:id', component: BidProposalPageUserComponent,
  canActivate: [UserGuard]
 },
 { path: 'allposts', component: PostsComponent,
  // canActivate: [ChefGuard]
},
  {
    path: 'specialorder/proposal/:id',
    component: BidProposalPageChefComponent,
    canActivate: [ChefGuard]
  },
  { path: 'checkout', component: CheckoutComponent },  //, canActivate: [UserGuard]
  { path: 'profile/:id', component: ChefProfileComponent }, //, canActivate: [ChefGuard]
  {path:'**',component:ContentComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
