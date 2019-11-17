import { Component, OnInit } from "@angular/core";
import { SelectItem } from "primeng/components/common/selectitem";
import { DistributionFilterModel, DayEntryModel } from "../../models/distributions.models";
import { DistributionDataService } from "../../services/distribution-data.service";


@Component({
  selector: 'distribution',
  templateUrl: './distribution.component.html',
})
export class DistributionComponent implements OnInit {
  index: number;
  filter: DistributionFilterModel;
  years: SelectItem[] = [{ label: '2017', value: '2017' }];
  semesters: SelectItem[] = [{ label: 'Перший семестр', value: '1' }, { label: 'Другий семестр', value: '1' }];
  dayEntry: DayEntryModel[] = [];

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
