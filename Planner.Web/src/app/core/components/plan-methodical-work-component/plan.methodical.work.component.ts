import { Component, OnInit } from '@angular/core';
import { FormGroup } from "@angular/forms";
import { MessageService } from "primeng/api";
import { IndivPlanDataService } from "src/app/core/services/indiv-plan-data.service";
import { IndivPlanFieldModel, IndivPlanFieldsValueModel } from '../../models/ind-plan.models';

@Component({
  selector: 'plan-methodical-work',
  templateUrl: './plan.methodical.work.component.html',
  styleUrls: ['./plan.methodical.work.component.scss']
})
export class PlanMethodicalWorkComponent implements OnInit {
  planMethodicalWorkField: IndivPlanFieldModel[] = [];
  planMethodicalWorkFieldValue: IndivPlanFieldsValueModel[] = [];

  planMethodicalWorkForm: FormGroup;

  constructor(
    private indivPlanDataService: IndivPlanDataService,
    private messageService: MessageService) {
  }

  ngOnInit() {
    this.getIndivPlanField();
    this.getIndivPlanFieldValue();
  }

  getIndivPlanField() {
    let planMethodicalWorkTypeId = "21972bd0-1081-4ab7-aab4-cc723b8a2c71";

    this.indivPlanDataService.getIndivPlanField(planMethodicalWorkTypeId).subscribe((result: IndivPlanFieldModel[]) => {
      if (result) {
        this.planMethodicalWorkField = result;
      }
    });
  }

  getIndivPlanFieldValue() {
    this.indivPlanDataService.getIndivPlanFieldValue().subscribe((result: IndivPlanFieldsValueModel[]) => {
      if (result) {
        this.planMethodicalWorkFieldValue = result;
      }
    });
  }

  updateIndivPlanFieldValue() {
    if (this.planMethodicalWorkForm.invalid) return;

    let tempPlanMethodicalWorkForm = <IndivPlanFieldsValueModel>this.planMethodicalWorkForm.value;

    this.indivPlanDataService.updateIndivPlanFieldValue(tempPlanMethodicalWorkForm).subscribe(data => {
      if (data) {
        this.planMethodicalWorkForm.reset();
        this.getIndivPlanFieldValue();
        this.messageService.add({ key: 'success', severity: 'success', summary: '', detail: 'Дані організаційної роботи успішно оновлено' });
      } else {
        this.messageService.add({ key: 'error', severity: 'error', summary: '', detail: '' });
      }
    });
  }
}
