import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Report } from "src/app/planner-component/report-component/shared/models/report.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { HttpRequest } from "@angular/common/http";
import { HttpEventType } from "@angular/common/http";

@Injectable()
export class ReportDataService {
  constructor(private http: HttpClient) { }

  showDepartmentReport(report: Report) {
    return this.http.post('', report);
  }

  printDepartmentReport(report: Report) {
    return this.http.post('', report);
  }

  showHalfYearDepartmentReport(report: Report) {
    return this.http.post('', report);
  }

  printHalfYearDepartmentReport(report: Report) {
    return this.http.post('', report);
  }
}
