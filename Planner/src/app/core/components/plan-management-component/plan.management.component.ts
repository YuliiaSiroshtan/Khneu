import { Component, OnInit } from '@angular/core';
import { MessageService } from "primeng/components/common/messageservice";
import { IndivPlanDataService } from "src/app/core/services/indiv-plan-data.service";
import { IndivPlanFieldModel, IndivPlanFieldsValueModel } from '../../models/ind-plan.models';

@Component({
  selector: 'plan-management',
  templateUrl: './plan.management.component.html'
})
export class PlanManagementComponent implements OnInit {
  planManagementField: IndivPlanFieldModel[] = [];
  planManagementFieldValue: IndivPlanFieldsValueModel[] = [];

  //planManagementForm: FormGroup;

  constructor(
    private _indivPlanDataService: IndivPlanDataService,
    private _messageService: MessageService) {
  }

  ngOnInit() {
    this.getIndivPlanField();
    this.getIndivPlanFieldValue();
  }

  getIndivPlanField() {
    let planManagementTypeId = "6e57da2e-de83-4c6c-b365-6e8aafa7d2ab";

    this._indivPlanDataService.getIndivPlanField(planManagementTypeId).subscribe((result: IndivPlanFieldModel[]) => {
      if (result) {
        this.planManagementField = result;
      }
    });
  }

  getIndivPlanFieldValue() {
    this._indivPlanDataService.getIndivPlanFieldValue().subscribe((result: IndivPlanFieldsValueModel[]) => {
      if (result) {
        this.planManagementFieldValue = result;
      }
    });
  }

  updateIndivPlanFieldValue() {
    //if (this.planManagementForm.invalid) return;

    //let tempPlanManagementForm = <IndivPlanFieldsValueModel>this.planManagementForm.value;
    let temp = new IndivPlanFieldsValueModel();
    this._indivPlanDataService.updateIndivPlanFieldValue(temp).subscribe(data => {
      if (data) {
      //  this.planManagementForm.reset();
        this.getIndivPlanFieldValue();
        this._messageService.add({ key: 'success', severity: 'success', summary: '', detail: 'Дані організаційної роботи успішно оновлено' });
      } else {
        this._messageService.add({ key: 'error', severity: 'error', summary: '', detail: '' });
      }
    });
  }
}
