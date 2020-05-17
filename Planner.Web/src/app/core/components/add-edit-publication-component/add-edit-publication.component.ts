import { Component, OnInit, Input } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { PublicationDataService } from 'src/app/core/services/publication-data.service';
import { ValidateLetter } from 'src/app/shared/validators/letter-validator';
import { ApplicationConstants } from 'src/app/shared/constants/constants';
import { HttpEventType } from '@angular/common/http';
import { PublicationAddEditModel } from '../../models/models-publication-component/publication-add-edit.model';
import { NmbdModel } from '../../models/models-publication-component/nmdb.model';
import { SelectItem } from 'primeng/api';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'add-edit-publication',
  templateUrl: './add-edit-publication.component.html',
  styleUrls: ['./add-edit-publication.component.scss']
})
export class AddEditPublicationComponent implements OnInit {
  @Input() publication: PublicationAddEditModel;
  users: SelectItem[] = [];
  researchDoneTypes = ApplicationConstants.RESEARCHDONETYPE;
  storingTypes = ApplicationConstants.STORINGTYPE;
  publicationTypes = ApplicationConstants.PUBLICATION;
  nmbds: SelectItem[] = [];
  // users: SelectItem[]=[];
  collaboratorsNames: string;

  file: File;
  publicationFile: string;
  ua: any;
  invalidDates: Array<Date>;
  rangeDates: Date[];
  minDate: Date;
  maxDate: Date;

  //Publication: Publication[] = [];
  publicationForm: FormGroup;

  constructor(
    private publicationDataService: PublicationDataService,
    private messageService: MessageService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    if (!this.publication) {
      this.publication = new PublicationAddEditModel();
    }

    this.initCalendar();
    let today = new Date();
    let month = today.getMonth();
    let year = today.getFullYear();
    let prevMonth = month === 0 ? 11 : month - 1;
    let prevYear = prevMonth === 11 ? year - 1 : year;
    let nextMonth = month === 11 ? 0 : month + 1;
    let nextYear = nextMonth === 0 ? year + 1 : year;
    this.minDate = new Date();
    this.minDate.setMonth(prevMonth);
    this.minDate.setFullYear(prevYear);
    this.maxDate = new Date();
    this.maxDate.setMonth(nextMonth);
    this.maxDate.setFullYear(nextYear);

    let invalidDate = new Date();
    invalidDate.setDate(today.getDate() - 1);
    this.invalidDates = [today, invalidDate];

    this.getNmbds();
    this.getUsers();
    this.publicationForm = this.fb.group({
      name: new FormControl(
        this.publication.name,
        Validators.compose([
          Validators.required,
          Validators.maxLength(250),
          Validators.minLength(3),
          ValidateLetter,
        ])
      ),
      pages: new FormControl(
        this.publication.pages,
        Validators.compose([Validators.required])
      ),
      filePath: new FormControl(this.publication.filePath, []),
      output: new FormControl(
        this.publication.output,
        Validators.compose([
          Validators.required,
          Validators.maxLength(250),
          Validators.minLength(3),
          ValidateLetter,
        ])
      ),
      publishedAt: new FormControl(
        this.publication.publishedAt,
        Validators.compose([Validators.required])
      ),
      isOverseas: new FormControl(
        this.publication.isOverseas,
        Validators.compose([Validators.required])
      ),
      citationNumberNMBD: new FormControl(
        this.publication.citationNumberNMBD,
        Validators.compose([Validators.required])
      ),
      impactFactorNMBD: new FormControl(
        this.publication.impactFactorNMBD,
        Validators.compose([Validators.required])
      ),
      nmbdId: new FormControl(
        this.publication.nmbdId,
        Validators.compose([Validators.required])
      ),
      storingType: new FormControl(
        this.publication.storingType,
        Validators.compose([Validators.required])
      ),
      publicationType: new FormControl(
        this.publication.publicationType,
        Validators.compose([Validators.required])
      ),
      researchDoneType: new FormControl(
        this.publication.researchDoneType,
        Validators.compose([Validators.required])
      ),
      //'newCollaboratorsIds': new FormControl(this.publication.newCollaboratorsIds, [Validators.required]),
      collaboratorsIds: new FormControl(this.publication.collaboratorsIds, [
        Validators.required,
      ]),
    });

    this.publicationForm.controls.collaboratorsIds.valueChanges.subscribe(
      (s) => {
        if (s) {
          let tempNames = [];
          this.users.forEach((result) => {
            s.forEach((item) => {
              if (result.value == item) {
                tempNames.push(result.label);
              }
            });
          });
          this.collaboratorsNames = tempNames.join(',');
          console.log(this.collaboratorsNames);
        }
        //console.log(s);
      }
    );
  }

