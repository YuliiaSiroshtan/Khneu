import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { LoginModel } from "src/app/account-component/shared/models/login.model";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { UserProfileModel } from "src/app/planner-component/home-component/shared/models/user-profile.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { Input } from "@angular/core";
import { Output } from "@angular/core";
import { EventEmitter } from "events";
import { UserDataService } from "src/app/planner-component/shared/service/user-data.service";
import { ValidateLetter } from "src/app/shared/validators/letter-validator";
import { ValidateURL } from "src/app/shared/validators/url-validator";
import { ApplicationConstants } from "src/app/shared/constants/constants";
import { HttpEventType } from "@angular/common/http";
import { ReportDataService } from "src/app/planner-component/report-component/shared/service/report-data.service";
import { Report } from "src/app/planner-component/report-component/shared/models/report.model";


@Component({
  selector: 'report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  @Input() ReportInfo: Report;

  Report: Report[] = [];

  departmentReportForm: FormGroup;
  halfYearDepartmentReportForm: FormGroup;

  constructor(private authenticationService: AuthenticationService,
    private ReportDataService: ReportDataService,
    private router: Router,
    private messageService: MessageService,
    private fb: FormBuilder) {
  }

  ngOnInit() {
    if (!this.ReportInfo) {
      this.ReportInfo = new Report();
    }

    this.departmentReportForm = this.fb.group({
      'DepartmentId': new FormControl(this.ReportInfo.DepartmentId, Validators.compose(
        [Validators.required]
      )),
      'DateRange': new FormControl(this.ReportInfo.DateRange, Validators.compose(
        [Validators.required]
      ))
    }
    );

    this.halfYearDepartmentReportForm = this.fb.group({
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
      this.ReportDataService.showDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    } else if (reportType === 'Звіт за півріччя') {
      tempReport = <Report>this.halfYearDepartmentReportForm.value;
      this.ReportDataService.showHalfYearDepartmentReport(tempReport).subscribe((result: Report[]) => {
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
      this.ReportDataService.printDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    } else if (reportType === 'Звіт за півріччя') {
      tempReport = <Report>this.halfYearDepartmentReportForm.value;
      this.ReportDataService.printHalfYearDepartmentReport(tempReport).subscribe((result: Report[]) => {
        if (result) {
          this.Report = result;
        }
      });
    }
  }
}
