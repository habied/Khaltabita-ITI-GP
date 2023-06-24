import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
 // message: string;
  constructor(private router: Router,private http: HttpClient) {}
beachef(){
  localStorage.setItem("registerAs","Chef");
  window.scrollTo(0, 0);
  this.router.navigate(['/login/Be_a_chef']);
}
// onSubmit()
// {
//   const emailUrl = 'https://api.sendgrid.com/v3/mail/send'; // Replace with your email sending API endpoint
//   const emailBody = {
//     personalizations: [{ to: [{ email: 'recipient@example.com' }] }],
//     from: { email: 'amiragomaa2597@example.com' },
//     subject: 'New Message from your website!',
//     content: [{ type: 'text/plain', value: this.message }]
//   };
//   this.http.post(emailUrl, emailBody).subscribe();
// }


}
