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
import { IndivPlanDataService } from "src/app/planner-component/indiv-plan-component/shared/service/indiv-plan-data.service";
import { TrainingJobModel } from "src/app/planner-component/indiv-plan-component/shared/models/training-job.model";
import { SelectItem } from "primeng/components/common/selectitem";


@Component({
  selector: 'training-job',
  templateUrl: './training.job.component.html',
  styleUrls: ['./training.job.component.css']
})
export class TrainingJobComponent implements OnInit {
  trainingJob: TrainingJobModel[] = [];

  trainingJobForm: FormGroup;

  constructor(private authenticationService: AuthenticationService,
    private indivPlanDataService: IndivPlanDataService,
    private router: Router,
    private messageService: MessageService) {
  }

  ngOnInit() {
    this.getTrainingJob();
  }

  getTrainingJob() {
    this.indivPlanDataService.getTrainingJob().subscribe((result: TrainingJobModel[]) => {
      if (result) {
        this.trainingJob = result;
      }
    });
  }

  updateTrainingJob() {
    if (this.trainingJobForm.invalid) return;

    let temptrainingJob = <TrainingJobModel>this.trainingJobForm.value;

    this.indivPlanDataService.updateTrainingJob(temptrainingJob).subscribe(data => {
      if (data) {
        this.trainingJobForm.reset();
        this.getTrainingJob();
        this.messageService.add({ key: 'success', severity: 'success', summary: '', detail: 'Дані навчальної роботи успішно оновлено' });
      } else {
        this.messageService.add({ key: 'error', severity: 'error', summary: '', detail: '' });
      }
    });
  }

}
