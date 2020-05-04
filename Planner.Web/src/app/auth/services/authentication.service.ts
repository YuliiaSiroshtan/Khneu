import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { LoginModel } from '../models/auth.models';

@Injectable()
export class AuthenticationService {
  private tokenResult: any;

  get isLoggin(){
    return !!this.getToken();
  }
  
  constructor(private _http: HttpClient) { }

  isAuthenticated(login: LoginModel) {
    return this._http.post(environment.apiBaseUrl + 'api/Token/CreateToken', login)
    .pipe(map(result => {
      this.tokenResult = result;
      if (this.tokenResult && this.tokenResult.jwtToken && this.tokenResult.jwtToken.token) {
        console.log(result);
        localStorage.setItem('tokenInfo', this.tokenResult.jwtToken.token);
        localStorage.setItem('role', this.tokenResult.jwtToken.role);
      }
      return this.tokenResult;
    }));
  }

  getToken() {
    return localStorage.getItem('tokenInfo');
  }
}
