import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {StorageService} from "./storage.service";
import {Observable} from "rxjs";
import {map} from "rxjs/operators";

declare type LoginResponse = {
  token: string
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private _httpClient: HttpClient
  ) {

  }

  login(username: string, password: string): Observable<string>{
    return this._httpClient.post<LoginResponse>('api/auth/login', {username, password})
      .pipe(map(response => response.token))
  }
}
