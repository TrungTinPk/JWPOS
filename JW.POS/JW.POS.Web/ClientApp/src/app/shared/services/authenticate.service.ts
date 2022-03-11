import { Injectable } from '@angular/core';
import {BehaviorSubject, concat, Observable, of} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {StorageService} from "./storage.service";
import {CurrentUser} from "../models/user.model";
import jwtDecode from 'jwt-decode'
import {filter, map, take, tap} from "rxjs/operators";

declare type Claim = {
  key: string,
  value: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {

  constructor(
    private _httpClient: HttpClient,
    private _storage: StorageService
  ) {

  }

  persistToken(token: string) {
    this._storage.set('token', token);
  }

  getToken(): Observable<string> {
    return of(this._storage.get('token') || '');
  }

  clearToken(): void {
    return this._storage.set('token', null);
  }

  private _userSubject = new BehaviorSubject<CurrentUser | null>(null);
  isAuthenticated(): Observable<boolean>{
    return this.getUser().pipe(map(u => !!u));
  }

  getUser(): Observable<CurrentUser | null> {
    return concat(
      this._userSubject.pipe(
        take(1),
        filter(u => !!u)
      ),
      this.getCurrentUser().pipe(
        filter(u => !!u),
        tap(u => this._userSubject.next(u))
      ),
      this._userSubject.asObservable()
    );
  }

  getCurrentUser(): Observable<CurrentUser | null> {
    const token = this._storage.get('token');
    if (!token) {
      return of(null);
    }

    let claims: any;

    try {
        claims = jwtDecode(token);
    } catch {
      return of(null)
    }

    if (!claims || Date.now().valueOf() > claims.exp * 100) {
      return of(null);
    }

    const user: CurrentUser = {
      username:claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] as string,
      fullName:claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] as string,
      role: claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']  as string
    };

    return of(user);
  }
}
