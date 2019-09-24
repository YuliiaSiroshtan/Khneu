import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { LoginModel } from "src/app/account-component/shared/models/login.model";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { UserInfo } from "src/app/shared/models/user-info.model";

@Component({
    selector: 'app-sidenav',
    templateUrl: './app-sidenav.component.html',
  styleUrls: ['./app-sidenav.component.css']
})
export class AppSidenavComponent implements OnInit {
    display: boolean = true;
    userProfile: UserInfo;

    constructor(private router: Router,
        private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.userProfile = new UserInfo();

        this.getUser();
    }

    getUser() {
        this.userProfile = this.authenticationService.getUserInfo();
    }

}
