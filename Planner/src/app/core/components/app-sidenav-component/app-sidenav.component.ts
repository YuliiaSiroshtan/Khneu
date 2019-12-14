import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './app-sidenav.component.html',
  styleUrls: ['./app-sidenav.component.css']
})
export class AppSidenavComponent implements OnInit {
  display: boolean = true;

  constructor(private  _accountService:  AccountService) { }

  ngOnInit() {
    this._accountService.uploadUserInfo();
  }
}
