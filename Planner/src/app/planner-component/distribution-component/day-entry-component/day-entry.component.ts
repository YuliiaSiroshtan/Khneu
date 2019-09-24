import { Component, OnInit, Input } from "@angular/core";
import { DayEntryModel } from "src/app/planner-component/distribution-component/shared/models/day-entry-model";

@Component({
  selector: 'day-entry',
  templateUrl: './day-entry.component.html',
})
export class DayEntryComponent implements OnInit {
  @Input() dayEntry: DayEntryModel[];

  constructor() {
  }

  ngOnInit() {
  }


}
