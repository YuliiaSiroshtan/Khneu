import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';



@Injectable()
export class UserListDataService {
  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get('/api/Account/GetAllUsers');
  }

  changeUserStatus(userId: string) {
      return this.http.post('/api/Account/ChangeUserStatus', userId);
  }

  
}
