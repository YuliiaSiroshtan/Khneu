import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { UserProfileModel } from "src/app/planner-component/home-component/shared/models/user-profile.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { HttpRequest } from "@angular/common/http";
import { HttpEventType } from "@angular/common/http";
import { environment } from "src/environments/environment";


@Injectable()
export class UserDataService {
    constructor(private http: HttpClient) { }


    updateUserInfo(user: UserProfileModel) {
        return this.http.post(environment.apiBaseUrl +'/api/Account/UpdateUser', user);
    }

    getUser(appUserId: string) {
        return this.http.get(environment.apiBaseUrl +'/api/Account/GetUser', { params: { userId: appUserId }} );
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
