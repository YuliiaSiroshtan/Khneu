import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators
} from '@angular/forms';
import { LoginModel } from 'src/app/auth/models/login.model';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/components/common/messageservice';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'pl-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userform: FormGroup;
  submitted: boolean;

  constructor(
    private _fb: FormBuilder,
    private _authenticationService: AuthenticationService,
    private _router: Router,
    private _messageService: MessageService
  ) {}

  ngOnInit() {
    this.userform = this._fb.group({
      email: new FormControl(
        '',
        Validators.compose([Validators.required, Validators.email])
      ),
      password: new FormControl(
        '',
        Validators.compose([Validators.required, Validators.minLength(4)])
      )
    });
  }

  getErrorMessage(value: string) {
    if (value == 'password') {
      return this.userform.controls['password'].errors['required']
        ? `Пароль - обов'язковий`
        : this.userform.controls['password'].errors['minlength']
        ? 'Пароль повинен мати не менше 4-х символів'
        : '';
    }
    if (value == 'email') {
      return this.userform.controls['email'].errors['required']
        ? `Електронна пошта - обов'язкова`
        : this.userform.controls['email'].errors['email']
        ? 'Некоректний формат електронної пошти'
        : '';
    }
  }

  onSubmit() {
    if (this.userform.invalid) return;

    this._authenticationService
      .isAuthenticated({
        login: this.userform.controls.email.value,
        password: this.userform.controls.password.value
      } as LoginModel)
      .subscribe(res => {
        if (res.jwtToken) {
          this._router.navigate(['home']);
        } else if (res.error) {
          this._messageService.add({
            key: 'error',
            severity: 'error',
            summary: '',
            detail: res.error
          });
        } else {
          this._messageService.add({
            key: 'error',
            severity: 'error',
            summary: '',
            detail: 'Некоректний логін чи пароль'
          });
        }
      });
  }
}
