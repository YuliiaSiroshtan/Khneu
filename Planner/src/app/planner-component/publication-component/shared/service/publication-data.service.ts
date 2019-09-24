import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Publication } from "src/app/planner-component/publication-component/shared/models/publication.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { HttpRequest } from "@angular/common/http";
import { HttpEventType, HttpParams } from "@angular/common/http";
import { PublicationAddEditModel } from "src/app/planner-component/publication-component/shared/models/publication-add-edit.model";

@Injectable()
export class PublicationDataService {
  constructor(private http: HttpClient) { }

  addPublication(publication: PublicationAddEditModel) {
      return this.http.post('/api/Publication/UpdatePublication', publication);
  }

  getUserPublication() {
      return this.http.get('/api/Publication/GetUserPublications');
  }

  getNMBDs() {
      return this.http.get('/api/Publication/GetNMBDs');
  }

  getUsers() {
      return this.http.get('/api/Account/GetAllUsers');
  }

  sendMessageToLibrary(id: string) {
    let params = new HttpParams();

    params = params.set('id', id);
    return this.http.get('/api/Publication/SendMessage', { params: params });
  }

  uploadFiles(data: File) {
      let formData: FormData = new FormData();

      formData.append(data.name, data);
      const uploadReq = new HttpRequest('POST', 'api/Publication', formData, {
          reportProgress: true,
      });
      return this.http.request(uploadReq);
  }
}
