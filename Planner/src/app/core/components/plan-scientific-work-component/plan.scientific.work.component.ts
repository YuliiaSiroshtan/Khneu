import { Component, OnInit } from '@angular/core';
import { FormGroup} from "@angular/forms";
import { MessageService } from "primeng/components/common/messageservice";
import { IndivPlanDataService } from "src/app/core/services/indiv-plan-data.service";
import { IndivPlanFieldModel, IndivPlanFieldsValueModel } from '../../models/ind-plan.models';

@Component({
  selector: 'plan-scientific-work',
  templateUrl: './plan.scientific.work.component.html'
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
