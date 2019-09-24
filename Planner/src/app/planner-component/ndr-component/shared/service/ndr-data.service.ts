import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { NDR } from "src/app/planner-component/ndr-component/shared/models/ndr.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { HttpRequest } from "@angular/common/http";
import { HttpEventType } from "@angular/common/http";

@Injectable()
export class NDRDataService {
  constructor(private http: HttpClient) { }

  addNDR(ndr: NDR) {
    return this.http.post('/api/Ndr/AddNdr', ndr);
  }

  getUserNdr() {
    return this.http.get('/api/Ndr/GetUserNdr');
  }
}
