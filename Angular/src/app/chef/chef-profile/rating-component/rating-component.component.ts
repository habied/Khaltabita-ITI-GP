import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-rating',
  template: `
    <div class="rating">
      <span
        class="star"
        [class.filled]="i < currentRating"
        [class.highlighted]="i < hoveredRating"
        (mouseover)="highlight(i + 1)"
        (mouseleave)="resetHighlight()"
        (click)="rate(i + 1)"
        *ngFor="let star of stars; let i = index"
      >
        &#9733;
      </span>
    </div>
  `,
  styles: [
    `
      .rating {
        font-size: 24px;
      }
      .star {
        cursor: pointer;
        color: gray;
      }
      .filled {
        color: gold;
      }
      .highlighted {
        color: orange;
      }
    `
  ]
})
export class RatingComponent {
  @Input() currentRating: number = 0;
  @Output() UserRating:EventEmitter<number>=new EventEmitter<number>();
  @Input() maxRating: number = 5;

  stars: number[] = [];

  hoveredRating: number = 0;

  ngOnInit() {
    this.stars = Array(this.maxRating).fill(0);
  }

  highlight(rating: number) {
    this.hoveredRating = rating;
  }

  resetHighlight() {
    this.hoveredRating = 0;
  }

  rate(rating: number) {
    this.currentRating = rating;
    this.UserRating.emit(this.currentRating);
  }
}
