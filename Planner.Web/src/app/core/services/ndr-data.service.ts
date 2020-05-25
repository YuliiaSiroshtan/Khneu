import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NDR } from "src/app/core/models/ndr.model";
import { environment } from 'src/environments/environment';

@Injectable()
export class NDRDataService {
  constructor(private http: HttpClient) { }

  addNDR(ndr: NDR) {
    return this.http.post(environment.apiBaseUrl + '/api/Ndr/AddNdr', ndr);
  }

  getUserNdr() {
    return this.http.get(environment.apiBaseUrl + '/api/Ndr/GetUserNdr');
  }
}
