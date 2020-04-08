import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';
import { LoginModel } from '../../models/auth.models';
import { Router } from '@angular/router';

@Component({
  selector: 'pl-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  userform: FormGroup;
  submitted: boolean;
  
  constructor(
    private _fromBuild: FormBuilder,
    private _authenticationService: AuthenticationService,
    private _router: Router
    ) { }

  ngOnInit(): void {
    this.userform = this._fromBuild.group({
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

  onSubmit(){
    if (this.userform.invalid) return;

    this._authenticationService
      .isAuthenticated({
        login: this.userform.controls.email.value,
        password: this.userform.controls.password.value
      } as LoginModel)
      .subscribe(res => {
        if (res.jwtToken) {
          this._router.navigate(['home']);
        } 
        // else if (res.error) {
        //   this._messageService.add({
        //     key: 'error',
        //     severity: 'error',
        //     summary: '',
        //     detail: res.error
        //   });
        // } else {
        //   this._messageService.add({
        //     key: 'error',
        //     severity: 'error',
        //     summary: '',
        //     detail: 'Некоректний логін чи пароль'
        //   });
        // }
      });
  }
}
