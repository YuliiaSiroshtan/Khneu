import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { UserInfo } from "src/app/shared/models/user-info.model";
import { environment } from "src/environments/environment";
import { LoginModel } from "../models/login.model";

@Injectable()
export class AuthenticationService {
  private tokenResult: any;

  constructor(private http: HttpClient) { }

  isAuthenticated(login: LoginModel) {
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post(environment.apiBaseUrl + 'api/Token/CreateToken', {
      login: login.email,
      password: login.password
    }, httpOptions).pipe(map(result => {
      this.tokenResult = result;
      if (this.tokenResult && this.tokenResult.jwtToken && this.tokenResult.jwtToken.token) {
        localStorage.setItem('tokenInfo', JSON.stringify(this.tokenResult.jwtToken));
        this.setUserInfo();
      }

      return this.tokenResult;
    }));

  }


  setUserInfo() {
    return this.http.get(environment.apiBaseUrl + 'api/Account/GetUserInfo').subscribe((result) => {
      if (result) {
        localStorage.setItem('userInfo', JSON.stringify(result));
      }
    });
  }

  getUserInfo() {
    let userInfo = JSON.parse(localStorage.getItem('userInfo'));
    return <UserInfo>userInfo;
  }

  getToken() {
    let token = JSON.parse(localStorage.getItem('tokenInfo'));
    if (token) {
      return token.token;
    }
    return null;
  }
}
