import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { LoginModel } from "src/app/account-component/shared/models/login.model";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { UserProfileModel } from "src/app/planner-component/home-component/shared/models/user-profile.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { UserDataService } from "src/app/planner-component/shared/service/user-data.service";

@Component({
    selector: 'home-component',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    userProfile: UserInfo;
    //userInfo:
    isEdit: boolean;

    constructor(private authenticationService: AuthenticationService,
        private userDataService: UserDataService) { }

    ngOnInit() {
        this.userProfile = new UserInfo();
        this.getUser();
    }

    getUser() {
        this.userProfile = this.authenticationService.getUserInfo();
    }

    toggleEditUser() {
        this.isEdit = !this.isEdit;
    }

}
