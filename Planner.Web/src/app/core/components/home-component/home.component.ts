import { Component, OnInit } from '@angular/core';
import { UserInfo } from "src/app/shared/models/user-info.model";
import { UserDataService } from "src/app/core/services/user-data.service";
import { AuthenticationService } from 'src/app/auth/services/authentication.service';

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
  }


  toggleEditUser() {
    this.isEdit = !this.isEdit;
  }

}
