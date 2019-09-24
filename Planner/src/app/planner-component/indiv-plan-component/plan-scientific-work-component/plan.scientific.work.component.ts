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
import { IndivPlanFieldsValueModel } from "src/app/planner-component/indiv-plan-component/shared/models/indiv-plan-field-value.model";
import { IndivPlanFieldModel } from "src/app/planner-component/indiv-plan-component/shared/models/indiv-plan-field.model";
import { SelectItem } from "primeng/components/common/selectitem";


@Component({
  selector: 'plan-scientific-work',
  templateUrl: './plan.scientific.work.component.html',
  styleUrls: ['./../indiv.plan.component.css']

})
export class PlanScientificWorkComponent implements OnInit {
  planScientificWorkField: IndivPlanFieldModel[] = [];
  planScientificWorkFieldValue: IndivPlanFieldsValueModel[] = [];
  
  planScientificWorkForm: FormGroup;

  constructor(private authenticationService: AuthenticationService,
    private indivPlanDataService: IndivPlanDataService,
    private router: Router,
    private messageService: MessageService) {
  }

  ngOnInit() {
    this.getIndivPlanField();
    this.getIndivPlanFieldValue();
  }

  getIndivPlanField() {
    let planScientificWorkTypeId = "4dc30515-da93-4a4b-a567-342d82472bc3";

    this.indivPlanDataService.getIndivPlanField(planScientificWorkTypeId).subscribe((result: IndivPlanFieldModel[]) => {
      if (result) {
        this.planScientificWorkField = result;
      }
    });
  }

  getIndivPlanFieldValue() {
    this.indivPlanDataService.getIndivPlanFieldValue().subscribe((result: IndivPlanFieldsValueModel[]) => {
      if (result) {
        this.planScientificWorkFieldValue = result;
      }
    });
  }

  updateIndivPlanFieldValue() {
    if (this.planScientificWorkForm.invalid) return;

    let tempplanScientificWorkForm = <IndivPlanFieldsValueModel>this.planScientificWorkForm.value;

    this.indivPlanDataService.updateIndivPlanFieldValue(tempplanScientificWorkForm).subscribe(data => {
      if (data) {
        this.planScientificWorkForm.reset();
        this.getIndivPlanFieldValue();
        this.messageService.add({ key: 'success', severity: 'success', summary: '', detail: 'Дані наукової роботи успішно оновлено' });
      } else {
        this.messageService.add({ key: 'error', severity: 'error', summary: '', detail: '' });
      }
    });
  }
}
