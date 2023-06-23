import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { Chef } from 'src/app/_models/chef/chef';
import { ChefService } from 'src/app/services/chef-service';

@Component({
  selector: 'app-top-chefs',
  templateUrl: './top-chefs.component.html',
  styleUrls: ['./top-chefs.component.css'],
})
export class TopChefsComponent {
  constructor(public chfService: ChefService) {}
  chefs: Chef[] = [];
  sub: Subscription | null = null;

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
  ngOnInit(): void {
    this.sub = this.chfService.getTop10Chefs().subscribe((data) => {
      this.chefs = data;
    });
  }
}
