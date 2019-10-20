import { Component, OnInit } from '@angular/core';
import { FormGroup} from "@angular/forms";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { IndivPlanDataService } from "src/app/planner-component/indiv-plan-component/shared/service/indiv-plan-data.service";
import { IndivPlanFieldsValueModel } from "src/app/planner-component/indiv-plan-component/shared/models/indiv-plan-field-value.model";
import { IndivPlanFieldModel } from "src/app/planner-component/indiv-plan-component/shared/models/indiv-plan-field.model";

@Component({
  selector: 'plan-scientific-work',
  templateUrl: './plan.scientific.work.component.html',
  styleUrls: ['./../indiv.plan.component.css']

})
export class PlanScientificWorkComponent implements OnInit {
  planScientificWorkField: IndivPlanFieldModel[] = [];
  planScientificWorkFieldValue: IndivPlanFieldsValueModel[] = [];
  
  planScientificWorkForm: FormGroup;

  constructor(
    private _indivPlanDataService: IndivPlanDataService,
    private _messageService: MessageService) {
  }

  ngOnInit() {
    this.getIndivPlanField();
    this.getIndivPlanFieldValue();
  }

  getIndivPlanField() {
    let planScientificWorkTypeId = "4dc30515-da93-4a4b-a567-342d82472bc3";

    this._indivPlanDataService.getIndivPlanField(planScientificWorkTypeId).subscribe((result: IndivPlanFieldModel[]) => {
      if (result) {
        this.planScientificWorkField = result;
      }
    });
  }

  getIndivPlanFieldValue() {
    this._indivPlanDataService.getIndivPlanFieldValue().subscribe((result: IndivPlanFieldsValueModel[]) => {
      if (result) {
        this.planScientificWorkFieldValue = result;
      }
    });
  }

  updateIndivPlanFieldValue() {
    if (this.planScientificWorkForm.invalid) return;

    let tempplanScientificWorkForm = <IndivPlanFieldsValueModel>this.planScientificWorkForm.value;

    this._indivPlanDataService.updateIndivPlanFieldValue(tempplanScientificWorkForm).subscribe(data => {
      if (data) {
        this.planScientificWorkForm.reset();
        this.getIndivPlanFieldValue();
        this._messageService.add({ key: 'success', severity: 'success', summary: '', detail: 'Дані наукової роботи успішно оновлено' });
      } else {
        this._messageService.add({ key: 'error', severity: 'error', summary: '', detail: '' });
      }
    });
  }
}
