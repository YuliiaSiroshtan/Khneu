import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";


@Injectable()
export class UploadDistributionService {
  constructor(private http: HttpClient) { }

}
