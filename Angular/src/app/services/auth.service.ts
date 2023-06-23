import { Injectable } from '@angular/core';
import { Chef } from '../_models/chef/chef';
import { Client } from '../_models/client/client';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor() {}
  userRole: string = 'chef';
  user: Chef | Client = new Chef(
    "1",
    'Aisha Mohamed',
    '17 Al-Sheikh Zayed St, 6th of October, Egypt',
    'assets/chef1.jpg',
    4
  );
  // user: Chef | Client = new Client(
  //   '+201234567810',
  //   'Mohamed Abdelrahman',
  //   'mohamed.abdelrahman@example.com',
  //   'M',
  //   '8 El-Sheikh Ali Youssef, El-Attarin, Alexandria Governorate, Egypt'
  // );
}
