import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { AuthenticationService } from "src/app/shared/components/authentication-component";
import { Router } from "@angular/router";
import { MessageService } from "primeng/components/common/messageservice";
import { ValidateLetter } from "src/app/shared/validators/letter-validator";
import { NDRDataService } from "src/app/planner-component/ndr-component/shared/service/ndr-data.service";
import { NDR } from "src/app/planner-component/ndr-component/shared/models/ndr.model";


@Component({
  selector: 'ndr',
  templateUrl: './ndr.component.html',
  styleUrls: ['./ndr.component.css']
})
export class NDRComponent implements OnInit {
  NDRInfo: NDR;

  NDR: NDR[] = [];

  NDRForm: FormGroup;

  constructor(
    private _NDRDataService: NDRDataService,
    private _messageService: MessageService,
    private _fb: FormBuilder) {
  }

  ngOnInit() {
      this.NDRInfo = new NDR();
      this.getUserNdr();

    this.NDRForm = this._fb.group({
      'fullName': new FormControl(this.NDRInfo.fullName, Validators.compose(
        [Validators.required,
        Validators.maxLength(250),
        Validators.minLength(3),
          ValidateLetter]
      )),
      'type': new FormControl(this.NDRInfo.type, Validators.compose(
        [Validators.required,
        Validators.maxLength(100),
        Validators.minLength(3),
          ValidateLetter]
      )),
      'level': new FormControl(this.NDRInfo.level, Validators.compose(
        [Validators.required,
        Validators.maxLength(100),
        Validators.minLength(3),
          ValidateLetter])),
      'name': new FormControl(this.NDRInfo.name, Validators.compose(
        [Validators.required,
        Validators.maxLength(100),
        Validators.minLength(3),
          ValidateLetter])),
      'step': new FormControl(this.NDRInfo.step, Validators.compose(
        [Validators.required,
        Validators.maxLength(100),
        Validators.minLength(3),
          ValidateLetter])),
      'place': new FormControl(this.NDRInfo.place, Validators.compose(
        [Validators.required,
        Validators.maxLength(100),
        Validators.minLength(3),
          ValidateLetter])),
      'studentName': new FormControl(this.NDRInfo.studentName, Validators.compose(
        [Validators.required,
        Validators.maxLength(250),
        Validators.minLength(3),
          ValidateLetter])),
      'awards': new FormControl(this.NDRInfo.awards, Validators.compose(
        [Validators.required,
        Validators.maxLength(100),
        Validators.minLength(3),
          ValidateLetter]))
    }
    );
  }

  addNDR() {
    if (this.NDRForm.invalid) return;

    let tempNDR = <NDR>this.NDRForm.value;

    this._NDRDataService.addNDR(tempNDR).subscribe(data => {
      if (data) {
          this.NDRForm.reset();
          this.getUserNdr();
          this._messageService.add({ key: 'success', severity: 'success', summary: '', detail: 'НДР студента успішно додано' });
      } else {
        this._messageService.add({ key: 'error', severity: 'error', summary: '', detail: '' });
      }
    });
  }

  getUserNdr() {
    this._NDRDataService.getUserNdr().subscribe((result: NDR[]) => {
      if (result) {
        this.NDR = result;
      }
    });
  }

  getErrorMessage(value: string) {
    if (value == 'fullName') {
      if (this.NDRForm.controls['fullName'].errors['required']) {
        return `Поле "ПІБ викладача" - обов'язкове`;
      }
      else if (this.NDRForm.controls['fullName'].errors['minlength']) {
        return `Поле "ПІБ викладача" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['fullName'].errors['maxLength']) {
        return `Поле "ПІБ викладача" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['fullName'].errors['validLetter']) {
        return `Коректно заповніть поле "ПІБ викладача" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'type') {
      if (this.NDRForm.controls['type'].errors['required']) {
        return `Поле "Тип" - обов'язкове`;
      }
      else if (this.NDRForm.controls['type'].errors['minlength']) {
        return `Поле "Тип" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['type'].errors['maxLength']) {
        return `Поле "Тип" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['type'].errors['validLetter']) {
        return `Коректно заповніть поле "Тип" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'level') {
      if (this.NDRForm.controls['level'].errors['required']) {
        return `Поле "Рівень" - обов'язкове`;
      }
      else if (this.NDRForm.controls['level'].errors['minlength']) {
        return `Поле "Рівень" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['level'].errors['maxLength']) {
        return `Поле "Рівень" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['level'].errors['validLetter']) {
        return `Коректно заповніть поле "Рівень" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'name') {
      if (this.NDRForm.controls['name'].errors['required']) {
        return `Поле "Назва/Напрям" - обов'язкове`;
      }
      else if (this.NDRForm.controls['name'].errors['minlength']) {
        return `Поле "Назва/Напрям" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['name'].errors['maxLength']) {
        return `Поле "Назва/Напрям" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['name'].errors['validLetter']) {
        return `Коректно заповніть поле "Назва/Напрям" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'step') {
      if (this.NDRForm.controls['step'].errors['required']) {
        return `Поле "Етап" - обов'язкове`;
      }
      else if (this.NDRForm.controls['step'].errors['minlength']) {
        return `Поле "Етап" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['step'].errors['maxLength']) {
        return `Поле "Етап" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['step'].errors['validLetter']) {
        return `Коректно заповніть поле "Етап" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'place') {
      if (this.NDRForm.controls['place'].errors['required']) {
        return `Поле "Місце та дата проведення" - обов'язкове`;
      }
      else if (this.NDRForm.controls['place'].errors['minlength']) {
        return `Поле "Місце та дата проведення" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['place'].errors['maxLength']) {
        return `Поле "Місце та дата проведення" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['place'].errors['validLetter']) {
        return `Коректно заповніть поле "Місце та дата проведення" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'studentName') {
      if (this.NDRForm.controls['studentName'].errors['required']) {
        return `Поле "ПІБ студента" - обов'язкове`;
      }
      else if (this.NDRForm.controls['studentName'].errors['minlength']) {
        return `Поле "ПІБ студента" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['studentName'].errors['maxLength']) {
        return `Поле "ПІБ студента" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['studentName'].errors['validLetter']) {
        return `Коректно заповніть поле "ПІБ студента" ! Поле не може мати цифорвих значень!`;
      }
    }
    if (value == 'awards') {
      if (this.NDRForm.controls['awards'].errors['required']) {
        return `Поле "Нагороди" - обов'язкове`;
      }
      else if (this.NDRForm.controls['awards'].errors['minlength']) {
        return `Поле "Нагороди" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['awards'].errors['maxLength']) {
        return `Поле "Нагороди" повинне мати не менше 3-х символів`;
      }
      else if (this.NDRForm.controls['awards'].errors['validLetter']) {
        return `Коректно заповніть поле "Нагороди" ! Поле не може мати цифорвих значень!`;
      }
    }
  }
}
