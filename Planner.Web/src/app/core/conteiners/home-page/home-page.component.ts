import { Component, OnInit } from '@angular/core';
import { UserInfo } from '../../models/user-info.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'pl-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  userProfile: any;// UserInfo;
  //userInfo:
  isEdit: boolean;

  constructor(
    //private authenticationService: AuthenticationService,
    //private userDataService: UserDataService
    private _userService: UserService
    ) { }

  ngOnInit() {
    this.userProfile = new UserInfo();

    console.log('init');
    this._userService.getUserInfo().subscribe(data =>{
      console.log(data);
    });
  }


  toggleEditUser() {
    this.isEdit = !this.isEdit;
  }

}
