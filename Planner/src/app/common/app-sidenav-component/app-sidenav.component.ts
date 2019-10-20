import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { UserInfo } from "src/app/shared/models/user-info.model";

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
