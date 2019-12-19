import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { EntryLoadService } from '../../services/entry-load.service';

@Component({
  selector: 'pl-teacher-entry-load',
  templateUrl: './teacher-entry-load.component.html',
  styleUrls: ['./teacher-entry-load.component.css']
})
export class TeacherEntryLoadComponent implements OnInit {

  constructor(
    private _accountService: AccountService,
    private _entryLoadService: EntryLoadService
  ) { }

  get users$(){
    this._accountService.users$.subscribe((res)=>{
    })
    return this._accountService.users$;
  }

  ngOnInit() {
    this._accountService.uploadUsersByDepartmentId(11);
  }

  makeAnEntryLoadPlan(){
    this._entryLoadService.makeAnEntryLoadPlan(1);
  }

}
