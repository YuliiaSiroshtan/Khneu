import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { Input } from "@angular/core";
import { ReportDataService } from "src/app/core/services/report-data.service";
import { Report } from "src/app/core/models/report.model";

@Component({
  selector: 'report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  @Input() ReportInfo: Report;

  Report: Report[] = [];
  Publication;

  departmentReportForm: FormGroup;
  halfYearDepartmentReportForm: FormGroup;

  constructor(
    private _ReportDataService: ReportDataService,
    private _fb: FormBuilder) {
  }

  ngOnInit() {
    if (!this.ReportInfo) {
      this.ReportInfo = new Report();
    }

    this.departmentReportForm = this._fb.group({
      'DepartmentId': new FormControl(this.ReportInfo.DepartmentId, Validators.compose(
        [Validators.required]
      )),
      'DateRange': new FormControl(this.ReportInfo.DateRange, Validators.compose(
        [Validators.required]
      ))
    }
    );

    this.halfYearDepartmentReportForm = this._fb.group({
      'DepartmentId': new FormControl(this.ReportInfo.DepartmentId, Validators.compose(
        [Validators.required]
      )),
      'Year': new FormControl(this.ReportInfo.Year, Validators.compose(
        [Validators.required]
      )),
      'Half': new FormControl(this.ReportInfo.Half, Validators.compose(
        [Validators.required]
      ))
    }
    );
  }

  showReport(reportType) {
    let tempReport;

    if (reportType === 'Звіт за кафедрою') {
      tempReport = <Report>this.departmentReportForm.value;
      this._ReportDataService.showDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    } else if (reportType === 'Звіт за півріччя') {
      tempReport = <Report>this.halfYearDepartmentReportForm.value;
      this._ReportDataService.showHalfYearDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    }
  }

  printReport(reportType) {
    let tempReport;

    if (reportType === 'Звіт за кафедрою') {
      tempReport = <Report>this.departmentReportForm.value;
      this._ReportDataService.printDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    } else if (reportType === 'Звіт за півріччя') {
      tempReport = <Report>this.halfYearDepartmentReportForm.value;
      this._ReportDataService.printHalfYearDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    }
  }
}
