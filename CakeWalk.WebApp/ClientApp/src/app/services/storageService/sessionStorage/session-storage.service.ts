import { Injectable } from '@angular/core';


// other services
import { LocalStorageService } from './../localStorage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class SessionStorageService {

  constructor() { }

  // Get User information
  public get getUserInfo(): any {
    if (LocalStorageService.isExist(storageKey.cackWalk_user.toString())) {
      return LocalStorageService.getValue(storageKey.cackWalk_user.toString());
    }
    return null;
  }
  // Set User infrmation
  public setUserInfo(userModel: any) {
    LocalStorageService.StoreValue(storageKey.cackWalk_user.toString(), userModel);
  }
}

export enum storageKey {
  cackWalk_user = 1, // User
}
