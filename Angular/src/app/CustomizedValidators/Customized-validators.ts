import { Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { formatDate } from '@angular/common';

export class CustomizedValidators{
  static futureDateValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const inputDate = new Date(control.value);
      const currentDate = new Date();
      if (inputDate < currentDate) {
        return { 'futureDate': true };
      } else {
        return null;
      }
    };
  }

  static priceRangeValidator(min: number, max: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const inputPrice = control.value;
      if (inputPrice === null || inputPrice === undefined || isNaN(inputPrice)) {
        return null; // don't validate if the input is not a number
      }
      if (inputPrice < min && inputPrice > max) {
        return null; // valid input
      } else {
        return { 'priceRange': true }; // invalid input
      }
    };
  }

}


