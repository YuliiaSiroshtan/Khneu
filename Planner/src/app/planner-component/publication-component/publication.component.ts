import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { LoginModel } from "src/app/account-component/shared/models/login.model";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { UserProfileModel } from "src/app/planner-component/home-component/shared/models/user-profile.model";
import { UserInfo } from "src/app/shared/models/user-info.model";
import { Input } from "@angular/core";
import { Output } from "@angular/core";
import { EventEmitter } from "events";
import { UserDataService } from "src/app/planner-component/shared/service/user-data.service";
import { ValidateLetter } from "src/app/shared/validators/letter-validator";
import { ValidateURL } from "src/app/shared/validators/url-validator";
import { ApplicationConstants } from "src/app/shared/constants/constants";
import { HttpEventType } from "@angular/common/http";
import { PublicationDataService } from "src/app/planner-component/publication-component/shared/service/publication-data.service";
import { Publication } from "src/app/planner-component/publication-component/shared/models/publication.model";
import { SelectItem } from "primeng/components/common/selectitem";


@Component({
  selector: 'publication',
  templateUrl: './publication.component.html',
  styleUrls: ['./publication.component.css']
})
export class PublicationComponent implements OnInit {
  @Input() PublicationInfo: Publication;

  Publication: Publication[] = [];
  users: SelectItem[] = []
  publicationForm: FormGroup;

  constructor(private authenticationService: AuthenticationService,
      private publicationDataService: PublicationDataService,
    private router: Router,
    private messageService: MessageService,
    private fb: FormBuilder) {
  }

  ngOnInit() {
    if (!this.PublicationInfo) {
      this.PublicationInfo = new Publication();
      this.getUserPublication();
      this.getUsers();
    }

  }


  getUsers() {
      this.publicationDataService.getUsers().subscribe((data) => {
          this.configUsers(data);
      });
  }

  configUsers(data) {
      console.log(data);
      data.forEach(item => {
          this.users.push({ label: item.fullName, value: item.applicationUserId });
      });
      console.log(this.users);
  }



  getUserPublication() {
      this.publicationDataService.getUserPublication().subscribe((result: Publication[]) => {
      if (result) {
        this.Publication = result;
      }
    });
  }

  getErrorMessage(value: string) {
    if (value == 'Name') {
      if (this.publicationForm.controls['Name'].errors['required']) {
        return `Поле "Назва" - обов'язкове`;
      }
      else if (this.publicationForm.controls['Name'].errors['minlength']) {
        return `Поле "Назва" повинне мати не менше 3-х символів`;
      }
      else if (this.publicationForm.controls['Name'].errors['maxLength']) {
        return `Поле "Назва" повинне мати не менше 3-х символів`;
      }
      else if (this.publicationForm.controls['Name'].errors['validLetter']) {
        return `Коректно заповніть поле "Назва" ! Поле не може мати цифорвих значень!`;
      }
    }
  }
}
