import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpRequest } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { UserProfileModel } from '../models/user.models';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }

  updateUserInfo(user: UserProfileModel) {
    return this.http.post(environment.apiBaseUrl + '/api/Account/UpdateUser', user);
  }

  getUser(appUserId: string) {
    return this.http.get(environment.apiBaseUrl + '/api/Account/GetUser', { params: { userId: appUserId } });
  }

  getUserInfo() {
    return this.http.get(environment.apiBaseUrl + 'api/Account/GetUserInfo');
  }

  uploadFiles(data: File) {
    let formData: FormData = new FormData();

    formData.append(data.name, data);
    const uploadReq = new HttpRequest('POST', 'api/Account', formData, {
      reportProgress: true,
    });
    return this.http.request(uploadReq);
  }
}