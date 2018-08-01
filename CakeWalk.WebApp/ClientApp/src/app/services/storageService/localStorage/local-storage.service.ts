import { Injectable } from '@angular/core';
import { IsJsonString } from '../../../util/validateInput';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }
  static StoreValue(key: string, value: any) {
    localStorage.setItem(key, JSON.stringify(value));
  }

  // Get Value from the Local storage
  static getValue(key: string): any {
    if (localStorage.getItem(key)) {
      if (IsJsonString(localStorage.getItem(key))) {
        return JSON.parse(localStorage.getItem(key));
      }
      return localStorage.getItem(key);
    } else {
      return null;
    }
  }

  // Check if key available at Local storage
  static isExist(key: string) {
    if (localStorage.getItem(key)) {
      return true;
    }
    return false;
  }

  // Clear the Local storage
  static Clear() {
    localStorage.clear();
  }
}
