import { Component } from '@angular/core';
import { AuthenService } from '../services/authen.service';
import { LoginDTO } from '../_models/Auth/LoginDTO';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})

export class LoginPageComponent {

  loginForm: FormGroup;
constructor(private formBuilder:FormBuilder,private authService: AuthenService, private route: Router) {
  this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });
    }
    isLoggedIn=false
    email:string=""
    password:string="" 
    Id:string=""; 
    ngOnInit():void{
      this.loginForm = this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      });
    }

    onSubmit(e:Event) {
      e.preventDefault();  
      var credentials = new LoginDTO();
      credentials.email = this.loginForm.get('email')?.value ?? '';
      credentials.password = this.loginForm.get('password')?.value ?? '';
      this.authService.login(credentials).subscribe((token) => {
        // console.log(token);
        this.Id=token.id;
        this.authService.isAuth$.subscribe((value) => (this.isLoggedIn = value));
        this.route.navigateByUrl("/home");

      });
    
    } 
    RegisterAsAUser(){
      localStorage.setItem('registerAs', "User");
      console.log("User");
      
    }
    RegisterAsAChef()
    {
      localStorage.setItem('registerAs', "Chef");
      console.log("Chef");

    }
   
  }
  