  getNmbds() {
    this.publicationDataService.getNMBDs().subscribe((data: NmbdModel[]) => {
      this.configNmdbs(data);
    });
  }

  getUsers() {
    this.publicationDataService.getUsers().subscribe((data) => {
      this.configUsers(data);

      if (this.publicationForm.controls.collaboratorsIds.value) {
        let tempNames = [];
        this.users.forEach((result) => {
          this.publicationForm.controls.collaboratorsIds.value.forEach(
            (item) => {
              if (result.value == item) {
                tempNames.push(result.label);
              }
            }
          );
        });
        this.collaboratorsNames = tempNames.join(',');
      }
    });
  }

  configNmdbs(data: NmbdModel[]) {
    data.forEach((item) => {
      this.nmbds.push({ label: item.name, value: item.nmbdId });
    });
  }

  configUsers(data) {
    console.log(data);
    data.forEach((item) => {
      this.users.push({ label: item.fullName, value: item.applicationUserId });
    });
    console.log(this.users);
  }

  addPublication() {
    //if (this.publicationForm.invalid) return;
    console.log(this.publicationForm.value);

    let tempPublication = <PublicationAddEditModel>this.publicationForm.value;
    if (this.publication)
      tempPublication.publicationId = this.publication.publicationId;

    this.publicationDataService
      .addPublication(tempPublication)
      .subscribe((data) => {
        if (data) {
          this.publicationForm.reset();
          this.messageService.add({
            key: 'success',
            severity: 'error',
            summary: '',
            detail: 'Публікацію успішно додано',
          });
        } else {
          this.messageService.add({
            key: 'error',
            severity: 'error',
            summary: '',
            detail: '',
          });
        }
      });
  }

  getErrorMessage(value: string) {
    if (value == 'Name') {
      if (this.publicationForm.controls['Name'].errors['required']) {
        return `Поле "Назва" - обов'язкове`;
      } else if (this.publicationForm.controls['Name'].errors['minlength']) {
        return `Поле "Назва" повинне мати не менше 3-х символів`;
      } else if (this.publicationForm.controls['Name'].errors['maxLength']) {
        return `Поле "Назва" повинне мати не менше 3-х символів`;
      } else if (this.publicationForm.controls['Name'].errors['validLetter']) {
        return `Коректно заповніть поле "Назва" ! Поле не може мати цифорвих значень!`;
      }
    }
  }

  sendMessage() {
    //this.publicationDataService.sendMessageToLibrary().subscribe(s => {
    //    console.log(s);
    //});
  }

  async uploadFile(data) {
    this.file = data.files[0];
    await this.publicationDataService
      .uploadFiles(this.file)
      .subscribe((event) => {
        if (event.type === HttpEventType.Response) {
          this.publicationFile = event.body.toString();
        }
      });
  }

  initCalendar() {
    this.ua = {
      firstDayOfWeek: 0,
      dayNames: [
        'Понеділок',
        'Вівторок',
        'Середа',
        'Четвер',
        "П'ятниця",
        'Субота',
        'Неділя',
      ],
      dayNamesShort: ['пн', 'вв', 'ср', 'чт', 'пт', 'сб', 'нд'],
      dayNamesMin: ['пн', 'вв', 'ср', 'чт', 'пт', 'сб', 'нд'],
      monthNames: [
        'Січень',
        'Лютий',
        'Березень',
        'Квітень',
        'Травень',
        'Червень',
        'Липень',
        'Серпень',
        'Вересень',
        'Жовтень',
        'Листопад',
        'Грудень',
      ],
      monthNamesShort: [
        'січ',
        'лют',
        'берез',
        'квіт',
        'трав',
        'черв',
        'лип',
        'серп',
        'верес',
        'жовт',
        'листоп',
        'груд',
      ],
      today: 'Сьогодні',
      clear: 'Видалити',
    };
  }
}
