import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { LoginModel } from "src/app/account-component/shared/models/login.model";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { UserList } from "src/app/planner-component/user-list-component/shared/models/user-list.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { Input } from "@angular/core";
import { Output } from "@angular/core";
import { EventEmitter } from "events";
import { UserDataService } from "src/app/planner-component/shared/service/user-data.service";
import { ValidateLetter } from "src/app/shared/validators/letter-validator";
import { ValidateURL } from "src/app/shared/validators/url-validator";
import { ApplicationConstants } from "src/app/shared/constants/constants";
import { UserListDataService } from "src/app/planner-component/user-list-component/shared/service/user-list-data.service";
import { ConfirmationService } from "primeng/api";


@Component({
  selector: 'user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  userList: UserList[] = [];

  userform: FormGroup;
  isEdit: boolean;
  applicationUserId: string;

  constructor(private authenticationService: AuthenticationService,
    private userListDataService: UserListDataService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private fb: FormBuilder) {
  }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userListDataService.getAllUsers().subscribe((result: UserList[]) => {
      if (result) {
        this.userList = result;
      }
    });
  }

  toggleEditUser(userId) {
      this.applicationUserId = userId;
      this.isEdit = !this.isEdit;
  }

  confirmActivate(userList: UserList) {
      this.confirmationService.confirm({
          message: userList.isActive ? 'Дійсно бажаєте деактивувати користувача?' : 'Дійсно бажаєте активувати користувача?',
          accept: () => {
              this.userListDataService.changeUserStatus(userList.applicationUserId).subscribe((result: UserList[]) => {
                  if (result) {
                      this.getUsers();
                      // console.log(userList.applicationUserId);
                  }
              });
             
          }
      });
  }
}
