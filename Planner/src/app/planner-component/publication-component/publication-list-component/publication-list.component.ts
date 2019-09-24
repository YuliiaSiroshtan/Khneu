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
    selector: 'publication-list',
    templateUrl: './publication-list.component.html'
})
export class PublicationListComponent implements OnInit {
    publications: Publication[] = [];

    constructor(private authenticationService: AuthenticationService,
        private publicationDataService: PublicationDataService,
        private router: Router,
        private messageService: MessageService) {
    }

    ngOnInit() {
        this.getUserPublication();
    }



    getUserPublication() {
        this.publicationDataService.getUserPublication().subscribe((result: Publication[]) => {
            if (result) {
                this.publications = result;
            }
        });
    }

    sendMessage(id: string) {
      this.publicationDataService.sendMessageToLibrary(id).subscribe(s => {
        console.log(s);
      });
    }

}
