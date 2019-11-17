import { Injectable } from "@angular/core";
import { HttpClient, HttpRequest } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable()
export class UploadDistributionService {
  constructor(private _http: HttpClient) { }

    uploadFile(formData: FormData) {
        const uploadReq = new HttpRequest('POST',
        environment.apiBaseUrl +`api/IndividualPlan`,
            formData,
            {
                reportProgress: true,
            });

        return this._http.request(uploadReq);
    }
}
