import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NDR } from "src/app/core/models/ndr.model";

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
