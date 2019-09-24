import { Component, OnInit } from "@angular/core";
import { SelectItem } from "primeng/components/common/selectitem";
import { DistributionFilterModel } from "src/app/planner-component/distribution-component/shared/models/distribution-filter.model";
import { DayEntryModel } from "src/app/planner-component/distribution-component/shared/models/day-entry-model";
import { DistributionDataService } from "src/app/planner-component/distribution-component/shared/services/distribution-data.service";

@Component({
  selector: 'distribution',
  templateUrl: './distribution.component.html',
})
export class DistributionComponent implements OnInit {
  index: number;
  filter:DistributionFilterModel;
  years: SelectItem[] = [{ label: '2017', value: '2017' }]; 
  semesters: SelectItem[] = [{ label: 'Перший семестр', value: '1' }, { label: 'Другий семестр', value: '1' }];
  dayEntry: DayEntryModel[]=[];

  constructor(private distributionDataService: DistributionDataService) {
  }

  ngOnInit() {
    this.filter = new DistributionFilterModel();
  }

  getDayEntry() {
    this.distributionDataService.getDayDistribution(this.filter)
      .subscribe((result: DayEntryModel[]) => {
        this.dayEntry = result;
    })
  }

  submit() {

  }
}
