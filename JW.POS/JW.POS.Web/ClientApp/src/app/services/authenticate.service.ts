import { Injectable } from '@angular/core';
import {isObservable, of} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {

  constructor() { }

  // @ts-ignore
  isAuthenticated(): isObservable<boolean>{
    return of(true);
  }
}
