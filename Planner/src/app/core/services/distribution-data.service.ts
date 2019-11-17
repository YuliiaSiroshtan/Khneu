import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { DistributionFilterModel } from "../models/distributions.models";

@Injectable()
export class DistributionDataService {
  constructor(private http: HttpClient) { }

  getDayDistribution(filter: DistributionFilterModel) {
    return this.http.post('/api/Distribution/GetDayDistribution', filter);
  }
}
