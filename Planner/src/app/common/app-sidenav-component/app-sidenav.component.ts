import { Component, OnInit } from '@angular/core';
import { UserInfo } from "src/app/shared/models/user-info.model";
import { AuthenticationService } from 'src/app/auth/services/authentication.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './app-sidenav.component.html',
  styleUrls: ['./app-sidenav.component.css']
})
export class AppSidenavComponent implements OnInit {
  display: boolean = true;
  userProfile: UserInfo;

  constructor(
    private _authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.userProfile = new UserInfo();

    this.getUser();
  }

  getUser() {
    this.userProfile = this._authenticationService.getUserInfo();
  }

}
