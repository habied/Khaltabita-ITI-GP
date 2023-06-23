import { Component, OnInit } from '@angular/core';
import { RegisterDTO} from '../_models/Auth/RegisterDTO';
import {RegisterService } from 'src/app/services/register.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterChefDto } from '../_models/Auth/RegisterChefDto';
import { Route, Router } from '@angular/router';
import { DialogsService } from '../services/dialogs.service';
import { SimplestDialogComponent } from '../dialogs/simplest-dialog/simplest-dialog.component';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})


export class RegisterPageComponent implements OnInit {
  
  user = new RegisterDTO('', '', '', '', '', '','','');
  
  showSection: boolean = false;
 
  constructor(private dialogService: DialogsService,private registerService: RegisterService,public http:HttpClient , private route:Router) {}
  //#region to know whether it's user or chef 
  ngOnInit(): void {
    if ( localStorage.getItem("registerAs")=="Chef")
    {
      this.showSection = true ;
      console.log("it's chef from register ");
    }
    else  if ( localStorage.getItem("registerAs")=="User")
    {
      this.showSection = false ;
      console.log("it's user from register ");
    }

    const password = "Amira_m5";
    if (this.isValidPassword(password)) {
      console.log("Password is valid!");
    } else {
      console.log("Password is invalid!");
    }

  }
  //#endregion

  //#region registration
  registerUser() {
    console.log(this.user);
    if ( localStorage.getItem("registerAs") == "User")
    {
      console.log("User from register");
      this.registerService.registerUser(this.user).subscribe(response => {
        console.log(response);
      });
    }
    else if ( localStorage.getItem("registerAs") == "Chef")
    {
      console.log("Chef from register");
     this.registerChef(); 
    }
    this.returnToLogin();
  }


  registerChef() {

    console.log(this.user);

    this.registerService.registerChef(this.user).subscribe(response => {
      console.log(response);
    });
  }
  //#endregion

  //#region save the image as url 
  onImageSelected(e:Event){
    const fileInput = e.target as HTMLInputElement;
  if (fileInput && fileInput.files && fileInput.files.length > 0) {
    const file = fileInput.files[0];
   
    const formData = new FormData();
    formData.append('file', file);
    
    this.registerService.getTheLinkOfRegisterChefImage(formData).subscribe(response => {
      this.user.media = (response as any).url; // cast the 'response' object to 'any' type and retrieve the 'url' property using bracket notation
      console.log(this.user.media); // log the URL to the console
      // use the 'imageUrl' variable to store or display the image URL as needed
    });
  }
  }
  //#endregion
  
  //#region redirect to loginpage
returnToLogin()
{
  
  //this.dialogService.showMessage('Hello, world!', 'Greeting');
  
  this.route.navigate(['/login']);
}
  //#endregion



  //#region  validation 
  isValidEmail(email: string): boolean {
    // check if email is valid using regular expression
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }
  
  isValidPassword(password: string): boolean {
    // check if password is at least 6 characters long, has one uppercase letter, one lowercase letter, and one digit
     const passwordRegexPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[\w]{8,}$/;;
    return passwordRegexPattern.test(password);
  }
  
  isValidConfirmPassword(password: string, confirmPassword: string): boolean {
    // check if password and confirm password match
    return password === confirmPassword;
  }
  
  isValidPhoneNumber(phoneNumber: string): boolean {
    // check if phone number is numeric and has 11 digits
    const phoneNumberRegex = /^\d{11}$/;
    return phoneNumberRegex.test(phoneNumber);
  }
  //#endregion
}
