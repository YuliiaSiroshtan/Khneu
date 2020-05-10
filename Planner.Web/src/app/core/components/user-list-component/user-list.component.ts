import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from "@angular/forms";
import { UserList } from '../../models/user-list.model';
import { AuthenticationService } from 'src/app/auth/services/authentication.service';
import { UserListDataService } from '../../models/user-list-data.service';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';

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
      console.log('UserListComponent');
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
