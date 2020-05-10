import { Component, OnInit } from '@angular/core';
import { FormGroup } from "@angular/forms";
import { Input } from "@angular/core";
import { PublicationDataService } from "src/app/core/services/publication-data.service";
import { SelectItem } from "primeng/api/selectitem";
import { Publication } from '../../models/models-publication-component/publication.model';

@Component({
  selector: 'publication',
  templateUrl: './publication.component.html',
  styleUrls: ['./publication.component.scss']
})
export class PublicationComponent implements OnInit {
  @Input() PublicationInfo: Publication;

  Publication: Publication[] = [];
  users: SelectItem[] = []
  publicationForm: FormGroup;

  constructor(
      private _publicationDataService: PublicationDataService) {
  }

  ngOnInit() {
    if (!this.PublicationInfo) {
      this.PublicationInfo = new Publication();
      this.getUserPublication();
      this.getUsers();
    }

  }


  getUsers() {
      this._publicationDataService.getUsers().subscribe((data) => {
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
      this._publicationDataService.getUserPublication().subscribe((result: Publication[]) => {
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
