import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Chef } from 'src/app/_models/chef/chef';
import { ChefService } from 'src/app/services/chef-service';

@Component({
  selector: 'app-chef-index',
  templateUrl: './chef-index.component.html',
  styleUrls: ['./chef-index.component.css'],
})
export class ChefIndexComponent implements OnInit, OnDestroy {
  constructor(public chfService: ChefService) {}
  chefs: Chef[] = [];
  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
  sub: Subscription | null = null;
  ngOnInit(): void {
    this.sub = this.chfService.getAll().subscribe((data) => {
      this.chefs = data;
    });
  }
}
