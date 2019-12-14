import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take, map, catchError } from 'rxjs/operators';
import { BehaviorSubject, of } from 'rxjs';
import { UserViewModel } from '../models/user.models';

@Injectable()
export class AccountService {
  user$: BehaviorSubject<UserViewModel> = new BehaviorSubject<UserViewModel>(
    null
  );

  usersByDepartment$: BehaviorSubject<UserViewModel[]> = new BehaviorSubject<
    UserViewModel[]
  >([]);

  users$: BehaviorSubject<UserViewModel[]> = new BehaviorSubject<
    UserViewModel[]
  >([]);

  constructor(private _http: HttpClient) {}

  uploadUsers() {
    this._http
      .get(environment.apiBaseUrl + 'api/Account/GetUsers')
      .pipe(
        take(1),
        map((response: UserViewModel[]) => {
          this.users$.next(response);
        })
      )
      .subscribe();
  }

  uploadUsersByDepartmentId(id: number) {
    this._http
      .get(environment.apiBaseUrl + 'api/Account/GetUsersByDepartmentId?id=' + id)
      .pipe(
        take(1),
        map((response: UserViewModel[]) => {
          this.users$.next(response);
        })
      )
      .subscribe();
  }

  uploadUserInfo() {
    this._http
      .get(environment.apiBaseUrl + 'api/Account/GetUserInfo')
      .pipe(
        take(1),
        map((response: UserViewModel) => {
          this.user$.next(response);
        })
      )
      .subscribe();
  }

  uploadUser(id: number) {
    this._http
      .get(environment.apiBaseUrl + 'api/Account/GetUser' + id)
      .pipe(
        take(1),
        map((response: UserViewModel) => {
          this.user$.next(response);
        })
      )
      .subscribe();
  }

  updateUser(user: UserViewModel) {
    this._http
      .post(environment.apiBaseUrl + 'api/Account/UpdateUser', user)
      .pipe(
        take(1),
        map((response: UserViewModel) => {
          this.user$.next(response);
        }),
        catchError(err => of(console.log(err)))
      )
      .subscribe();
  }
}
