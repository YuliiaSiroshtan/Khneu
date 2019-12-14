import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { LoginModel } from "../models/login.model";
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService {
  private tokenResult: any;

  constructor(private _http: HttpClient,
    private  _router:  Router) { }

  isAuthenticated(login: LoginModel) {
    return this._http.post(environment.apiBaseUrl + 'api/Token/CreateToken', login)
    .pipe(map(result => {
      this.tokenResult = result;
      if (this.tokenResult && this.tokenResult.jwtToken && this.tokenResult.jwtToken.token) {
        localStorage.setItem('tokenInfo', this.tokenResult.jwtToken.token);
      }
      return this.tokenResult;
    }));
  }

  getToken() {
    return localStorage.getItem('tokenInfo');
  }
}
