import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Report } from "src/app/core/models/report.model";

@Injectable()
export class ReportDataService {
  constructor(private _http: HttpClient) { }

  showDepartmentReport(report: Report) {
    return this._http.post('', report);
  }

  printDepartmentReport(report: Report) {
    return this._http.post('', report);
  }

  showHalfYearDepartmentReport(report: Report) {
    return this._http.post('', report);
  }

  printHalfYearDepartmentReport(report: Report) {
    return this._http.post('', report);
  }
}
