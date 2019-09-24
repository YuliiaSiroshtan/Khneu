import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of, Subject, forkJoin } from 'rxjs';
import { UserInfo } from "src/app/shared/models/user-info.model";
import { LoginModel } from "src/app/account-component/shared/models/login.model";

@Injectable()
export class AuthenticationService {
    private tokenResult: any;

    constructor(private http: HttpClient) { }

    isAuthenticated(login: LoginModel) {
        let httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        let body = JSON.stringify(login);
        return this.http.post('api/Token/CreateToken', body, httpOptions).pipe(map(result => {
            this.tokenResult = result;
            if (this.tokenResult && this.tokenResult.jwtToken &&  this.tokenResult.jwtToken.token) {
                localStorage.setItem('tokenInfo', JSON.stringify(this.tokenResult.jwtToken));
                this.setUserInfo();
            }

            return this.tokenResult;
        }));

    }


    setUserInfo() {
        return this.http.get('api/Account/GetUserInfo').subscribe((result) => {
            if (result) {
                localStorage.setItem('userInfo', JSON.stringify(result));
            }
        });
    }

    public getUserInfo() {
        let userInfo = JSON.parse(localStorage.getItem('userInfo'));
        return <UserInfo>userInfo;
    }

    public getToken() {
        let token = JSON.parse(localStorage.getItem('tokenInfo'));
        if (token) {
            return token.token;
        }
        return null;
    }
}
