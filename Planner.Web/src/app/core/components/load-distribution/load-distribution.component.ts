import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { EntryLoadService } from '../../services/entry-load.service';
import { DesciplineService } from '../../services/descipline.service';
import { FullTimeDisciplinesViewModel } from '../../models/disciplines.models';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-load-distribution',
  templateUrl: './load-distribution.component.html',
  styleUrls: ['./load-distribution.component.scss']
})
export class LoadDistributionComponent implements OnInit {

  constructor(
    private _accountService: AccountService,
    private _entryLoadService: EntryLoadService,
    private _desciplinesService: DesciplineService
  ) { }


  get users$(){
    return this._accountService.users$;
  }

  get fullTimeDisciplines$() : BehaviorSubject<FullTimeDisciplinesViewModel[]>{
    return  this._desciplinesService.fullTimeDisciplines$;
  }

  ngOnInit() {
    this._accountService.uploadUsersByDepartmentId(11);
    this._desciplinesService.uploadFullTimeDiscipline(9);
  }

  makeAnEntryLoadPlan(){
    this._entryLoadService.makeAnEntryLoadPlan(1);
  }

}
