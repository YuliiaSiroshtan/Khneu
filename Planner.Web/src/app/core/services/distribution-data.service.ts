import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { DistributionFilterModel } from "../models/distributions.models";
import { environment } from 'src/environments/environment';

@Injectable()
export class DistributionDataService {
  constructor(private http: HttpClient) { }

  getDayDistribution(filter: DistributionFilterModel) {
    return this.http.post(environment.apiBaseUrl + '/api/Distribution/GetDayDistribution', filter);
  }
}
