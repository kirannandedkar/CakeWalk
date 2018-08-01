import { FormGroup, FormControl } from '@angular/forms';
import { element } from 'protractor';
import { Type } from '@angular/core';

/* User for check is JSON format is valid or not */
export function IsJsonString(str) {
  try {
    JSON.parse(str);
  } catch (e) {
    return false;
  }
  return true;
}

// Validate form Fields
export function validateAllFormFields(formGroup: FormGroup) {
  Object.keys(formGroup.controls).forEach(field => {
    const control = formGroup.get(field);
    if (control instanceof FormControl) {
      control.markAsTouched({onlySelf: true});
      control.markAsDirty({onlySelf: true});
    } else if (control instanceof FormGroup) {
      this.validateAllFormFields(control);
    }
  });

}

// This function will check if form is valid , If not then show the error
export function isValidForm(formGroup: FormGroup) {
  if (formGroup.valid) {
    return true;
  }  else {
    validateAllFormFields(formGroup);
  }

}
