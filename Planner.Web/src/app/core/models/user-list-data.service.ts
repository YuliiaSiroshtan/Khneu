import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';



@Injectable()
export class UserListDataService {
  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get(environment.apiBaseUrl + '/api/Account/GetAllUsers');
  }

  changeUserStatus(userId: string) {
      return this.http.post(environment.apiBaseUrl + '/api/Account/ChangeUserStatus', userId);
  }

  
}
