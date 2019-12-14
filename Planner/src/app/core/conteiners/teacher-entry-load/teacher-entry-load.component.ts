import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'pl-teacher-entry-load',
  templateUrl: './teacher-entry-load.component.html',
  styleUrls: ['./teacher-entry-load.component.css']
})
export class TeacherEntryLoadComponent implements OnInit {

  constructor(
    private _accountService: AccountService
  ) { }

  get users$(){
    this._accountService.users$.subscribe((res)=>{
      console.log(res);
    })
    return this._accountService.users$;
  }

  ngOnInit() {
    this._accountService.uploadUsersByDepartmentId(11);
  }

}
