import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpRequest } from "@angular/common/http";
import { HttpParams } from "@angular/common/http";
import { PublicationAddEditModel } from "../models/models-publication-component/publication-add-edit.model";
import { environment } from 'src/environments/environment';

@Injectable()
export class PublicationDataService {
  constructor(private http: HttpClient) { }

  addPublication(publication: PublicationAddEditModel) {
      return this.http.post(environment.apiBaseUrl + '/api/Publication/UpdatePublication', publication);
  }

  getUserPublication() {
      return this.http.get(environment.apiBaseUrl + '/api/Publication/GetUserPublications');
  }

  getNMBDs() {
      return this.http.get(environment.apiBaseUrl + '/api/Publication/GetNMBDs');
  }

  getUsers() {
      return this.http.get(environment.apiBaseUrl + '/api/Account/GetAllUsers');
  }

  sendMessageToLibrary(id: string) {
    let params = new HttpParams();

    params = params.set('id', id);
    return this.http.get(environment.apiBaseUrl + '/api/Publication/SendMessage', { params: params });
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
